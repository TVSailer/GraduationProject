using System.Drawing;
using System.Windows.Forms;
using Extension_Func_Library;

namespace UserInterface.LayoutPanel.ControlBuilder;

public class NumericBuilder<TParentBuilder> : ControlBuilder<NumericUpDown, TParentBuilder>
{
    public NumericBuilder<TParentBuilder> Binding(object dataSource, string dataMember)
    {
        Control
            .Binding(nameof(TextBox.Text), dataSource, dataMember)
            .ErrorProvider(dataSource, dataMember);
        return this;
    }

    protected override NumericUpDown SettingControl()
    {
        return new()
        {
            Text = "",
            Minimum = 1,
            Maximum = 1000,
            Value = 50,
            Dock = DockStyle.Fill,
            Font = new Font("Times New Roman", 11, FontStyle.Bold),
            BorderStyle = BorderStyle.FixedSingle,
        };
    }
}