using CSharpFunctionalExtensions;

namespace Admin.ViewModels
{
    public interface IAddingPanel<T> : IViewModele<T>
        where T : Entity
    {
    }
}