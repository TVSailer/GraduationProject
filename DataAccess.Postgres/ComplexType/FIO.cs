using System.ComponentModel.DataAnnotations.Schema;

[ComplexType]
public class FIO 
{
    public string Name { get; private set; }
    public string Surname { get; private set; }
    public string Patronymic { get; private set; }

    public FIO() { }

    public FIO(string name, string surname, string patronymic)
    {
        Name = name;
        Surname = surname;
        Patronymic = patronymic;
    }
    
    public FIO(string fio)
    {
        if (fio is null) throw new ArgumentNullException();

        var list = fio.Split(" ");

        if (list.Length != 3) throw new ArgumentNullException();

        Name = list[0];
        Surname = list[1];
        Patronymic = list[2];
    }

    public static bool TryValidFIO(string fio)
    {
        if (fio is null) return false;

        var list = fio.Split(" ");

        return list.Length == 3;
    }

    public override string ToString()
            => $"{Surname} {Name} {Patronymic}";
}