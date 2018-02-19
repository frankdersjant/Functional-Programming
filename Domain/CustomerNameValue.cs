using Domain.Infrastructure;

namespace Domain
{
    public class CustomerNameValue : BaseValueObject<CustomerNameValue>
    {
        private readonly string _value;

        private CustomerNameValue(string value)
        {
            _value = value;
        }

        public static Result<CustomerNameValue> Create(string customerName)
        {
            if (string.IsNullOrWhiteSpace(customerName))
                return Result.Fail<CustomerNameValue>("Customer name should not be empty");

            customerName = customerName.Trim();
            if (customerName.Length > 100)
                return Result.Fail<CustomerNameValue>("Customer name is too long");

            return Result.OK(new CustomerNameValue(customerName));
        }

        protected override bool EqualsCore(CustomerNameValue other)
        {
            return _value == other._value;
        }

        protected override int GetHashCodeCore()
        {
            return _value.GetHashCode();
        }

        public static explicit operator CustomerNameValue(string customerName)
        {
            return Create(customerName).value;
        }

        public static implicit operator string(CustomerNameValue customerName)
        {
            return customerName._value;
        }
    }
}
