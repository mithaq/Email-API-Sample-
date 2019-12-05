using EmailSample.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EmailSample.Domain;

namespace EmailSample.Data.Interfaces
{
    public interface IEmailRepo
    {
        Task<EmailEntity> GetEmailByID(string id);
        List<EmailEntity> GetEmails(string fromEmail, string toEmail);
        Task<string> InsertAsync(EmailEntity email);
        Task<bool> ReceiveEmail(string id);
    }
}
