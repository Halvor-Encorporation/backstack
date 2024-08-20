using System.Threading.Tasks;

namespace backstack.Services;

public interface IEmailSender
{
    Task SendEmailAsync(string email, string subject, string message);
}
