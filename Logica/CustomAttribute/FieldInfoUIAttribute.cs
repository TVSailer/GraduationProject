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
                    .OnErrorProvider(PropertyName, data)
                    .Binding(PropertyNameControl, data, PropertyName);
            }

            var type = data.GetType();
            var field = type.GetProperty(FieldDataName!) ?? throw new ArgumentException();
            var value = field.GetValue(data);

            Control = creatingControl!
                .Invoke(value)
                .Binding(PropertyNameControl, data, PropertyName)
                .OnErrorProvider(PropertyName, data);

            isBinding = true;

            return Control;
        }
    }

    public class MultilineFieldUiAttribute([CallerMemberName] string prop = "") : FieldInfoUiAttribute("Описание:*",
        prop, FactoryElements.TextBox("Введите описание", true, false), 100);
    
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
        : FieldInfoUiAttribute(labelText, prop, FactoryElements.TextBox(placeholder, false, true));
    
    public class ReadOnlyMultilineFieldUiAttribute(
        string labelText,
        string placeholder = "",
        [CallerMemberName] string prop = "")
        : FieldInfoUiAttribute(labelText, prop, FactoryElements.TextBox(placeholder, true, true), 170);
    
    public class DateFieldUiAttribute(string labelText, CustomFormatDatePicker format, [CallerMemberName] string prop = "")
        : FieldInfoUiAttribute(labelText, prop, FactoryElements.DateTimePicker(format)); 
    
    public class MaskedTextBoxFieldUiAttribute(string labelText, string mask, [CallerMemberName] string prop = "")
        : FieldInfoUiAttribute(labelText, prop, FactoryElements.MaskedTextBox(mask));
}