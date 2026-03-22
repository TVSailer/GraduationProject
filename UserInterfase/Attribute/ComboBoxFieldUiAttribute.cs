using System.Runtime.CompilerServices;
using System.Windows.Forms;
using UserInterface.UiLayoutPanel;

namespace UserInterface.Attribute;

public class ComboBoxFieldUiAttribute(string labelText, string nameFieldData, [CallerMemberName] string prop = "")
    : FieldInfoUiAttribute(labelText, prop, nameof(ComboBox.SelectedItem), nameFieldData, FactoryElements.ComboBox);