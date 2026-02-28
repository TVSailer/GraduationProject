using System.Windows.Forms;

namespace UserInterface.LayoutPanel;

public interface IBuilder
{
    Control Build();
}