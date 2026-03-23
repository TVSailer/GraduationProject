using System.Drawing;
using System.Windows.Forms;
using ExtensionFunc;
using UserInterface.LayoutPanel.ContentSelection;

namespace UserInterface.LayoutPanel.ControlBuilder;

public class DateTimePickerBuilder<TParentBuilder> : ControlBuilder<DateTimePicker, TParentBuilder>
{
    public DateTimePickerBuilder<TParentBuilder> Binding(object dataSource, string dataMember)
    {
        Control.Binding(nameof(DateTimePicker.Text), dataSource, dataMember);
        MessageErrorProvider(dataSource, dataMember);
        return this;
    }
    
    public DateTimePickerBuilder<TParentBuilder> MessageError(object dataSource, string dataMember)
    {
        MessageErrorProvider(dataSource, dataMember);
        return this;
    }
        
    public DateTimePickerBuilder<TParentBuilder> Format(string format)
    {
        Control.CustomFormat = format;
        return this;
    }
    public DateTimePickerBuilder<TParentBuilder> Enabled(bool enabled)
    {
        Control.Enabled = enabled;
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