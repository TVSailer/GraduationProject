using System.Drawing;
using System.Windows.Forms;
using Extension_Func_Library;

namespace UserInterface.LayoutPanel.ControlBuilder;

public class TextBoxBuilder<TParentBuilder>(TParentBuilder parentBuilder) : IControlBuilder<TextBox, TParentBuilder>
{
    private readonly TextBox _textBox = new()
    {
        Text = "",
        Dock = DockStyle.Fill,
        Font = new Font("Times New Roman", 11, FontStyle.Bold),
        BorderStyle = BorderStyle.FixedSingle,
    };

    public TextBoxBuilder<TParentBuilder> Placeholder(string placeholder)
    {
        _textBox.Text = placeholder;
        return this;
    }

    public TextBoxBuilder<TParentBuilder> Multiline(bool multiline = true)
    {
        _textBox.Multiline = multiline;
        return this;
    }

    public TextBoxBuilder<TParentBuilder> ReadOnly(bool readOnly = true)
    {
        _textBox.ReadOnly = readOnly;
        return this;
    }

    public TextBoxBuilder<TParentBuilder> Binding(object dataSource, string dataMember)
    {
        _textBox.Binding(nameof(TextBox.Text), dataSource, dataMember);
        return this;
    }


    public TextBox Build() => _textBox;

    public TParentBuilder End()
    {
        return parentBuilder;
    }
}