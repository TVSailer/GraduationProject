using System.Drawing;
using System.Windows.Forms;
using Extension_Func_Library;

namespace UserInterface.LayoutPanel.ControlBuilder;

public class NumericBuilder<TParentBuilder>(TParentBuilder parentBuilder) : IControlBuilder<NumericUpDown, TParentBuilder>
{
    private readonly NumericUpDown _textBox = new()
    {
        Text = "",
        Minimum = 1,
        Maximum = 1000,
        Value = 50,
        Dock = DockStyle.Fill,
        Font = new Font("Times New Roman", 11, FontStyle.Bold),
        BorderStyle = BorderStyle.FixedSingle,
    };

    public NumericBuilder<TParentBuilder> Binding(object dataSource, string dataMember)
    {
        _textBox
            .Binding(nameof(TextBox.Text), dataSource, dataMember)
            .ErrorProvider(dataSource, dataMember);
        return this;
    }

    public NumericUpDown Build() => _textBox;

    public TParentBuilder End()
    {
        return parentBuilder;
    }
}