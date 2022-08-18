using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Project.COMMON.Tools
{
    public static class MailSender
    {
        public static void Send(string receiver, string password = "Sa346223--", string body = "Test Mesajıdır", string subject = "E-Mail Testi", string sender = "seval346223@gmail.com")
        {
            MailAddress senderMail = new MailAddress(sender);
            MailAddress receiverEmail = new MailAddress(receiver);

            //Bizim Email işlemlerimiz SMTP'ye göre yapılır...
            //Kullandıgınız Gmail hesabının baska uygulamalar tarafından mesaj gonderme ozelliginiz acmalısınız....
            SmtpClient smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(senderMail.Address, password)
            };


            using (MailMessage message = new MailMessage(senderMail, receiverEmail)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }


        }


    }
}
