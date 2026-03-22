using System.ComponentModel.DataAnnotations;
using Domain.Entitys.ComplexType;

namespace Domain.Valid.AttributeValid;

public class FIOAttribute : RequiredAttribute
{
    public FIOAttribute()
    {
        ErrorMessage = "Неверно введено ФИО!";
    }

    public override bool IsValid(object? value)
    {
        if (value is string val)
        {
            var str = val.Split(" ");

            switch (str.Length)
            {
                case 2:
                {
                    if (!Validatoreg.TryValidObject(new FIO(str[0], str[1]), out var results))
                    {
                        ErrorMessage = results.ToString();
                        return false;
                    }

                    return true;
                }
                case 3:
                {
                    if (!Validatoreg.TryValidObject(new FIO(str[0], str[1], str[2]), out var results))
                    {
                        ErrorMessage = results.ToString();
                        return false;
                    }

                    return true;
                }
            }

            return false;
        }

        if (value is FIO fio)
        {
            if (!Validatoreg.TryValidObject(fio, out var results))
            {
                ErrorMessage = results.ToString();
                return false;
            }

            return true;
        }

        return false;
    }
}