namespace Admin.ViewModel.Interface;

public interface IButtons<in TEventArgs>
{
    public List<CustomButton>? GetButtons(object? send, TEventArgs? eventArgs);
}

public interface IButton<in TEventArgs>
{
    public CustomButton? GetButton(object? send, TEventArgs eventArgs);
}