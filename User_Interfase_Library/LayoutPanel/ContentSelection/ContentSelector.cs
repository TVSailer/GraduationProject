using System.Windows.Forms;
using UserInterface.LayoutPanel.ControlBuilder;

namespace UserInterface.LayoutPanel.ContentSelection;

internal class ContentSelector<TParentBuilder>(TParentBuilder parentBuilder, Action<Control> setContent)
    : IContentSelector<TParentBuilder>
{
    public LabelBuilder<TParentBuilder> Label(string text)
    {
        var builder = new LabelBuilder<TParentBuilder>(parentBuilder);
        setContent(builder.Build());
        return builder.Text(text);
    }

    public TextBoxBuilder<TParentBuilder> TextBox(string placeholder)
    {
        var builder = new TextBoxBuilder<TParentBuilder>(parentBuilder);
        setContent(builder.Build());
        return builder.Placeholder(placeholder);
    }

    public NumericBuilder<TParentBuilder> Numeric()
    {
        var builder = new NumericBuilder<TParentBuilder>(parentBuilder);
        setContent(builder.Build());
        return builder;
    }

    public ComboBoxBuilder<TParentBuilder> ComboBox()
    {
        var builder = new ComboBoxBuilder<TParentBuilder>(parentBuilder);
        setContent(builder.Build());
        return builder.WriteValue();
    }
}