using System.Collections;
using ExtensionFunc;
using System.Drawing;
using System.Windows.Forms;
using UserInterface.LayoutPanel.ContentSelection;

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
        Control.Binding(nameof(ComboBox.SelectedItem), dataSource, dataMember);
        if (Control.Items.Count > 0)
            Control.SelectedIndex = 0;
        MessageErrorProvider(dataSource, dataMember);
        return this;
    }
        
    public ComboBoxBuilder<TParentBuilder> SetData(object[]? dataSource)
    {
        Control.Items.Add("");
        Control.Items.AddRange(dataSource ?? []);
        return this;
    }
    
    public ComboBoxBuilder<TParentBuilder> SetData<T>() where T : Enum
    {
        Control.DataSource = Enum.GetValues(typeof(T))
            .Cast<T>()
            .Select(selector: d => new { Description = d.ToDescriptionString(), Value = d })
            .ToList();

        DisplayMember("Description");
        ValueMember("Value");

        return this;
    }
    
    public ComboBoxBuilder<TParentBuilder> DisplayMember(string dataSource)
    {
        Control.DisplayMember = dataSource;
        return this;
    }
    
    public ComboBoxBuilder<TParentBuilder> ValueMember(string dataSource)
    {
        Control.ValueMember = dataSource;
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