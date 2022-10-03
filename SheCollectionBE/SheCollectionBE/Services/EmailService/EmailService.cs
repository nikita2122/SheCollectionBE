using SheCollectionBE.Context;
using SheCollectionBE.DB_Models;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace SheCollectionBE.Services.EmailService
{
    public class EmailService : Service<EmailResetModel>, IEmailService
    {
        public EmailService(SheCollectionContext context) : base(context)
        {
        }

        public override EmailResetModel Create(EmailResetModel entity)
        {
            EmailResetModel model = context.EmailResetTable.Add(entity).Entity;
            context.SaveChanges();
            return model;
        }

        public override bool Delete(int id)
        {
            try
            {
                context.EmailResetTable.Remove(GetById(id));
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public override List<EmailResetModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public override List<EmailResetModel> GetBy(Func<EmailResetModel, bool> predicate)
        {
            return context.EmailResetTable.Where(predicate).ToList();
        }

        public override EmailResetModel GetById(int id)
        {
            return context.EmailResetTable.FirstOrDefault(e => e.EmailResetId == id);
        }

        public bool SendResetMail(string email)
        {
            EmailResetModel model = new EmailResetModel()
            {
                EmailAddress = email,
                Code = GenerateRandomString(10)
            };
           
            Create(model);

            return SendEmail($"Reset your password with the following link: http://localhost:4200/reset-password/{email}/{model.Code}",
                "SheCollection - Reset Password",
                email);
        }

        public bool SendEmail(string body, string subject, string email)
        {
            string from = "Inf370team39@gmail.com"; //From address    
            MailMessage message = new MailMessage(from, email);

            string mailbody = body;
            message.Subject = subject;
            message.BodyEncoding = Encoding.UTF8;
            message.IsBodyHtml = true;
            message.Body = mailbody;
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587); //Gmail smtp    
            NetworkCredential basicCredential1 = new NetworkCredential("Inf370team39@gmail.com", "tkzegvjnbplntfvq");
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = basicCredential1;

            try
            {
                client.Send(message);
            }

            catch (Exception ex)
            {
                return false;
            }

            return true;
        }

        public override bool Update(int id, EmailResetModel entity)
        {
            throw new NotImplementedException();
        }

        private string GenerateRandomString(int length)
        {
            // creating a StringBuilder object()
            StringBuilder str_build = new StringBuilder();
            Random random = new Random();

            char letter;

            for (int i = 0; i < length; i++)
            {
                double flt = random.NextDouble();
                int shift = Convert.ToInt32(Math.Floor(25 * flt));
                letter = Convert.ToChar(shift + 65);
                str_build.Append(letter);
            }
            return str_build.ToString();
        }
    }
}
