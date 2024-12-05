using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace Cosmalyze.Api.Utilities
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            // Logic to send email
            return Task.CompletedTask;
        }
    }
}