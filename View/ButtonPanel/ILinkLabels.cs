using System.Windows.Forms;
using UserInterface.Args;

namespace UserInterface.UiLayoutPanel.ButtonPanel;

public interface ILinkLabels<TData>
{
    public InfoLinkLabel[] GetLinkLabels(LinkLabelArgs<TData> eventArgs);
}
