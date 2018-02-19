using Domain;

namespace Services
{
    public interface IEMailGateway
    {
        void SendPromotionalEMail(string email, CustomerStatus status);
        void SendMail(string to, string subject, string body);
    }
}
