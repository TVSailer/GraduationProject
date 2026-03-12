using System.Windows.Forms;
using UserInterface.Info;
using UserInterface.LayoutPanel.ControlBuilder;
using UserInterface.UiLayoutPanel.CardPanel;
using UserInterface.UiLayoutPanel.ImagePanel;

namespace UserInterface.LayoutPanel.ContentSelection;

public interface IContentSelector<TParentBuilder>
{
    LabelBuilder<TParentBuilder> Label(string text = "");
    LinkLabelBuilder<TParentBuilder> LinkLabel(string text = "");
    TextBoxBuilder<TParentBuilder> TextBox(string placeholder = "");
    NumericBuilder<TParentBuilder> Numeric();
    ComboBoxBuilder<TParentBuilder> ComboBox();
    DateTimePickerBuilder<TParentBuilder> DateTimePicker(string format = "");
    MaskedTextBoxBuilder<TParentBuilder> MaskedTextBox(string mask = "");
    ButtonBuilder<TParentBuilder> Button(string text = "");
    ImagePanelBuilder<TParentBuilder> ImageLayoutPanel(IRepositoryImgUi repositoryImgUi);
    ButtonLayerBuilder<TParentBuilder> ButtonLayoutPanel(InfoButton[] data);
    CardLayoutBuilder<TParentBuilder, TControl, TEntity, TCard> CardLayoutPanel<TEntity, TCard, TControl>(
        TEntity[] entities)
        where TCard : ObjectCard<TEntity>, new()
        where TControl : Panel, new();
}