using CSharpFunctionalExtensions;

namespace Admin.ViewModels
{
    public interface IDetalsPanel<T> : IViewModele<T>
        where T : Entity
    {
    }
}