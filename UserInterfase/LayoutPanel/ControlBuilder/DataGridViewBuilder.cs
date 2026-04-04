using System.Drawing;
using System.Windows.Forms;
using UserInterface.LayoutPanel.ContentSelection;

namespace UserInterface.LayoutPanel.ControlBuilder;

public class DataGridViewBuilder<TParentBuilder> : ControlBuilder<DataGridView, TParentBuilder>
{
    public DataGridViewBuilder<TParentBuilder> SetRow(IEnumerable<object[]> data)
    {
        foreach (var obj in data) Control.Rows.Add(obj);
        return this;
    }

    public DataGridViewBuilder<TParentBuilder> SetColumn(string name)
    {
        Control.Columns.Add(name.GetHashCode().ToString(), name);

        return this;
    }
    
    public DataGridViewBuilder<TParentBuilder> SetColumn(IEnumerable<string> names)
    {
        foreach (var name in names)
            Control.Columns.Add(name.GetHashCode().ToString(), name);
        
        return this;
    }
    
    public DataGridViewBuilder<TParentBuilder> SetColumn(string[] names)
    {
        foreach (var name in names)
            Control.Columns.Add(name.GetHashCode().ToString(), name);
        
        return this;
    }

    protected override DataGridView SettingControl()
    {
        return new DataGridView
        {
            AutoSize = true,
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells,
            AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders,
            SelectionMode = DataGridViewSelectionMode.FullRowSelect,
            AllowUserToAddRows = false,
            ScrollBars = ScrollBars.Both,
            Font = new Font("Times New Roman", 11, FontStyle.Bold),
            Margin = new Padding(5),
        };
    }
}