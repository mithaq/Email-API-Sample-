namespace EmailSample.Domain.Model
{
    public class AppConfiguration
    {
        public string ApplicationName { get; set; }
        public string ApplicationBasePath { get; set; } = "/";
        public string DefaultConnection { get; set; }
        public EmailConfiguration Email { get; set; } = new EmailConfiguration();
    }
    public class EmailConfiguration
    {
        public SmtpConfiguration Smtp { get; set; } = new SmtpConfiguration();
    }
    public class SmtpConfiguration
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
