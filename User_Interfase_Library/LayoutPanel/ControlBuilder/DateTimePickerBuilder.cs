using System.Drawing;
using System.Windows.Forms;
using Extension_Func_Library;

namespace UserInterface.LayoutPanel.ControlBuilder;

public class DateTimePickerBuilder<TParentBuilder>(TParentBuilder parentBuilder) : IControlBuilder<DateTimePicker, TParentBuilder>
{
    private readonly DateTimePicker _textBox = new()
    {
        Dock = DockStyle.Fill,
        Font = new Font("Times New Roman", 11, FontStyle.Bold),
        Padding = new Padding(5),
        Format = DateTimePickerFormat.Custom,
        ShowUpDown = true
    };

    public DateTimePickerBuilder<TParentBuilder> Binding(object dataSource, string dataMember)
    {
        _textBox.Binding(nameof(DateTimePicker.Text), dataSource, dataMember);
        return this;
    }
        
    public DateTimePickerBuilder<TParentBuilder> Format(string format)
    {
        _textBox.CustomFormat = format;
        return this;
    }

    public DateTimePicker Build() => _textBox;

    public TParentBuilder End()
    {
        return parentBuilder;
    }
}