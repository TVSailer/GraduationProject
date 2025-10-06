
namespace Logica;
public class StripMenuItem
{
    public readonly string Name;
    public readonly Action Action;

    public StripMenuItem(string name, Action action)
    {
        Name = name;
        Action = action;
    }
}
