using System.Windows.Forms;
using UserInterface.Info;
using UserInterface.LayoutPanel.ControlBuilder;
using UserInterface.UiLayoutPanel.CardPanel;
using UserInterface.UiLayoutPanel.ImagePanel;

namespace UserInterface.LayoutPanel.ContentSelection;

internal class ContentSelector<TParentBuilder>(TParentBuilder parentBuilder, Action<Control> setContent)
    : IContentSelector<TParentBuilder>
{
    public TBuilder Builder<TBuilder, TControl>()
        where TControl : Control, new()
        where TBuilder : ControlBuilder<TControl, TParentBuilder>, new()
    {
        var builder = new TBuilder();
        builder.Initialize(parentBuilder);
        setContent(builder.Build());
        return builder;
    }

    public LabelBuilder<TParentBuilder> Label(string text) 
        => Builder<LabelBuilder<TParentBuilder>, Label>()
            .Text(text);

    public LinkLabelBuilder<TParentBuilder> LinkLabel(string text = "")
        => Builder<LinkLabelBuilder<TParentBuilder>, LinkLabel>()
            .Text(text);

    public TextBoxBuilder<TParentBuilder> TextBox(string placeholder)
        => Builder<TextBoxBuilder<TParentBuilder>, TextBox>()
            .Placeholder(placeholder);

    public NumericBuilder<TParentBuilder> Numeric()
        => Builder<NumericBuilder<TParentBuilder>, NumericUpDown>();

    public ComboBoxBuilder<TParentBuilder> ComboBox()
        => Builder<ComboBoxBuilder<TParentBuilder>, ComboBox>()
            .WriteValue();

    public DateTimePickerBuilder<TParentBuilder> DateTimePicker(string format = "")
        => Builder<DateTimePickerBuilder<TParentBuilder>, DateTimePicker>()
            .Format(format);

    public MaskedTextBoxBuilder<TParentBuilder> MaskedTextBox(string mask = "")
        => Builder<MaskedTextBoxBuilder<TParentBuilder>, MaskedTextBox>()
            .Mask(mask);

    public ButtonBuilder<TParentBuilder> Button(string text = "")
        => Builder<ButtonBuilder<TParentBuilder>, Button>()
            .Text(text);

    public ImagePanelBuilder<TParentBuilder> ImageLayoutPanel(IRepositoryImgUi repositoryImgUi) 
        => Builder<ImagePanelBuilder<TParentBuilder>, FlowLayoutPanel>()
            .Repository(repositoryImgUi);

    public ButtonLayerBuilder<TParentBuilder> ButtonLayoutPanel(InfoButton[] data)
        => Builder<ButtonLayerBuilder<TParentBuilder>, Panel>()
            .Data(data);

    public CardLayoutBuilder<TParentBuilder, TControl, TEntity, TCard> CardLayoutPanel<TEntity, TCard, TControl>(
        TEntity[] entities)
        where TCard : ObjectCard<TEntity>, new()
        where TControl : Panel, new()
        => Builder<CardLayoutBuilder<TParentBuilder, TControl, TEntity, TCard>, TControl>()
            .Initialize(entities);
}