using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using EmailSample.Domain.Model;
using EmailSample.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;

namespace Email.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailController : ControllerBase
    {
        private readonly ILogger<MailController> _logger;
        private IEmailServices _mailServices { get; set; }

        public MailController(ILogger<MailController> logger, IEmailServices mailServices)
        {
            _logger = logger;
            _mailServices = mailServices;
        }


        [HttpPost]
        public async Task<IActionResult> Post()
        {
            var resullt =_mailServices.SendEmail();
            return new OkObjectResult(resullt);
        }
    }
}
