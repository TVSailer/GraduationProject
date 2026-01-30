using Admin.ViewModel.Interface;
using CSharpFunctionalExtensions;

namespace Admin.View.ViewForm
{
    public interface IView
    {
        public Form InitializeComponents(object? data);
    }
    
    // public interface IView<TEntity, TViewModel> : IView<TViewModel>
    //     where TEntity : Entity, new()
    //     where TViewModel : IViewModele<TEntity>
    // {
    // }
    
    public interface IView<T> : IView
        where T : IParam
    {
        public IViewModel<T> ViewModel { get; }
    }
}