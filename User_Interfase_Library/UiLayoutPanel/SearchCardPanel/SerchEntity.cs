using User_Interface_Library.UiLayoutPanel.SearchPanel;

namespace User_Interface_Library.UiLayoutPanel.SearchCardPanel;

public class SearchEntity<TEntity, T> : ISearchEntity
    where T : SearchFieldData<TEntity>
    where TEntity : new()
{
    private readonly T _field;
    private readonly TEntity[] _data;

    public event Action<TEntity[]>? OnSortEntity;

    public object GetField() => _field;

    public void OnClearSearch()
    {
        OnSortEntity?.Invoke(_data);
        _field.ClearFunc.Invoke();
    }

    public SearchEntity(T field, TEntity[] data)
    {
        _data = data;
        _field = field;
        _field.PropertyChanged += (_, _) => OnSortEntity?.Invoke(_field.SearchFunc(data));
    }
}