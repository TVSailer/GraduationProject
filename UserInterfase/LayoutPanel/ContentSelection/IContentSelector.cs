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
    ButtonBuilder<TParentBuilder> Button(InfoButton infoButton);
    ImagePanelBuilder<TParentBuilder> ImageLayoutPanel(IRepositoryImgUi repositoryImgUi);
    ButtonLayerBuilder<TParentBuilder> ButtonLayoutPanel(InfoButton[] data);
    CardLayoutBuilder<TParentBuilder, FlowLayoutPanel, TEntity, TCard> CardFlowLayoutPanel<TEntity, TCard>(TEntity[] entities) where TCard : ObjectCard<TEntity>, new();
    CardLayoutBuilder<TParentBuilder, TableLayoutPanel, TEntity, TCard> CardTableLayoutPanel<TEntity, TCard>(TEntity[] entities) where TCard : ObjectCard<TEntity>, new();
    ImageBuilder<TParentBuilder> Image(string url);
}