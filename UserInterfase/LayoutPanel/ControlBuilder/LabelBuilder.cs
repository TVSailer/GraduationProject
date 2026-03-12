using System.Drawing;
using System.Windows.Forms;

namespace UserInterface.LayoutPanel.ControlBuilder;

public class LabelBuilder<TParentBuilder> : ControlBuilder<Label, TParentBuilder>
{
    public LabelBuilder<TParentBuilder> Text(string text)
    {
        Control.Text = text;
        return this;
    }
    public LabelBuilder<TParentBuilder> Size(int size)
    {
        Control.Font = new Font("Times New Roman", size, FontStyle.Bold);
        return this;
    }
    
    public LabelBuilder<TParentBuilder> Alignment(ContentAlignment contentAlignment)
    {
        Control.TextAlign = contentAlignment;
        return this;
    }
    public LabelBuilder<TParentBuilder> ForeColor(Color color)
    {
        Control.ForeColor = color;
        return this;
    }

    protected override Label SettingControl()
    {
        return new Label
        {
            Font = new Font("Times New Roman", 11, FontStyle.Bold),
            AutoSize = true,
            TextAlign = ContentAlignment.TopLeft,
            BorderStyle = BorderStyle.None,
            Padding = new Padding(2),
            Dock = DockStyle.Fill
        }; ;
    }
}