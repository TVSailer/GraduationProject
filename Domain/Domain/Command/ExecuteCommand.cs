using Domain.Command.Base;

namespace Domain.Command;

public class ExecuteCommand(
    Action<object?> execute,
    Func<object?, bool>? canExecute = null) : BaseCommand
{
    public override bool CanExecute(object? parameter) => canExecute?.Invoke(parameter) ?? true;
    public override void Execute(object? parameter) => execute(parameter);
}