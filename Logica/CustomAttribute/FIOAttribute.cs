using System.ComponentModel.DataAnnotations;

namespace Logica.CustomAttribute;

public class FIOAttribute : RequiredAttribute
{
    public FIOAttribute()
    {
        ErrorMessage = "Неверно введено ФИО!";
    }

    public override bool IsValid(object? value)
    {
        if (value is not string fio) return false;

        return fio.Split(" ").Length == 3;
    }
}