using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace User_Interface_Library.Attribute;

public class ComboBoxFieldUiAttribute(string labelText, string nameFieldData, [CallerMemberName] string prop = "")
    : FieldInfoUiAttribute(labelText, prop, nameof(ComboBox.SelectedItem), nameFieldData, FactoryElements.ComboBox);