using System.Drawing;
using System.Windows.Forms;
using Extension_Func_Library;

namespace UserInterface.LayoutPanel.ControlBuilder;

public class ComboBoxBuilder<TParentBuilder> : ControlBuilder<ComboBox, TParentBuilder>
{
    public ComboBoxBuilder<TParentBuilder> WriteValue()
    {
        Control.SelectedIndexChanged += (_, _) => Control.DataBindings["SelectedItem"]?.WriteValue();
        return this;
    }

    public ComboBoxBuilder<TParentBuilder> Binding(object dataSource, string dataMember)
    {
        Control
            .Binding(nameof(ComboBox.SelectedItem), dataSource, dataMember)
            .ErrorProvider(dataSource, dataMember);
        return this;
    }
        
    public ComboBoxBuilder<TParentBuilder> SetData(object dataSource)
    {
        Control.DataSource = dataSource;
        return this;
    }

    protected override ComboBox SettingControl()
    {
        return new()
        {
            DropDownStyle = ComboBoxStyle.DropDownList,
            Text = "",
            Dock = DockStyle.Fill,
            Font = new Font("Times New Roman", 11, FontStyle.Bold),
        };
    }
}