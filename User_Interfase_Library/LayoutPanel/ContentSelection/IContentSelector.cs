using UserInterface.LayoutPanel.ControlBuilder;

namespace UserInterface.LayoutPanel.ContentSelection;

public interface IContentSelector<TParentBuilder>
{
    LabelBuilder<TParentBuilder> Label(string text = "");
    TextBoxBuilder<TParentBuilder> TextBox(string placeholder = "");
    NumericBuilder<TParentBuilder> Numeric();
    ComboBoxBuilder<TParentBuilder> ComboBox();
    DateTimePickerBuilder<TParentBuilder> DateTimePicker(string format = "");
    MaskedTextBoxBuilder<TParentBuilder> MaskedTextBox(string mask = "");
}