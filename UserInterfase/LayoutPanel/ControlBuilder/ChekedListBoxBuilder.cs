using System.Drawing;
using System.Windows.Forms;
using System.Windows.Input;
using UserInterface.LayoutPanel.ContentSelection;

namespace UserInterface.LayoutPanel.ControlBuilder;

public class ChekedListBoxBuilder<TParentBuilder> : ControlBuilder<CheckedListBox, TParentBuilder>
{

    public ChekedListBoxBuilder<TParentBuilder> CommandCheckedItem(ICommand command)
    {
        Control.ItemCheck += (s, e) =>
        {
            var item = Control.Items[e.Index];
            if (command.CanExecute(item))
                command.Execute(item);
        };

        return this;
    }
    
    public ChekedListBoxBuilder<TParentBuilder> SetData(object[] items)
    {
        Control.Items.AddRange(items);
        return this;
    }
    
    public ChekedListBoxBuilder<TParentBuilder> SetData<T>(Dictionary<T, bool> items) where T : notnull
    {
        foreach (var item in items)
            Control.Items.Add(item.Key, item.Value);
        
        return this;
    }

    protected override CheckedListBox SettingControl()
    {
        return new CheckedListBox()
        {
            AutoSize = true,
            Dock = DockStyle.Fill,
            Font = new Font("Times New Roman", 11, FontStyle.Bold),
            Margin = new Padding(5),
            CheckOnClick = true
        };
    }
}