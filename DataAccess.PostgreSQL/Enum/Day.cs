using System.ComponentModel;

namespace DataAccess.PostgreSQL.Enum;

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