using System.ComponentModel;

namespace Domain.Enum;

public enum Estimation
{
    [Description("Отлично")] Excellent = 5,
    [Description("Хорошо")] Good = 4,
    [Description("Удовлетворительно")] Satisfactory = 3,
    [Description("Умеренно")] Moderately = 2,
    [Description("Плохо")] Badly = 1,
}