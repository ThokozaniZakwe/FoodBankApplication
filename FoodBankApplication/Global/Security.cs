using FoodBankApplication.Global.interfaces;
using Microsoft.Extensions.Options;
using System.Security.Cryptography;
using System.Text;
using System.Net.Mail;
using System.Net;

namespace FoodBankApplication.Global
{
    public static class Security
    {
        public static string GenerateSalt()
        {
            return Guid.NewGuid().ToString().Replace("-", "") + Guid.NewGuid().ToString().Replace("-", "");
        }

        public static string GenerateHash(string password)
        {
            SHA256 sHA256 = SHA256.Create();

            var bytePassword = Encoding.Default.GetBytes(password);
            //var bytePassword = Encoding.UTF8.GetBytes(password);

            var byteHash = sHA256.ComputeHash(bytePassword);

            return Convert.ToHexString(byteHash);//Encoding.Default.GetString(byteHash);
        }
    }

    public class SmtpSetting
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
    }

    public class EmailService : IEmailService
    {
        private readonly IOptions<SmtpSetting> _smtpSetting;
        public EmailService(IOptions<SmtpSetting> smtpSetting)
        {
            _smtpSetting = smtpSetting;
        }
        public async Task SendAsync(string from, string to, string subject, string body)
        {
                var emailMessage = new MailMessage(from, to, subject, body);
                using (var emailClient = new SmtpClient(_smtpSetting.Value.Host, _smtpSetting.Value.Port))
                {
                    emailClient.EnableSsl = true;
                    emailClient.Credentials = new NetworkCredential(_smtpSetting.Value.User, _smtpSetting.Value.Password);
                    await emailClient.SendMailAsync(emailMessage);
                }
        }
    }
}
