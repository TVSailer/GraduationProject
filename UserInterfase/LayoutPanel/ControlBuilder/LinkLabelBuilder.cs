using System.Drawing;
using System.Windows.Forms;

namespace UserInterface.LayoutPanel.ControlBuilder;

public class LinkLabelBuilder<TParentBuilder> : ControlBuilder<LinkLabel, TParentBuilder>
{
    public LinkLabelBuilder<TParentBuilder> Text(string text)
    {
        Control.Text = text;
        return this;
    }
    public LinkLabelBuilder<TParentBuilder> Size(int size)
    {
        Control.Font = new Font("Times New Roman", size, FontStyle.Bold);
        return this;
    }
    
    public LinkLabelBuilder<TParentBuilder> Alignment(ContentAlignment contentAlignment)
    {
        Control.TextAlign = contentAlignment;
        return this;
    }
    public LinkLabelBuilder<TParentBuilder> Color(Color color)
    {
        Control.LinkColor = color;
        return this;
    }

    public LinkLabelBuilder<TParentBuilder> Click(Action click)
    {
        Control.LinkClicked += (s, e) => click.Invoke();
        return this;
    }

    protected override LinkLabel SettingControl()
    {
        return new LinkLabel
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