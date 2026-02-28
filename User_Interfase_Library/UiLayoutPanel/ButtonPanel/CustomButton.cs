using System.Drawing;
using System.Windows.Forms;
using Extension_Func_Library;

namespace UserInterface.UiLayoutPanel.ButtonPanel;

public sealed class CustomButton : Button
{
    public CustomButton(string text = "")
    {
        AutoSize = true;
        Dock = DockStyle.Fill;
        Text = text;
        Font = new Font("Times New Roman", 11, FontStyle.Bold);
    }
    public CustomButton CommandClick(Action action) => this.With(_ => Click += (_, _) => action());
    public CustomButton NoEnabled() => this.With(_ => Enabled = false);
    public CustomButton Enablede(bool enable = true) => this.With(_ => Enabled = enable);
}
