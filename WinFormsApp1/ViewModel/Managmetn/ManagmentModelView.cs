using System.Reflection;
using Admin.ViewModels.Lesson;
using Admin.ViewModels.NotifuPropertyViewModel;
using CSharpFunctionalExtensions;
using Logica;
using System.Windows.Input;
using Admin.View.ViewForm;
using Admin.ViewModel.WordWithEntity;
using Admin.ViewModels;
using WinFormsApp1.View;

namespace Admin.ViewModels
{
    public class ManagmentModelView<TEntity> : PropertyChange, IViewModele
        where TEntity : Entity, new()
    {
        public SerchManagment<TEntity> SerchManagment { get; private set; }

        [ButtonInfoUI("Добавить")]
        public ICommand OnLoadAddingView { get; private set; }

        [ButtonInfoUI("Назад")]
        public ICommand OnBack { get; private set; }

        public ICommand OnLoadDetailsView { get; private set; }

        public ManagmentModelView(
            AdminMainView mainForm,
            SerchManagment<TEntity> serchManagment,
            IView<TEntity>[] view)
        {
            SerchManagment = serchManagment;
            var detailsPanel = GetEntity(view, nameof(OnLoadDetailsView));
            var addingPanel = GetEntity(view, nameof(OnLoadAddingView));

            OnBack = new MainCommand(
                _ => mainForm.InitializeComponents());

            OnLoadDetailsView = new MainCommand(
                obj =>
                {
                    if (obj is TEntity val)
                    {
                        detailsPanel.ViewModele.GenericRepositoryEntity.SetEntity(val);
                        detailsPanel.InitializeComponents(null);
                    }
                    else throw new ArgumentException();
                });

            OnLoadAddingView = new MainCommand(
                _ => addingPanel.InitializeComponents(null));
        }

        public IView<TEntity> GetEntity(IView<TEntity>[] viewModeles, string nameCommand)
            => viewModeles
                .First(v => v.ViewModele
                    .GetType()
                    .GetCustomAttribute<LinkingCommandAttribute>()!.NameCommand
                    .Equals(nameCommand)) ?? throw new Exception();
    }
}

