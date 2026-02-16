using Admin.Args;
using Admin.View.AdminMain;
using Admin.View.Moduls.UIModel;
using Admin.View.ViewForm;
using Admin.ViewModel.Interface;
using CSharpFunctionalExtensions;
using Logica.UILayerPanel;

namespace Admin.View;

public class ManagmentEntityUi<T, TEntity, TFieldSearch, TFieldDetails, TCard, TButtons>(
    AdminMainView form,
    T viewData,
    TButtons parametersButtons,
    SearchCardPanel<TEntity, TFieldSearch, TFieldDetails, TCard> searchCardPanel) : View<T>(form) where TEntity : Entity, new()
    where TFieldSearch : PropertyChange, IFieldData
    where TFieldDetails : IFieldData<TEntity>
    where TCard : ObjectCard<TEntity>, new()
    where T : IFieldData
    where TButtons : IButtons<ViewButtonClickArgs<T>>
{
    protected override Control CreateUi()
    {
        var layout = LayoutPanel.CreateColumn()
            .Row().ContentEnd(searchCardPanel.CreateControl())
            .Row(80, SizeType.Absolute).ContentEnd(new ButtonLayoutPanel<ViewButtonClickArgs<T>>()
                .SetClickedData(this, new ViewButtonClickArgs<T>(viewData))
                .SetButtons(parametersButtons))
            .Build();

        return layout;
    }
}