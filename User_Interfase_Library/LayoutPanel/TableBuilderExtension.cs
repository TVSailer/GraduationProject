using System.Windows.Forms;
using Extension_Func_Library;
using User_Interface_Library.LayoutPanel;

namespace User_Interface_Library.LayerPanel;


public static class TableBuilderExtension
{
    public static IRowBuilder RowAutoSize(this IColumnBuilder columnBuilder) => columnBuilder.Row(0, SizeType.AutoSize);
    public static IColumnBuilder ColumnAutoSize(this IRowBuilder rowBuilder) => rowBuilder.Column(0, SizeType.AutoSize);

    //public static IColumnBuilder ContentLabelTextBox(this IRowBuilder rowBuilder, string label, string placeholder, object context,
    //    string nameMember, bool multiline = false, bool readOnly = false)
    //    => rowBuilder
    //        .Column().ContentEnd(FactoryElements.Label_12(label))
    //        .Column().ContentEnd(FactoryElements.TextBox(placeholder)
    //            .Binding(nameof(TextBox.Text), context, nameMember))
    //        .End();
    
    public static IColumnBuilder ContentLabelNumeric(string label, object context, string nameMember)
        => LayoutPanel.CreateRow()
            .Column().ContentEnd(FactoryElements.Label_12(label))
            .Column().ContentEnd(FactoryElements.NumericUpDown()
                .Binding(nameof(TextBox.Text), context, nameMember)).End();

    public static IColumnBuilder ContentLabelComboBox(string label, object context, string nameMember, object data)
        => LayoutPanel.CreateRow()
            .Column().ContentEnd(FactoryElements.Label_12(label))
            .Column().ContentEnd(FactoryElements.ComboBox(data)
                .Binding(nameof(ComboBox.SelectedItem), context, nameMember)).End();
}

