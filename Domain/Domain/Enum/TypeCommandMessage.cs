using System.ComponentModel;

namespace Domain.Enum;

public enum TypeCommandMessage
{
    [Description("Да")] Yes, 
    [Description("Нет")] No, 
    [Description("Отмена")] Cancel,
    [Description("Ок")] Ok,
}