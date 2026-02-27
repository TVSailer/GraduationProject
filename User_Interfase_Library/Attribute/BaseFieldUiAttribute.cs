using System.Runtime.CompilerServices;

namespace User_Interface_Library.Attribute;

public class BaseFieldUiAttribute(string labelText, string placeholder = "", [CallerMemberName] string prop = "")
    : FieldInfoUiAttribute(labelText, prop, FactoryElements.TextBox(placeholder));