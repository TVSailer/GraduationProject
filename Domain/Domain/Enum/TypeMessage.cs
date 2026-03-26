using System.ComponentModel;

namespace Domain.Enum;

public enum TypeMessage
{
    [Description("Ошибка")] Error, 
    [Description("Информация")] Info, 
    [Description("Предупреждение")] Warning,
    [Description("Да/Нет")] YesNo,
    [Description("Ок/Отмена")] YesCancel,
}