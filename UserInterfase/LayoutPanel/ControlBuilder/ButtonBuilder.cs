using System.Drawing;
using System.Windows.Forms;
using UserInterface.UiLayoutPanel.ButtonPanel;

namespace UserInterface.LayoutPanel.ControlBuilder;

public class ButtonBuilder<TParentBuilder>(TParentBuilder parentBuilder) : ControlBuilder<Button, TParentBuilder>(parentBuilder)
{
    public ButtonBuilder<TParentBuilder> Text(string text)
    {
        Control.Text = text;
        return this;
    }
    public ButtonBuilder<TParentBuilder> Size(int size)
    {
        Control.Font = new Font("Times New Roman", size, FontStyle.Bold);
        return this;
    }
    
    public ButtonBuilder<TParentBuilder> Alignment(ContentAlignment contentAlignment)
    {
        Control.TextAlign = contentAlignment;
        return this;
    }
    public ButtonBuilder<TParentBuilder> ForeColor(Color color)
    {
        Control.ForeColor = color;
        return this;
    }



    public override Button SettingControl()
    {
        return new Button
        {
            AutoSize = true,
            Dock = DockStyle.Fill,
            Font = new Font("Times New Roman", 11, FontStyle.Bold)
        };
    }
}

