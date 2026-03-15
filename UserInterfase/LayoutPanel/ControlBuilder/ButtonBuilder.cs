using System;
using System.Drawing;
using System.Windows.Forms;
using UserInterface.Info;
using Font = System.Drawing.Font;

namespace UserInterface.LayoutPanel.ControlBuilder;

public class ButtonBuilder<TParentBuilder> : ControlBuilder<Button, TParentBuilder>
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
    
    public ButtonBuilder<TParentBuilder> Enable(bool enable = true)
    {
        Control.Enabled = enable;
        return this;
    }
    
    public ButtonBuilder<TParentBuilder> InfoButton(InfoButton info)
    {
        return this
            .Text(info.Text)
            .Click(info.OnClick)
            .Enable(info.Enabled);
    }

    public ButtonBuilder<TParentBuilder> Click(Action action)
    {
        Control.Click += (_, _) => action();
        return this;
    }

    protected override Button SettingControl()
    {
        return new Button
        {
            AutoSize = true,
            Dock = DockStyle.Fill,
            Font = new Font("Times New Roman", 11, FontStyle.Bold)
        };
    }
}