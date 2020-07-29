using System;
using System.Net;
using System.Net.Mail;

namespace Demo.Core.Util
{
    public static class Email
    {
        public static bool Enviar(string email)
        {
            try
            {
                MailMessage _mailMessage = new MailMessage
                {
                    From = new MailAddress("Email")
                };

                _mailMessage.CC.Add(email);
                _mailMessage.Subject = "Titulo email";
                _mailMessage.IsBodyHtml = true;
                _mailMessage.Body = "Corpo email";

                SmtpClient _smtpClient = new SmtpClient("smtp.gmail.com", Convert.ToInt32("587"))
                {
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential("Email", "Senha"),
                    EnableSsl = true
                };

                _smtpClient.Send(_mailMessage);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
