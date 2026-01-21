public static class TimeExtension
{
    public static TimeOnly HousMinute(this DateTime dateTime)
    {
        return new TimeOnly(dateTime.Hour, dateTime.Minute);
    }
    
    public static TimeOnly HousMinute(this DateTimePicker dateTime)
    {
        return new TimeOnly(dateTime.Value.Hour, dateTime.Value.Minute);
    }
}
