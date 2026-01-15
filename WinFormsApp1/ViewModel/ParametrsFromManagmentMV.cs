using CSharpFunctionalExtensions;
using WinFormsApp1;

namespace Admin.ViewModels
{
    public class ParametrsFromManagmentMV<TEntity, TViewModel>
        where TEntity : Entity, new()
        where TViewModel : IViewModele<TEntity>
    {
        public UIEntity<TEntity, TViewModel> UI { get; private set; }
        public GenericRepositoryEntity<TEntity, TViewModel> RepositoryEntity { get; private set; }
        public TViewModel ViewModel { get; private set; }

        public ParametrsFromManagmentMV()
        {
            using (var scope = AdminDI.CreateDIScope())
            {
                ViewModel = scope.GetService<TViewModel>();
                RepositoryEntity = scope.GetService<GenericRepositoryEntity<TEntity, TViewModel>>();
                UI = scope.GetService<UIEntity<TEntity, TViewModel>>();
            }
        }
    }
}

