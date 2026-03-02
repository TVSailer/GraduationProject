using System.Drawing;
using System.Windows.Forms;
using Extension_Func_Library;

namespace UserInterface.LayoutPanel.ControlBuilder;

public class MaskedTextBoxBuilder<TParentBuilder>(TParentBuilder parentBuilder) : IControlBuilder<MaskedTextBox, TParentBuilder>
{
    private readonly MaskedTextBox _textBox = new()
    {
        Dock = DockStyle.Fill,
        Font = new Font("Times New Roman", 11, FontStyle.Bold),
        Padding = new Padding(5),
    };

    public MaskedTextBoxBuilder<TParentBuilder> Mask(string mask)
    {
        _textBox.Mask = mask;
        return this;
    }

    public MaskedTextBoxBuilder<TParentBuilder> Binding(object dataSource, string dataMember)
    {
        _textBox
            .Binding(nameof(MaskedTextBox.Text), dataSource, dataMember)
            .ErrorProvider(dataSource, dataMember);
        return this;
    }


    public MaskedTextBox Build() => _textBox;

    public TParentBuilder End()
    {
        return parentBuilder;
    }
}