using System.ComponentModel.DataAnnotations.Schema;


[ComplexType]
public class FIO 
{
    public string Name { get; private set; }
    public string Surname { get; set; }
    public string Patronymic { get; set; }

    public FIO() { }

    public FIO(string? fio)
    {
        if (!TryValidFio(fio, out var result)) throw new ArgumentException();

        Surname = result[0];
        Name = result[1];
        Patronymic = result[2];
    }

    public static bool TryValidFio(string? fio, out string[]? result)
    {
        if (fio is null)
        {
            result = null;
            return false;
        }

        var list = fio.Split(separator: " ");

        if (list.Length != 3)
        {
            result = null;
            return false;
        }

        result = list;
        return true;
    }

    public override string ToString()
            => $"{Surname} {Name} {Patronymic}";
}