using UserInterface.Info;

namespace UserInterface.UiLayoutPanel.ButtonPanel;

public interface IToolStrip<in TEventArgs>
    where TEventArgs : EventArgs
{
    public List<InfoToolStrip> GetToolStrip(TEventArgs eventArgs);
}