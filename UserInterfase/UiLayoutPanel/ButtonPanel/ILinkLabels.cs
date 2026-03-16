using System.Windows.Forms;
using UserInterface.Info;
using UserInterface.UiLayoutPanel.CardPanel.Args;

namespace UserInterface.UiLayoutPanel.ButtonPanel;

public interface ILinkLabels<TData>
{
    public InfoLinkLabel[] GetLinkLabels(LinkLabelArgs<TData> eventArgs);
}
