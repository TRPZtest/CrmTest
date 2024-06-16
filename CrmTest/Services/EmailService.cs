using System.Net.Mail;
using System.Net;
using Microsoft.AspNetCore.Identity.UI.Services;
using Humanizer;
using System.Net.Http;

namespace CrmTest.Services
{
    public class EmailService 
    {
        private readonly ILogger<EmailService> _logger;

        public EmailService(ILogger<EmailService> logger)         
        {
            _logger = logger;
        }

        public void SendEmailAsync(string to, string subject, string htmlMessage)
        {
            using var client = new SmtpClient("smtp.gmail.com", 587)
            {
                EnableSsl = true,
                Credentials = new NetworkCredential("crm634452@gmail.com", "gxsx vsrx wrmx vwog"),
                
            };


            client.Send("crm634452@gmail.com", to, subject, htmlMessage);
        }
    }
}
