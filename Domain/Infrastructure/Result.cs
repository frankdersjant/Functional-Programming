using System;

namespace Domain.Infrastructure
{
    public class Result
    {
        public bool isSuccues { get; }
        public string Error { get; private set; }
        public bool isFailure => !isSuccues;

        protected Result(bool issucces, string error)
        {
            if (issucces && error != string.Empty) throw new InvalidOperationException();
            if (!issucces && error == string.Empty) throw new InvalidOperationException();

            isSuccues = issucces;
            Error = error;
        }

        public static Result Fail(string message)
        {
            return new Result(false, message);
        }

        public static Result<T> Fail<T>(string message)
        {
            return new Result<T>(default(T), false, message);
        }

        public static Result Ok()
        {
            return new Result(true, string.Empty);
        }

        public static Result<T> OK<T>(T value)
        {
            return new Result<T>(value, true, string.Empty);
        }

        public static Result Combine(params Result[] results)
        {
            foreach (Result result in results)
            {
                if (result.isFailure)
                    return result;
            }

            return Ok();
        }
    }

    public class Result<T> : Result
    {
        private readonly T _value;

        public T value
        {
            get
            {
                if (!isSuccues) throw new InvalidOperationException();
                return _value;
            }
        }

        protected internal Result(T value, bool issucces, string message) : base(issucces, message)
        {
            _value = value;
        }
    }
}