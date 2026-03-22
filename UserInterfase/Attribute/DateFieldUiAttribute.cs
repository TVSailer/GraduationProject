using System.Runtime.CompilerServices;
using UserInterface.UiLayoutPanel;

namespace UserInterface.Attribute;

public class DateFieldUiAttribute(string labelText, string format, [CallerMemberName] string prop = "")
    : FieldInfoUiAttribute(labelText, prop, FactoryElements.DateTimePicker(format));