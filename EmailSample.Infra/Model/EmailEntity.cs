using System;

namespace EmailSample.Domain.Model
{
    public class EmailEntity
    {
        public string Id { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }
        public string BBC { get; set; }
        public string CC { get; set; }
        public string Message { get; set; }
        public bool IsBodyHtml { get; set; }
        public bool IsReceived { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
