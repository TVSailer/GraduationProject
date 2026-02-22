using Admin.Args;
using Admin.View.Moduls.UIModel;
using Admin.View.ViewForm;
using Admin.ViewModel.Interface;
using CSharpFunctionalExtensions;
using Logica.Interface;
using Logica.UILayerPanel;

namespace Admin.View;

public class ManagmentEntityUi<T, TEntity, TFieldSearch, TCard, TButtons>(
    T viewData,
    TButtons parametersButtons,

    SearchCardPanel<TEntity, TFieldSearch, TCard> searchCardPanel) : View<T> where TEntity : Entity, new()
    where TFieldSearch : PropertyChange, IFieldData
    where TCard : ObjectCard<TEntity>, new()
    where T : IFieldData
    where TButtons : IButtons<ViewButtonClickArgs<T>>, IButtons<CardClickedToolStripArgs<TEntity>>, IButton<CardClickedArgs<TEntity>>
{
    protected override Control CreateUi()
    {
        var layout = LayoutPanel.CreateColumn()
            .Row().ContentEnd(searchCardPanel
                .SetClickedPanel(parametersButtons)
                .SetContextMenu(parametersButtons)
                .CreateControl())
            .Row(80, SizeType.Absolute).ContentEnd(new ButtonLayoutPanel<ViewButtonClickArgs<T>>()
                .SetClickedData(this, new ViewButtonClickArgs<T>(viewData))
                .SetButtons(parametersButtons))
            .Build();

        return layout;
    }
}