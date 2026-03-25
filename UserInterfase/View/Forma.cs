using System.Windows.Forms;
using UserInterface.LayoutPanel;
using UserInterface.View.Base;

namespace UserInterface.View;

public abstract class Forma : Form, IForma
{
    public Forma()
    {
        StartPosition = FormStartPosition.CenterScreen;
        Initialize();
        Controls.Add(ControlUi(new BuilderLayoutPanel()).Build());
    }

    public void ShowDialog() => ShowDialog();

    public abstract void Initialize();
    public abstract IBuilder ControlUi(BuilderLayoutPanel builderLayoutPanel);
}