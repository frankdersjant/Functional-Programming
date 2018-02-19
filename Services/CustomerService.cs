using Data.Repo;
using Domain;
using Domain.Infrastructure;

namespace Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerDataRepo<CustomerManagement> _database;
        private readonly IPaymentGateway _paymentGateway;

        public CustomerService(ICustomerDataRepo<CustomerManagement> database, IPaymentGateway paymentGateway)
        {
            _database = database;
            _paymentGateway = paymentGateway;
        }

        public void Log(Result result)
        {
            if (result.isFailure)
            {
                //log stuff;
            }
            else
            {
                //log stuff;
            }
            throw new System.NotImplementedException();
        }

        public string RefillBalance(int customerId, decimal moneyAmount)
        {
            Result<MoneyToCharge> moneyToCharge = MoneyToCharge.Create(moneyAmount);
            Result<CustomerManagement> customer = _database.GetById(customerId).ToResult("Customer is not found");

            return Result.Combine(moneyToCharge, customer)
                .OnSuccess(() => customer.value.AddBalance(moneyToCharge.value))
                .OnSuccess(() => _paymentGateway.ChargePayment(customer.value.BillingInfo, moneyToCharge.value))
                .OnSuccess(
                    () => _database.Save(customer.value)
                        .OnFailure(() => _paymentGateway.RollbackLastTransaction()))
                .OnBoth(result => Log(result))
                .OnBoth(result => result.isSuccues ? "OK" : result.Error);
        }
    }
}
