using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmailSample.Data.Context;
using EmailSample.Domain.Model;
using EmailSample.Data.Interfaces;

namespace EmailSample.Data.Repositories
{
    public class EmailRepo : IEmailRepo
    {
        private DatabaseContext _context { get; set; }
        public EmailRepo(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<EmailEntity> GetEmailByID(string id)
        {
            EmailEntity result = _context.Email.FirstOrDefault(e => e.Id.ToString() == id);
            return result;
        }
        public List<EmailEntity> GetEmails(string fromEmail, string toEmail)
        {
            List<EmailEntity> result = _context.Email.Where(e => e.From == fromEmail && e.To == toEmail).ToList();
            return result;
        }
        private async Task<bool> UpdateAsync(EmailEntity mail)
        {
            try
            {
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<string> InsertAsync(EmailEntity email)
        {
            _context.Email.Add(email);
            await _context.SaveChangesAsync();
            return email.Id.ToString();
        }

        public async Task<bool> ReceiveEmail(string id)
        {
            var result = await GetEmailByID(id);
            if (result != null)
            {
                result.IsReceived = true;
                return await UpdateAsync(result);
            }
            return false;
        }
    }
}
