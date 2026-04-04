using CSharpFunctionalExtensions;

namespace Domain.Extension;

public static class StringExtensions
{
    public static Result<DateTime> ToDateTime(this string date)
    {
        if (!DateTime.TryParse(date, out var result)) Result.Failure<DateTime>("Не является датой");
        return Result.Success(result);
    }
}