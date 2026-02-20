using Logica.UI;

namespace Logica.Interface;

public interface IButtons<in TEventArgs>
{
    public List<CustomButton>? GetButtons(object? send, TEventArgs? eventArgs);
}

public interface IButton<in TEventArgs>
{
    public CustomButton? GetButton(object? send, TEventArgs eventArgs);
}