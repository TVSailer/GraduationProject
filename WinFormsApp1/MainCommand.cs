using System.Windows.Input;

public class MainCommand : ICommand
{
    public event EventHandler? CanExecuteChanged;
    Action<object?> action;
    public MainCommand(Action<object?> action)
    {
        this.action = action;
    }
    public bool CanExecute(object? parameter) => true;

    public void Execute(object? parameter) => action?.Invoke(parameter);
}