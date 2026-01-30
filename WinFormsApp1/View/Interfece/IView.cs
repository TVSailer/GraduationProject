using Admin.ViewModel.Interface;
using CSharpFunctionalExtensions;

namespace Admin.View.ViewForm
{
    public interface IView
    {
        public Form InitializeComponents(object? data);
    }
    
    public interface IView<T> : IView
    {
        public IViewModel<T> ViewModel { get; }
    }
}