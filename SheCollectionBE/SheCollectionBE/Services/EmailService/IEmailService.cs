using SheCollectionBE.DB_Models;

namespace SheCollectionBE.Services.EmailService
{
    public interface IEmailService: IService<EmailResetModel>
    {
        bool SendResetMail(string email);
        bool SendEmail(string body, string subject, string email);
    }
}
