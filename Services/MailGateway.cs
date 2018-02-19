using Domain;
using System.Net.Mail;

namespace Services
{
    public class MailGateway : IEMailGateway
    {
        public void SendMail(string to, string subject, string body)
        {
            var Message = new MailMessage("blaat@blaat.com", to, subject, body);
            var Client = new SmtpClient();
            Client.Send(Message);
        }

        public void SendPromotionalEMail(string email, CustomerStatus status)
        {
            SendMail(email, "Congratulations", "You have been promoted");
        }
    }
}
