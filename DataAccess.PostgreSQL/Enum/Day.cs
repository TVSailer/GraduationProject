using System.ComponentModel;

namespace DataAccess.Postgres.Enum;

public enum Day
{
    [Description(description: "Понедельник")] Monday, 
    [Description(description: "Вторник")] Tuesday, 
    [Description(description: "Среда")] Wednesday,
    [Description(description: "Четверг")] Thursday,
    [Description(description: "Пятница")] Friday,
    [Description(description: "Суббота")] Saturday,
    [Description(description: "Воскресенье")] Sunday
}

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

        throw new Exception();
    }
}