using System.ComponentModel;

namespace Domain.Enum;

public enum UserRole
{
    [Description("Администратор")] Admin = 1,
    [Description("Преподователь")] Teacher = 2,
    [Description("Посититель")] Visitor = 3
}