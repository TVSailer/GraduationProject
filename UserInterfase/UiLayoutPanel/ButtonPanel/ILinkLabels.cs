using UserInterface.Info;

namespace UserInterface.UiLayoutPanel.ButtonPanel;

public interface ILinkLabels<in TEventArgs>
    where TEventArgs : EventArgs
{
    public List<InfoLinkLabel> GetLinkLabels(TEventArgs eventArgs);
}