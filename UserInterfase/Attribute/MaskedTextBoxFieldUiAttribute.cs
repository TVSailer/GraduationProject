using System.Runtime.CompilerServices;

namespace UserInterface.Attribute;

public class MaskedTextBoxFieldUiAttribute(string labelText, string mask, [CallerMemberName] string prop = "")
    : FieldInfoUiAttribute(labelText, prop, FactoryElements.MaskedTextBox(mask));