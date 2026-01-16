using Admin.ViewModels.Lesson;
using Admin.ViewModels.NotifuPropertyViewModel;
using CSharpFunctionalExtensions;
using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;
using Logica;
using System.Windows.Input;
using WinFormsApp1.View;

namespace Admin.ViewModels
{

    

    public class ManagmentModelView<TEntity, TAddingPanel, TDetailsPanel> : PropertyChange, IViewModele
        where TEntity : Entity, new()
        where TAddingPanel : IAddingPanel<TEntity>
        where TDetailsPanel : IDetalsPanel<TEntity>
    {
        [ButtonInfoUI("Добавить")]
        public ICommand OnLoadAddingView { get; private set; }

        [ButtonInfoUI("Назад")]
        public ICommand OnBack { get; private set; }

        public ICommand OnLoadDetailsView { get; private set; }

        public ManagmentModelView(
            AdminMainView mainForm,
            ParametrsFromManagmentMV<TEntity, TAddingPanel> addingPanel,
            ParametrsFromManagmentMV<TEntity, TDetailsPanel> detailsPanel,
            SerchManagment<TEntity> serchManagment)
        {

            OnBack = new MainCommand(
                _ => mainForm.InitializeComponents());

            OnLoadDetailsView = new MainCommand(
                obj =>
                {
                    if (obj is TEntity val)
                    {
                        detailsPanel.RepositoryEntity.SetEntity(val);
                        detailsPanel.UI.InitializeComponents(null);
                    }
                    else throw new ArgumentException();
                });

            OnLoadAddingView = new MainCommand(
                _ => addingPanel.UI.InitializeComponents(null));
        }
    }
}

