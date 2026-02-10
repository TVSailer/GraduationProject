using CSharpFunctionalExtensions;

namespace Logica.UILayerPanel;

public interface IUIModel
{
    public Control? CreateControl();
}

public interface ISearchModule<T> : IUIModel
    where T : Entity, new();

public interface ICardModule<T> : IUIModel 
    where T : Entity, new();

public interface IUIModel<T> : IUIModel
{
}