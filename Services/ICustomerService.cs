using Domain.Infrastructure;

namespace Services
{
    public interface ICustomerService
    {
        string RefillBalance(int customerId, decimal moneyAmount);
        void Log(Result result);
    }
}
