using Admin.ViewModel.Interface;
using CSharpFunctionalExtensions;
using Logica.UILayerPanel;

namespace Admin.View.Moduls.UIModel;

public class SearchCardModule<TEntity, TFieldSearch, TFieldData>(
    CardModule<TEntity> cardModule, 
    ControlView control,
    SearchModule<TEntity, TFieldSearch> searchModule) : IUIModel
    where TFieldSearch : PropertyChange, IFieldData
    where TEntity : Entity, new()
    where TFieldData : IFieldData<TEntity>
{

    public Control? CreateControl()
    {
        cardModule.OnClick = entity => control.LoadView<TFieldData, TEntity>(entity);
        searchModule.Search.OnSortEntity = e => cardModule.UpdateCard(e);
        cardModule.UpdateCard(searchModule.Search.GetEntities());

        return LayoutPanel.CreateRow()
            .Column(75).ContentEnd(cardModule.CreateControl())
            .Column(25).ContentEnd(searchModule.CreateControl())
            .Build();
    }
}