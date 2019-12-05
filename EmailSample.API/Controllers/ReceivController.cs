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
    public class ReceivController : ControllerBase
    {
        private readonly ILogger<ReceivController> _logger;
        private IEmailServices _mailServices { get; set; }

        public ReceivController(ILogger<ReceivController> logger, IEmailServices mailServices)
        {
            _logger = logger;
            _mailServices = mailServices;
        }

        [HttpGet("{filename}")]
        public IActionResult Get(string filename)
        {           
            string id = filename.Replace(".jpg", string.Empty);
            var resullt = _mailServices.ReceiveEmail(id);
            var image = System.IO.File.OpenRead("C:\\test\\r.jpeg"); //==> 1px * 1px
            return File(image, "image/jpeg");
        }
    }
}
