using System.Drawing;
using System.Windows.Forms;
using System.Windows.Input;
using UserInterface.Command;
using UserInterface.LayoutPanel.ContentSelection;
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
    
    public ButtonBuilder<TParentBuilder> NoEnable(bool enable = false)
    {
        Control.Enabled = enable;
        return this;
    }

    public ButtonBuilder<TParentBuilder> Command(ICommand info)
    {
        var en = info.CanExecute(null);
        Control.Enabled = en;

        if (en) Control.Click += (s, e) => info.Execute(null);

        return this;
    }

    protected override Button SettingControl()
    {
        return new Button
        {
            AutoSize = true,
            Dock = DockStyle.Fill,
            Font = new Font("Times New Roman", 11, FontStyle.Bold),
            Margin = new Padding(5),
        };
    }
}