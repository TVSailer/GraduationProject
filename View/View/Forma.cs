using System.Windows.Forms;
using UserInterface.LayoutPanel;

namespace UserInterface.View;

public abstract class Forma : Form
{
    public Forma()
    {
        StartPosition = FormStartPosition.CenterScreen;
        Initialize();
        Controls.Add(ControlUi(new BuilderLayoutPanel()).Build());
    }

    public abstract void Initialize();
    public abstract IBuilder ControlUi(BuilderLayoutPanel builderLayoutPanel);
}