using System.Runtime.CompilerServices;

namespace UserInterface.Attribute;

public class NumericFieldUiAttribute(string labelText, [CallerMemberName] string prop = "")
    : FieldInfoUiAttribute(labelText, prop, FactoryElements.NumericUpDown());