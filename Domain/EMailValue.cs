using Domain.Infrastructure;
using System.Text.RegularExpressions;

namespace Domain
{
    public class EMailValue : BaseValueObject<EMailValue>
    {
        private readonly string _value;

        private EMailValue(string value)
        {
            _value = value;
        }

        public static Result<EMailValue> Create(string Email)
        {
            if (string.IsNullOrWhiteSpace(Email))
                return Result.Fail<EMailValue>("Mail address cannot be empty");

            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(Email);
            if (!match.Success)
                return Result.Fail<EMailValue>("Format of mail is incorrect");

            return Result.OK(new EMailValue(Email));
        }

        protected override bool EqualsCore(EMailValue other)
        {
            return _value == other._value;
        }

        protected override int GetHashCodeCore()
        {
            return _value.GetHashCode();
        }

        public static explicit operator EMailValue(string email)
        {
            return Create(email).value;
        }

        public static implicit operator string(EMailValue email)
        {
            return email._value;
        }
    }
}
