namespace Admin.ViewModel.Managment;

public class ButtonInfo
{
    public string LabelText { get; private set; }
    public Action<object> Command { get; private set; }

    public ButtonInfo(string text, Action<object> command)
    {
        LabelText = text;
        Command = command;
    }

}