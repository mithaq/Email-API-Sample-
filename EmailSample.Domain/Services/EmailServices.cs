using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using EmailSample.Data.Interfaces;
using EmailSample.Domain.Model;
using System.Data;

namespace EmailSample.Domain.Services
{
    public class EmailServices: IEmailServices
    {
        private SmtpClient _smtpClient;
        private IEmailRepo _emailRepo { get; set; }

        public EmailServices(SmtpClient smtpClient, IEmailRepo emailRepo)
        {
            _smtpClient = smtpClient;
            _emailRepo = emailRepo;
        }
        public bool SendEmail()
        {
            Guid newId = Guid.NewGuid();
            EmailEntity email = new EmailEntity
            {
                Id = newId.ToString(),
                From = "me@contoso.com",
                To = "ben@contoso.com",
                Subject = "test message 1",
                Message = $"This is a test email message sent by an application.<img src=\"https://Your_Api_Address_Here/api/Receiv/{newId}.jpg\"/>",
            IsBodyHtml = true,
                IsReceived = false,
                TimeStamp = DateTime.Now
            };

            var id = _emailRepo.InsertAsync(email);

            MailAddress from = new MailAddress(email.From, "Jane Clayton", System.Text.Encoding.UTF8);
            MailAddress to = new MailAddress(email.To);
            MailMessage message = new MailMessage(from, to);
            message.IsBodyHtml = email.IsBodyHtml;
            message.Body =email.Message ;
            message.BodyEncoding = System.Text.Encoding.UTF8;
            message.Subject =email.Subject ;
            message.SubjectEncoding = System.Text.Encoding.UTF8;
            string userState = "test message1";
            _smtpClient.SendAsync(message, userState);
            message.Dispose();

            

            return true;
        }
        public async Task<bool> ReceiveEmail(string id)
        {
            return await _emailRepo.ReceiveEmail(id);
        }
    }
}
