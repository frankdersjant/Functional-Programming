using System;

namespace Domain.Infrastructure
{
    public static class ResultExtension
    {
        public static Result<T> ToResult<T>(this Option<T> option, string errorMessage) where T : class
        {
            if (option.HasNoValue)
                return Result.Fail<T>(errorMessage);

            return Result.OK(option.Value);
        }

        public static Result OnSuccess(this Result result, Action action)
        {
            if (result.isFailure)
                return result;

            action();

            return Result.Ok();
        }

        public static Result OnSuccess(this Result result, Func<Result> func)
        {
            if (result.isFailure)
                return result;

            return func();
        }

        public static Result OnFailure(this Result result, Action action)
        {
            if (result.isFailure)
            {
                action();
            }

            return result;
        }

        //eg: use for logging
        public static Result OnBoth(this Result result, Action<Result> action)
        {
            action(result);

            return result;
        }

        //eg: use for logging
        public static T OnBoth<T>(this Result result, Func<Result, T> func)
        {
            return func(result);
        }
    }
}
