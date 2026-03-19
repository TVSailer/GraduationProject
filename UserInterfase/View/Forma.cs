using System.Windows.Forms;
using UserInterface.LayoutPanel;

namespace UserInterface.View;

public abstract class Forma : Form
{
    public Forma()
    {
        StartPosition = FormStartPosition.CenterScreen;
    }

    public abstract IBuilder ControlUi(BuilderLayoutPanel builderLayoutPanel);
}