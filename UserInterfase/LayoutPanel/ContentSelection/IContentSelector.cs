using System.Windows.Forms;
using System.Windows.Input;
using UserInterface.Command;
using UserInterface.Interfase;
using UserInterface.LayoutPanel.ControlBuilder;
using UserInterface.UiLayoutPanel.CardPanel;

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
    ImagePanelBuilder<TParentBuilder> ImageLayoutPanel(IRepositoryImgUi repositoryImgUi);
    ButtonLayerBuilder<TParentBuilder> ButtonLayoutPanel(ICommand[] data);
    CardLayoutBuilder<TParentBuilder, FlowLayoutPanel, TEntity, TCard> CardFlowLayoutPanel<TEntity, TCard>(Func<TEntity[]> entities) 
        where TCard : ObjectCard<TEntity>, new();
    CardLayoutBuilder<TParentBuilder, TableLayoutPanel, TEntity, TCard> CardTableLayoutPanel<TEntity, TCard>(Func<TEntity[]> entities) 
        where TCard : ObjectCard<TEntity>, new();
    ImageBuilder<TParentBuilder> Image(string url);
    PanelBuilder<TParentBuilder> Panel();
}