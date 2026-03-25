using System.ComponentModel.DataAnnotations.Schema;
using Domain.Valid.AttributeValid;

namespace Domain.Entitys.ComplexType;

[ComplexType]
public class FIO 
{
    

    private FIO() { }

    public FIO(string name, string surname)
    {
        Name = name;
        Surname = surname;
    }
    
    public FIO(string name, string surname, string patronymic)
    {
        Name = name;
        Surname = surname;
        Patronymic = patronymic;
    }

    public override string ToString()
        => $"{Surname} {Name} {Patronymic}";
}