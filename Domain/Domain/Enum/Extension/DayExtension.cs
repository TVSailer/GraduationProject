using Domain.Exception;

namespace Domain.Enum.Extension;

public static class DayExtension
{
    public static DayOfWeek ConvertDayOfWeek(this Day day)
    {
        switch (day)
        {
            case Day.Monday: return DayOfWeek.Monday;
            case Day.Thursday: return DayOfWeek.Thursday;
            case Day.Tuesday: return DayOfWeek.Tuesday;
            case Day.Wednesday: return DayOfWeek.Wednesday;
            case Day.Friday: return DayOfWeek.Friday;
            case Day.Saturday: return DayOfWeek.Saturday;
            case Day.Sunday: return DayOfWeek.Sunday;
        }

        throw new EnumException("Нету такого enum");
    }
}