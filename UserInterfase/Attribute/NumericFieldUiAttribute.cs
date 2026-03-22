using System.Runtime.CompilerServices;
using UserInterface.UiLayoutPanel;

namespace UserInterface.Attribute;

public class NumericFieldUiAttribute(string labelText, [CallerMemberName] string prop = "")
    : FieldInfoUiAttribute(labelText, prop, FactoryElements.NumericUpDown());