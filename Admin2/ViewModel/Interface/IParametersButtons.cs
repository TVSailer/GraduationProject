using Admin.ViewModel.Interface;

public interface IButtons<TEventArgs>
{
    public List<CustomButton<TEventArgs>> GetButtons(object? data = null);
}
    
