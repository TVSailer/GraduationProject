using System.Runtime.CompilerServices;

namespace UserInterface.Attribute;

public class BaseFieldUiAttribute(string labelText, string placeholder = "", [CallerMemberName] string prop = "")
    : FieldInfoUiAttribute(labelText, prop, FactoryElements.TextBox(placeholder));