using Microsoft.AspNetCore.Identity.UI.Services;

namespace BlazorBoard.Areas.Identity.Services
{
    //Abstractions: Interfaces => IEmailSender
    //Implemenrations: Classes => EmailSender, SendGridEmailSender, ...
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            return Task.CompletedTask;
        }
    }
}
