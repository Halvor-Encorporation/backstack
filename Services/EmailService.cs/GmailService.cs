using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace backstack.Services
{
    public class GmailService : IEmailSender
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<GmailService> _logger;

        public GmailService(IConfiguration configuration, ILogger<GmailService> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }

        public async Task SendEmailAsync(string email, string subject, string message)
        {
            try
            {
                _logger.LogInformation("Preparing to send email to {Email}", email);

                var smtpClient = new SmtpClient(_configuration["Outlook:Smtp:Host"])
                {
                    Port = int.Parse(_configuration["Outlook:Smtp:Port"]),
                    Credentials = new NetworkCredential(_configuration["Outlook:Smtp:Username"], _configuration["Outlook:Smtp:Password"]),
                    EnableSsl = true,
                };

                var mailMessage = new MailMessage
                {
                    From = new MailAddress(_configuration["Outlook:Smtp:From"]),
                    Subject = subject,
                    Body = message,
                    IsBodyHtml = true,
                };

                mailMessage.To.Add(email);

                _logger.LogInformation("Sending email to {Email} via SMTP server {SmtpServer}", email, smtpClient.Host);

                await smtpClient.SendMailAsync(mailMessage);

                _logger.LogInformation("Email sent successfully to {Email}", email);
            }
            catch (SmtpException smtpEx)
            {
                _logger.LogError(smtpEx, "SMTP error occurred while sending email to {Email}", email);
                throw new SmtpException(smtpEx.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while sending email to {Email}", email);
                throw;
            }
        }
    }
}