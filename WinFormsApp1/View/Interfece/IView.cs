using Admin.ViewModel.Interface;
using CSharpFunctionalExtensions;

namespace Admin.View.ViewForm
{
    public interface IView
    {
        public Form InitializeComponents(object? data);
    }
    
    public interface IView<TEntity, TViewModel> : IView<TViewModel>
        where TEntity : Entity, new()
        where TViewModel : IViewModele<TEntity>
    {
    }
    
    public interface IView<TViewModel> : IView
        where TViewModel : IViewModele
    {
        public IViewModele ViewModele { get; set; }
    }
}