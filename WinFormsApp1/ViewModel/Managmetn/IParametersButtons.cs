using Admin.ViewModel.Managment;

public interface IParametersButtons<T> : IParametersButtons
{

}

public interface IParametersButtons

{
    public List<ButtonInfo> buttons { get; }
}