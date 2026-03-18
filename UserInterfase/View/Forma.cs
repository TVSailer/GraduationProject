using System.Windows.Forms;
using UserInterface.LayoutPanel;

namespace UserInterface.View;

public abstract class Forma : Form
{
    public Forma()
    {
        StartPosition = FormStartPosition.CenterScreen;
        Controls.Add(ControlUi(new BuilderLayoutPanel()).Build());
    }

    public abstract IBuilder ControlUi(BuilderLayoutPanel builderLayoutPanel);
}