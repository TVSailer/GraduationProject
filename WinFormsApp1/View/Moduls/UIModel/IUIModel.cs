using CSharpFunctionalExtensions;

namespace Admin.View.Moduls.UIModel
{
    public interface IUIModel<TEntity, TViewModel>
        where TEntity : Entity
        where TViewModel : IViewModele<TEntity>
    {
    }
}
