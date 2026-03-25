using System.Windows.Forms;
using System.Windows.Input;
using UserInterface.Command;
using UserInterface.LayoutPanel.ControlBuilder;
using UserInterface.Service.Image.BaseServiceImage;
using UserInterface.UiObjects.Card;

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
    {
        return Builder<LabelBuilder<TParentBuilder>, Label>()
            .Text(text);
    }

    public LinkLabelBuilder<TParentBuilder> LinkLabel(string text = "")
        => Builder<LinkLabelBuilder<TParentBuilder>, LinkLabel>()
            .Text(text);

    public LinkLabelBuilder<TParentBuilder> LinkLabel(InfoCommand info)
        => Builder<LinkLabelBuilder<TParentBuilder>, LinkLabel>();

    public TextBoxBuilder<TParentBuilder> TextBox(string placeholder)
    {
        return Builder<TextBoxBuilder<TParentBuilder>, TextBox>()
            .Placeholder(placeholder);
    }

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

    public ImagePanelBuilder<TParentBuilder> ImageLayoutPanel(IImagePanel imagePanel)
        => Builder<ImagePanelBuilder<TParentBuilder>, FlowLayoutPanel>()
            .Setting(imagePanel);

    public ImagePanelBuilder<TParentBuilder> ImageLayoutPanel()
        => Builder<ImagePanelBuilder<TParentBuilder>, FlowLayoutPanel>();

    public ButtonLayerBuilder<TParentBuilder> ButtonLayoutPanel(ICommand[] data)
        => Builder<ButtonLayerBuilder<TParentBuilder>, Panel>()
            .Data(data);

    public CardLayoutBuilder<TParentBuilder, FlowLayoutPanel, TEntity, TCard> CardFlowLayoutPanel<TEntity, TCard>(Func<IEnumerable<TEntity>> entities) where TCard : ObjectCard<TEntity>, new()
        => Builder<CardLayoutBuilder<TParentBuilder, FlowLayoutPanel, TEntity, TCard>, FlowLayoutPanel>()
            .SetData(entities);

    public CardLayoutBuilder<TParentBuilder, TableLayoutPanel, TEntity, TCard> CardTableLayoutPanel<TEntity, TCard>(Func<IEnumerable<TEntity>> entities) where TCard : ObjectCard<TEntity>, new()
        => Builder<CardLayoutBuilder<TParentBuilder, TableLayoutPanel, TEntity, TCard>, TableLayoutPanel>()
            .SetData(entities);

    public ImageBuilder<TParentBuilder> Image(string url = "")
        => Builder<ImageBuilder<TParentBuilder>, PictureBox>()
            .Url(url);

    public PanelBuilder<TParentBuilder> Panel()
        => Builder<PanelBuilder<TParentBuilder>, Panel>();
}