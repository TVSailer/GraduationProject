using System.Windows.Forms;
using UserInterface.LayoutPanel.ControlBuilder;

namespace UserInterface.LayoutPanel.Extension;

public static class LayoutPanelExtension
{
    private static object? _binding;

    public static BuilderLayoutPanel ObjectBinding(this BuilderLayoutPanel columnBuilder, object binding)
    {
        _binding = binding;
        return columnBuilder;
    }
    
    public static IColumnBuilder LabelTextBox(this IRowBuilder rowBuilder, string labelText, string placeholder, string nameMember)
    {
        return rowBuilder
            .Column(10).Content().Label(labelText).End()
            .Column(40).Content().TextBox(placeholder).Binding(_binding ?? throw new NullReferenceException(), nameMember).End()
            .Column(30, SizeType.Absolute).End()
            .End();
    }
    
    public static IColumnBuilder LabelMaskTextBox(this IRowBuilder rowBuilder, string labelText, string mask, string nameMember)
    {
        return rowBuilder
            .Column(10).Content().Label(labelText).End()
            .Column(40).Content().MaskedTextBox(mask).Binding(_binding ?? throw new NullReferenceException(), nameMember).End()
            .Column(30, SizeType.Absolute).End()
            .End();
    }
    
    public static IColumnBuilder LabelTextBoxMultiline(this IRowBuilder rowBuilder, string labelText, string placeholder, string nameMember)
    {
        return rowBuilder
            .Column(10).Content().Label(labelText).End()
            .Column(40).Content().TextBox(placeholder).Binding(_binding ?? throw new NullReferenceException(), nameMember).Multiline().End()
            .Column(30, SizeType.Absolute).End()
            .End();
    }
    
    public static IColumnBuilder LabelTextBoxReadOnly(this IRowBuilder rowBuilder, string labelText, string placeholder, string nameMember)
    {
        return rowBuilder
            .Column(10).Content().Label(labelText).End()
            .Column(40).Content().TextBox(placeholder).Binding(_binding ?? throw new NullReferenceException(), nameMember).ReadOnly().End()
            .Column(30, SizeType.Absolute).End()
            .End();
    }
    
    public static IColumnBuilder LabelTextBoxReadOnlyMultiline(this IRowBuilder rowBuilder, string labelText, string placeholder, string nameMember)
    {
        return rowBuilder
            .Column(10).Content().Label(labelText).End()
            .Column(40).Content().TextBox(placeholder)
                .Binding(_binding ?? throw new NullReferenceException(), nameMember)
                .ReadOnly()
                .Multiline().End()
            .Column(30, SizeType.Absolute).End()
            .End();
    }
    
    public static IColumnBuilder LabelDatePicker(this IRowBuilder rowBuilder, string labelText, string format, string nameMember)
    {
        return rowBuilder
            .Column(10).Content().Label(labelText).End()
            .Column(40).Content().DateTimePicker(format).Binding(_binding ?? throw new NullReferenceException(), nameMember).End()
            .Column(30, SizeType.Absolute).End()
            .End();
    }
    
    public static IColumnBuilder LabelNumeric(this IRowBuilder rowBuilder, string labelText, string nameMember)
    {
        return rowBuilder
            .Column(10).Content().Label(labelText).End()
            .Column(40).Content().Numeric().Binding(_binding ?? throw new NullReferenceException(), nameMember).End()
            .Column(30, SizeType.Absolute).End()
            .End();
    }
    
    public static IColumnBuilder LabelComboBox(this IRowBuilder rowBuilder, string labelText, string nameMember, object dataSource)
    {
        return rowBuilder
            .Column(10).Content().Label(labelText).End()
            .Column(40).Content().ComboBox().SetData(dataSource).Binding(_binding ?? throw new NullReferenceException(), nameMember).End()
            .Column(30, SizeType.Absolute).End()
            .End();
    }
}