using System.ComponentModel;

namespace DataAccess.PostgreSQL.Enum;

public enum Day
{
    [Description("Понедельник")] Monday, 
    [Description("Вторник")] Tuesday, 
    [Description("Среда")] Wednesday,
    [Description("Четверг")] Thursday,
    [Description("Пятница")] Friday,
    [Description("Суббота")] Saturday,
    [Description("Воскресенье")] Sunday
}