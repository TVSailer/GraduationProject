using Admin.ViewModel.Interface;

public interface IButtons<in TEventArgs>
{
    public List<CustomButton>? GetButtons(object? data, TEventArgs? eventArgs);
}
    
