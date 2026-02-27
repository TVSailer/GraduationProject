using System.Drawing;
using System.Windows.Forms;

namespace User_Interface_Library.TableLayerPanel.ControlBuilder;

public class LabelBuilder<TParentBuilder>(TParentBuilder parentBuilder) : IControlBuilder<Label, TParentBuilder>
{
    private readonly Label _label = new()
    {
        Font = new Font("Times New Roman", 11, FontStyle.Bold),
        AutoSize = true,
        TextAlign = ContentAlignment.TopLeft,
        BorderStyle = BorderStyle.None,
        Padding = new Padding(5),
        Dock = DockStyle.Fill
    };

    public LabelBuilder<TParentBuilder> Text(string text)
    {
        _label.Text = text;
        return this;
    }

    public Label Build() => _label;

    public TParentBuilder End()
    {
        return parentBuilder;
    }
}