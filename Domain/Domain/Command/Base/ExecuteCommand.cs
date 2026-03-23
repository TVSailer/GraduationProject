using System.Windows.Input;

namespace Domain.Command.Base;

public abstract class BaseCommand : ICommand
{
    public abstract bool CanExecute(object? parameter);
    public abstract void Execute(object? parameter);

    public event EventHandler? CanExecuteChanged;
}