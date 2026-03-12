using System.Drawing;
using System.Windows.Forms;
using Extension_Func_Library;

namespace UserInterface.LayoutPanel.ControlBuilder;

public class MaskedTextBoxBuilder<TParentBuilder> : ControlBuilder<MaskedTextBox, TParentBuilder>
{
    public MaskedTextBoxBuilder<TParentBuilder> Mask(string mask)
    {
        Control.Mask = mask;
        return this;
    }

    public MaskedTextBoxBuilder<TParentBuilder> Binding(object dataSource, string dataMember)
    {
        Control
            .Binding(nameof(MaskedTextBox.Text), dataSource, dataMember)
            .ErrorProvider(dataSource, dataMember);
        return this;
    }


    protected override MaskedTextBox SettingControl()
    {
        return new()
        {
            Dock = DockStyle.Fill,
            Font = new Font("Times New Roman", 11, FontStyle.Bold),
            Padding = new Padding(5),
        };
    }
}