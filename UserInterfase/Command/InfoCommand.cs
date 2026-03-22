using System.Windows.Input;

namespace UserInterface.Command;

public sealed class InfoCommand
{
    public InfoCommand(string text, ICommand command)
    {
        Text = text;
        Command = command;
    }

    public InfoCommand(ICommand command)
    {
        Text = string.Empty;
        Command = command;
    }

    internal readonly string Text;
    internal readonly ICommand? Command;
}

