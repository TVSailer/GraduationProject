using System.Windows.Forms;
using ExtensionFunc;

namespace UserInterface.Attribute;

public class FieldInfoUiAttribute : System.Attribute
{
    public string LabelText { get; protected set; }
    public int Size { get; protected set; } = 54;
    public string PropertyName { get; protected set; }
    public string? FieldDataName { get; protected set; }
    public string PropertyNameControl { get; protected set; }
    private Control? Control { get; set; }
    private readonly Func<object?, Control>? creatingControl;
    private bool isBinding;

    public FieldInfoUiAttribute(
        string text,
        string prop, 
        string propertyNameControl, 
        string nameFieldData, 
        Func<object?, Control> creatingControl, int size = 54)
    {
        LabelText = text;
        PropertyName = prop;
        FieldDataName = nameFieldData;
        PropertyNameControl = propertyNameControl;
        Size = size;
        this.creatingControl = creatingControl;
    }
        
    public FieldInfoUiAttribute(string text, string prop, Control control, int size = 54)
    {
        LabelText = text;
        PropertyName = prop;
        PropertyNameControl = "Text";
        Size = size;
        Control = control;
    }

    public Control GetControl(object data)
    {
        if (isBinding) return Control!;

        if (Control != null)
        {
            isBinding = true;
            return Control
                .Binding(PropertyNameControl, data, PropertyName);
        }

        var type = data.GetType();
        var field = type.GetProperty(FieldDataName!) ?? throw new ArgumentException();
        var value = field.GetValue(data);


        Control = creatingControl!
            .Invoke(value)
            .Binding(PropertyNameControl, data, PropertyName);
                
        isBinding = true;

        return Control;
    }
}