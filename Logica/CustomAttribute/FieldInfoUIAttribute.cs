
using DataAccess.Postgres.Models;
using Logica.Extension;
using System.Collections;
using System.Runtime.CompilerServices;

namespace Admin.ViewModels.Lesson
{
    public class FieldInfoUIAttribute : Attribute
    {
        public string LabelText { get; protected set; }
        public int Size { get; protected set; } = 54;
        public string PropertyName { get; protected set; }
        public string FieldDataName { get; protected set; }
        public string PropertyNameContol { get; protected set; }
        public Control Control { get; protected set; }

        private Func<object?, Control> creatingControl;

        public FieldInfoUIAttribute(
            string text, 
            string prop, 
            string propertyNameControl, 
            string nameFieldData, 
            Func<object?, Control> creatingControl, int size = 54)
        {
            LabelText = text;
            PropertyName = prop;
            FieldDataName = nameFieldData;
            PropertyNameContol = propertyNameControl;

            this.creatingControl = creatingControl;
        }
        
        public FieldInfoUIAttribute(string text, string prop, Control control, int size = 54)
        {
            LabelText = text;
            PropertyName = prop;
            PropertyNameContol = "Text";
            Control = control;
        }

        public Control GetContol(object data)
        {
            if (Control != null) return Control.Binding(PropertyNameContol, data, PropertyName);

            var type = data.GetType();
            var field = type.GetField(FieldDataName) ?? throw new ArgumentException();
            var value = field.GetValue(data);

            return creatingControl
                .Invoke(value)
                .Binding(PropertyNameContol, data, PropertyName);
        }
    }

    public class MultilineFieldUIAttribute : FieldInfoUIAttribute
    {
        public MultilineFieldUIAttribute([CallerMemberName] string prop = "") : base(
            "Описание:*", prop, FactoryElements.TextBoxMultiline("Введите описание"), 200)
        {
        }
    }
    
    public class BaseFieldUIAttribute : FieldInfoUIAttribute
    {
        public BaseFieldUIAttribute(string labelText, string placeholder = "", [CallerMemberName] string prop = "") : base(
            labelText, prop, FactoryElements.TextBox(placeholder))
        {
        }
    }
    
    public class ComboBoxFieldUIAttribute : FieldInfoUIAttribute
    {
        public ComboBoxFieldUIAttribute(string labelText, string nameFieldData, [CallerMemberName] string prop = "") : base(
            labelText, prop, nameof(ComboBox.SelectedItem), nameFieldData, obj =>
            {
                if (obj is ICollection array)
                {
                    var cb = FactoryElements.ComboBox();
                    array.ForEach(a => cb.Items.Add(a));
                    return cb;
                }

                throw new ArgumentException();
            })
            { }
    }
    
    public class NumericFieldUIAttribute : FieldInfoUIAttribute
    {
        public NumericFieldUIAttribute(string labelText, [CallerMemberName] string prop = "") : base(
            labelText, prop, FactoryElements.NumericUpDown())
        {
        }
    }
    
    public class ReadOnlyFieldUIAttribute : FieldInfoUIAttribute
    {
        public ReadOnlyFieldUIAttribute(string labelText, string placeholder = "", [CallerMemberName] string prop = "") : base(
            labelText, prop, FactoryElements.TextBoxReadOnle(placeholder))
        {
        }
    }
    
    public class DateFieldUIAttribute : FieldInfoUIAttribute
    {
        public DateFieldUIAttribute(CustomFormatDatePicker format, [CallerMemberName] string prop = "") : base(
            "Дата:*", prop, FactoryElements.DateTimePicker(format))
        {
        }
    }
}