using System.Runtime.CompilerServices;

namespace User_Interface_Library.Attribute;

public class MaskedTextBoxFieldUiAttribute(string labelText, string mask, [CallerMemberName] string prop = "")
    : FieldInfoUiAttribute(labelText, prop, FactoryElements.MaskedTextBox(mask));