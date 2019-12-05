using EmailSample.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmailSample.Domain.Services
{
    public interface IEmailServices
    {
        bool SendEmail();
        Task<bool> ReceiveEmail(string id);
    }
}
