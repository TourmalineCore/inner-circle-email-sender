using Microsoft.AspNetCore.Http;

namespace Application.Models;

public class MailFileModel
{
    public string To { get; set; }
    public string Subject { get; set; }
    public string Body { get; set; }
    public IFormFile File { get; set; }
}