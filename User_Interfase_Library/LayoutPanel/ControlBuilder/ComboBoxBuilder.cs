using System.Drawing;
using System.Windows.Forms;
using Extension_Func_Library;

namespace UserInterface.LayoutPanel.ControlBuilder;

public class ComboBoxBuilder<TParentBuilder>(TParentBuilder parentBuilder) : IControlBuilder<ComboBox, TParentBuilder>
{
    private readonly ComboBox _textBox = new()
    {
        DropDownStyle = ComboBoxStyle.DropDownList,
        Text = "",
        Dock = DockStyle.Fill,
        Font = new Font("Times New Roman", 11, FontStyle.Bold),
    };

    public ComboBoxBuilder<TParentBuilder> WriteValue()
    {
        _textBox.SelectedIndexChanged += (_, _) => _textBox.DataBindings["SelectedItem"]?.WriteValue();
        return this;
    }

    public ComboBoxBuilder<TParentBuilder> Binding(object dataSource, string dataMember)
    {
        _textBox
            .Binding(nameof(ComboBox.SelectedItem), dataSource, dataMember)
            .ErrorProvider(dataSource, dataMember);
        return this;
    }
        
    public ComboBoxBuilder<TParentBuilder> SetData(object dataSource)
    {
        _textBox.DataSource = dataSource;
        return this;
    }

    public ComboBox Build() => _textBox;

    public TParentBuilder End()
    {
        return parentBuilder;
    }
}