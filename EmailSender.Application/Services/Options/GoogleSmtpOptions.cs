namespace EmailSender.Application.Services.Options
{
    public class GoogleSmtpOptions
    {
        public string Host { get; set; }
        public string Port { get; set; }
        public string FromEmail { get; set; }
        public string FromPassword { get; set; }
    }
}
