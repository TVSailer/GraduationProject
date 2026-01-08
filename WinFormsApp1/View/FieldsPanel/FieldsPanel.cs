using Logica;

public class FieldsPanel : IFieldsPanel
{
    private readonly List<LessonFieldView> fields;

    public FieldsPanel(List<LessonFieldView> fields)
    {
        this.fields = fields;
    }

    public Control? CreateFieldsPanel()
        => FactoryElements.TableLayoutPanel()
        .With(t => fields.ForEach(a => t.ControlAddIsRowsAbsoluteV2(a.Func.Invoke(a.LabelText, a.PlaceholderText, a.Attributer), a.Heinght)))
        .ControlAddIsRowsPercentV2();
}

public class LessonFieldView
{
    public string LabelText { get; private set; }
    public string PlaceholderText { get; private set; }
    public string Attributer { get; private set; }
    public int Heinght { get; private set; }
    public Func<string, string, string, TableLayoutPanel> Func { get; private set; }

    public LessonFieldView(string labelText, string placeholderText, string attribute, Func<string, string, string, TableLayoutPanel> func, int heinght)
    {
        LabelText = labelText;
        PlaceholderText = placeholderText;
        Attributer = attribute;
        Func = func;
        Heinght = heinght;
    }
}
