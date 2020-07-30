using System;
using System.Net;
using System.Net.Mail;

namespace TurtlePizzaria.Core.Util
{
    public static class Email
    {
        public static bool Enviar(string email)
        {
            // TODO: Refatorar 
            try
            {
                MailMessage _mailMessage = new MailMessage
                {
                    From = new MailAddress("ga_lok.10@hotmail.com")
                };

                _mailMessage.CC.Add(email);
                _mailMessage.Subject = "Titulo email";
                _mailMessage.IsBodyHtml = true;
                _mailMessage.Body = "Corpo email";

                SmtpClient _smtpClient = new SmtpClient("smtp.live.com", Convert.ToInt32("587"))
                {
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential("email", "senha"),
                    EnableSsl = true
                };

                _smtpClient.Send(_mailMessage);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
