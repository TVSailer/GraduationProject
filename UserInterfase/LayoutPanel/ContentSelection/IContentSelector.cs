using System.Windows.Forms;
using System.Windows.Input;
using UserInterface.Command;
using UserInterface.LayoutPanel.ControlBuilder;
using UserInterface.Service.Image.BaseServiceImage;
using UserInterface.UiObjects.Card;

namespace UserInterface.LayoutPanel.ContentSelection;

public interface IContentSelector<TParentBuilder>
{
    LabelBuilder<TParentBuilder> Label(string text = "");
    LinkLabelBuilder<TParentBuilder> LinkLabel(string text = "");
    LinkLabelBuilder<TParentBuilder> LinkLabel(InfoCommand info);
    TextBoxBuilder<TParentBuilder> TextBox(string placeholder = "");
    NumericBuilder<TParentBuilder> Numeric();
    ComboBoxBuilder<TParentBuilder> ComboBox();
    DateTimePickerBuilder<TParentBuilder> DateTimePicker(string format = "");
    MaskedTextBoxBuilder<TParentBuilder> MaskedTextBox(string mask = "");
    ButtonBuilder<TParentBuilder> Button(string text = "");
    DataGridViewBuilder<TParentBuilder> DataGridView();
    ChekedListBoxBuilder<TParentBuilder> ChekedListBox();
    ImagePanelBuilder<TParentBuilder> ImageLayoutPanel();
    ButtonLayerBuilder<TParentBuilder> ButtonLayoutPanel(ICommand[] data);
    CardLayoutBuilder<TParentBuilder, FlowLayoutPanel, TEntity, TCard> CardFlowLayoutPanel<TEntity, TCard>() 
        where TCard : ObjectCard<TEntity>, new();
    CardLayoutBuilder<TParentBuilder, TableLayoutPanel, TEntity, TCard> CardTableLayoutPanel<TEntity, TCard>() 
        where TCard : ObjectCard<TEntity>, new();
    ImageBuilder<TParentBuilder> Image(string? url = "");
    PanelBuilder<TParentBuilder> Panel();
}