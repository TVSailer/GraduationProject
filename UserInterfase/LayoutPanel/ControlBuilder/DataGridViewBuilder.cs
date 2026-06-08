using System.Collections.Generic;
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
        int index = Control.Columns.Add(name.GetHashCode().ToString(), name);
        Control.Columns[index].SortMode = DataGridViewColumnSortMode.NotSortable;

        return this;
    }

    public DataGridViewBuilder<TParentBuilder> SetColumn(IEnumerable<string> names)
    {
        foreach (var name in names)
            SetColumn(name);

        Control.SelectionMode = DataGridViewSelectionMode.ColumnHeaderSelect;
        return this;
    }

    public DataGridViewBuilder<TParentBuilder> SetColumn(string[] names)
    {
        return SetColumn((IEnumerable<string>)names);
    }

    protected override DataGridView SettingControl()
    {
        return new DataGridView
        {
            AutoSize = true,
            MultiSelect = false,
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells,
            AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders,
            AllowUserToAddRows = false,
            ScrollBars = ScrollBars.Both,
            Font = new Font("Times New Roman", 14, FontStyle.Bold),
            Margin = new Padding(5),
        };
    }
}
