using System.Runtime.CompilerServices;
using UserInterface.UiLayoutPanel;

namespace UserInterface.Attribute;

public class MaskedTextBoxFieldUiAttribute(string labelText, string mask, [CallerMemberName] string prop = "")
    : FieldInfoUiAttribute(labelText, prop, FactoryElements.MaskedTextBox(mask));