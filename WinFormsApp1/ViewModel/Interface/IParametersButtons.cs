using Admin.ViewModel.Managment;

public interface IParametersButtons<T>
{
    public List<ButtonInfo> GetButtons(T instance);
}
    
