using System.Windows.Forms;
using UserInterface.LayoutPanel;
using UserInterface.View.Base;

namespace UserInterface.View;

public abstract class Forma<T> : Form, IForma<T>
{
    protected Forma()
    {
        FormClosed += (s, e) => Close();
        StartPosition = FormStartPosition.CenterScreen;
        Initialize();
        Controls.Add(ControlUi(new BuilderLayoutPanel()).Build());
    }

    public void Show() => ShowDialog();
    public abstract void Initialize();
    public abstract IBuilder ControlUi(BuilderLayoutPanel builderLayoutPanel);
}