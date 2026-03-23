using System.ComponentModel.DataAnnotations.Schema;
using Domain.Valid.AttributeValid;

namespace Domain.Entitys.ComplexType;

[ComplexType]
public class FIOEntity 
{
    [Name] public string Name { get; set; }
    [Surname] public string Surname { get; set; }
    [Patronymic] public string? Patronymic { get; set; }

    private FIOEntity() { }

    public FIOEntity(string name, string surname)
    {
        Name = name;
        Surname = surname;
    }
    
    public FIOEntity(string name, string surname, string patronymic)
    {
        Name = name;
        Surname = surname;
        Patronymic = patronymic;
    }

    public override string ToString()
        => $"{Surname} {Name} {Patronymic}";
}