using Domain.Infrastructure;
using System;

namespace Domain
{
    public class Customer
    {
        public decimal Balance { get; private set; }
        public string BillingInfo { get; private set; }
        public int Id { get; private set; }
        public CustomerNameValue CustomerNameValue { get; private set; }
        public EMailValue EMailValue { get; private set; }

        public Customer(CustomerNameValue cnv, EMailValue ev)
        {
            CustomerNameValue = cnv ?? throw new ArgumentNullException(nameof(cnv));
            EMailValue = ev ?? throw new ArgumentNullException(nameof(ev));
        }

        public void ChangeMail(EMailValue email)
        {
            EMailValue = email ?? throw new ArgumentNullException(nameof(email));
        }

        public void ChangeName(CustomerNameValue customerName)
        {
            CustomerNameValue = customerName ?? throw new ArgumentNullException(nameof(customerName));
            CustomerNameValue = customerName;
        }

        public void AddBalance(MoneyToCharge amount)
        {
            Balance += amount;
        }
    }
}
