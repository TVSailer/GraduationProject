using CSharpFunctionalExtensions;

namespace Admin.View.ViewForm
{
    public interface IView
    {
        public Form InitializeComponents(object? data);
    }
    
    public interface IView<TEntity> : IView
        where TEntity : Entity, new()
    {
        public IViewModele<TEntity> ViewModele { get; set; }
    }
}