using Admin.ViewModel.Interface;
using CSharpFunctionalExtensions;

namespace Admin.View.ViewForm
{
    public interface IView
    {
        public Form InitializeComponents(object? data);
    }
    
    public interface IView<T, TEntity> : IView
        where TEntity : Entity, new()
        where T : IViewData<TEntity>
    {
        T ViewData { get; }
    }

    public interface IView<T> : IView
    {
    }
}