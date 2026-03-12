using System.Drawing;
using System.Windows.Forms;
using Extension_Func_Library;

namespace UserInterface.LayoutPanel.ControlBuilder;

public class DateTimePickerBuilder<TParentBuilder> : ControlBuilder<DateTimePicker, TParentBuilder>
{
    public DateTimePickerBuilder<TParentBuilder> Binding(object dataSource, string dataMember)
    {
        Control
            .Binding(nameof(DateTimePicker.Text), dataSource, dataMember)
            .ErrorProvider(dataSource, dataMember);
        return this;
    }
        
    public DateTimePickerBuilder<TParentBuilder> Format(string format)
    {
        Control.CustomFormat = format;
        return this;
    }

    protected override DateTimePicker SettingControl()
    {
        return new()
        {
            Dock = DockStyle.Fill,
            Font = new Font("Times New Roman", 11, FontStyle.Bold),
            Padding = new Padding(5),
            Format = DateTimePickerFormat.Custom,
            ShowUpDown = true
        };
    }
}