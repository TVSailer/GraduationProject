namespace Logica.UILayerPanel;

public interface IUIModel
{
    public Control? CreateControl();
}

public interface IUIModel<T> : IUIModel
    where T : Control
{
}