using UserInterface.Info;

namespace UserInterface.UiLayoutPanel.ButtonPanel;

public interface IButtons<in TEventArgs>
    where TEventArgs : EventArgs
{
    public InfoButton[] GetButtons(TEventArgs eventArgs);
}

