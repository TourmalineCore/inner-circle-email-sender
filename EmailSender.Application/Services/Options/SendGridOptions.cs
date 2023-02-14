namespace EmailSender.Application.Services.Options
{
    public class SendGridOptions
    {
        public string SendGridAPIKey { get; set; }
        public string SenderEmail { get; set; }
        public string SenderName { get; set; }
    }
}