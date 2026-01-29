namespace Admin.View.Moduls.UIModel
{
    public interface IUIModel
    {
        public Control? CreateControl();
    }
    
    public interface IUIModel<T> : IUIModel
        where T : Control
    {
    }
}
