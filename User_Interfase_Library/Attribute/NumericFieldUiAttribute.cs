using System.Runtime.CompilerServices;

namespace User_Interface_Library.Attribute;

public class NumericFieldUiAttribute(string labelText, [CallerMemberName] string prop = "")
    : FieldInfoUiAttribute(labelText, prop, FactoryElements.NumericUpDown());