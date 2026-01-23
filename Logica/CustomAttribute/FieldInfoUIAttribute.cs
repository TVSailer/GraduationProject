using Logica.Extension;
using System.Collections;
using System.Runtime.CompilerServices;

namespace Admin.ViewModels.Lesson
{
    public class FieldInfoUiAttribute : Attribute
    {
        public string LabelText { get; protected set; }
        public int Size { get; protected set; } = 54;
        public string PropertyName { get; protected set; }
        public string? FieldDataName { get; protected set; }
        public string PropertyNameControl { get; protected set; }
        public Control? Control { get; protected set; }

        private readonly Func<object?, Control>? creatingControl;

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

            this.creatingControl = creatingControl;
        }
        
        public FieldInfoUiAttribute(string text, string prop, Control control, int size = 54)
        {
            LabelText = text;
            PropertyName = prop;
            PropertyNameControl = "Text";
            Control = control;
        }

        public Control GetContol(object data)
        {
            if (Control != null) return Control.Binding(PropertyNameControl, data, PropertyName);

            var type = data.GetType();
            var field = type.GetField(FieldDataName) ?? throw new ArgumentException();
            var value = field.GetValue(data);

            return creatingControl
                .Invoke(value)
                .Binding(PropertyNameControl, data, PropertyName);
        }
    }

    public class MultilineFieldUiAttribute([CallerMemberName] string prop = "") : FieldInfoUiAttribute("Описание:*",
        prop, FactoryElements.TextBoxMultiline("Введите описание"), 200);
    
    public class BaseFieldUiAttribute(string labelText, string placeholder = "", [CallerMemberName] string prop = "")
        : FieldInfoUiAttribute(labelText, prop, FactoryElements.TextBox(placeholder));
    
    public class ComboBoxFieldUiAttribute(string labelText, string nameFieldData, [CallerMemberName] string prop = "")
        : FieldInfoUiAttribute(labelText, prop, nameof(ComboBox.SelectedItem), nameFieldData, obj =>
        {
            if (obj is not ICollection array) throw new ArgumentException();
            var cb = FactoryElements.ComboBox();
            array.ForEach(a => cb.Items.Add(a));
            return cb;

        });
    
    public class NumericFieldUiAttribute(string labelText, [CallerMemberName] string prop = "")
        : FieldInfoUiAttribute(labelText, prop, FactoryElements.NumericUpDown());
    
    public class ReadOnlyFieldUiAttribute(
        string labelText,
        string placeholder = "",
        [CallerMemberName] string prop = "")
        : FieldInfoUiAttribute(labelText, prop, FactoryElements.TextBoxReadOnle(placeholder));
    
    public class DateFieldUiAttribute(CustomFormatDatePicker format, [CallerMemberName] string prop = "")
        : FieldInfoUiAttribute("Дата:*", prop, FactoryElements.DateTimePicker(format));
}