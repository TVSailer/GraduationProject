using System.Drawing;
using System.Windows.Forms;
using ExtensionFunc;
using UserInterface.LayoutPanel.ContentSelection;

namespace UserInterface.LayoutPanel.ControlBuilder;

public class TextBoxBuilder<TParentBuilder> : ControlBuilder<TextBox, TParentBuilder>
{

    public TextBoxBuilder<TParentBuilder> Placeholder(string placeholder = "")
    {
        Control.PlaceholderText = placeholder;
        return this;
    }

    public TextBoxBuilder<TParentBuilder> Text(string text)
    {
        Control.Text = text;
        return this;
    }
    
    public TextBoxBuilder<TParentBuilder> Size(int size)
    {
        Control.Font = new Font("Times New Roman", size, FontStyle.Bold);
        return this;
    }

    public TextBoxBuilder<TParentBuilder> Multiline(bool multiline = true)
    {
        Control.Multiline = multiline;
        return this;
    }

    public TextBoxBuilder<TParentBuilder> ReadOnly(bool readOnly = true)
    {
        Control.ReadOnly = readOnly;
        return this;
    }

    public TextBoxBuilder<TParentBuilder> Binding(object dataSource, string dataMember)
    {
        Control
            .Binding(nameof(TextBox.Text), dataSource, dataMember);
        ErrorProvider(dataSource, dataMember);

        return this;
    }

    public TextBoxBuilder<TParentBuilder> UseSystemPasswordChar()
    {
        Control.UseSystemPasswordChar = true;
        return this;
    }

    protected override TextBox SettingControl()
    {
        return new TextBox
        {
            Dock = DockStyle.Fill,
            Font = new Font("Times New Roman", 11, FontStyle.Bold),
            BorderStyle = BorderStyle.FixedSingle,
        };
    }
}