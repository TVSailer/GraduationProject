using Admin.ViewModel.Interface;
using CSharpFunctionalExtensions;

namespace Admin.View.ViewForm
{
    public interface IView
    {
        public Form InitializeComponents(object? data);
    }
    
    public interface IView<T, TEntity> : IView<T>
        where TEntity : Entity, new()
        where T : IFieldData<TEntity>
    {
        T ViewField { get; set; }
    }

    public interface IView<T> : IView;
}