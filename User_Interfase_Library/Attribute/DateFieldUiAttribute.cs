using System.Runtime.CompilerServices;

namespace User_Interface_Library.Attribute;

public class DateFieldUiAttribute(string labelText, string format, [CallerMemberName] string prop = "")
    : FieldInfoUiAttribute(labelText, prop, FactoryElements.DateTimePicker(format));