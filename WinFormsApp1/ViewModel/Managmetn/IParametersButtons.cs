using Admin.ViewModel.Managment;

public interface IParametersButtons<T> : IParametersButtons
    where T : IParam
{

}

public interface IParametersButtons

{
    public List<ButtonInfo> buttons { get; }
}