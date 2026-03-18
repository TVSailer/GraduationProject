using System.ComponentModel;

namespace Visitor.Enum;

public enum Estimation
{
    [Description("Отлично")] Excellent,
    [Description("Хорошо")] Good,
    [Description("Удовлетворительно")] Satisfactory,
    [Description("Умеренно")] Moderately,
    [Description("Плохо")] Badly,
}