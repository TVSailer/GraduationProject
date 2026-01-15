using Admin.ViewModels.NotifuPropertyViewModel;
using CSharpFunctionalExtensions;
using DataAccess.Postgres.Repository;
using Logica;
using System.Windows.Input;
using WinFormsApp1.View;

namespace Admin.ViewModels
{

    

    public class ManagmentModelView<TEntity, TAddingPanel, TDetailsPanel> : PropertyChange
        where TEntity : Entity, new()
        where TAddingPanel : IAddingPanel<TEntity>
        where TDetailsPanel : IDetalsPanel<TEntity>
    {
        public event Action<ICommand> OnClick; 

        public ICommand OnBack { get; private set; }
        public ICommand OnLoadAddingView { get; private set; }
        public ICommand OnLoadDetailsView { get; private set; }
        public ICommand OnSerch { get; private set; }
        public ICommand OnClearSerch { get; private set; }

        public List<TEntity> DataEntitys
        {
            get;
            set;
        }

        public ManagmentModelView(
            AdminMainView mainForm, 
            Repository<TEntity> repository,
            ParametrsFromManagmentMV<TEntity, TAddingPanel> addingPanel,
            ParametrsFromManagmentMV<TEntity, TDetailsPanel> detailsPanel)
        {
            DataEntitys = repository.Get();

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

            //OnSerch = new MainCommand(
            //_ =>
            //{
            //    data = repository.Get()
            //   .Where(e => e.Title.StartsWith(Title))
            //   .Where(e => Category == "Пусто" ? true : e.Category == Category)
            //   .Where(e => DateTime.Parse(StartDate) < DateTime.Parse(e.Date) && DateTime.Parse(EndDate) > DateTime.Parse(e.Date))
            //   .ToList();
            //});

            //OnClearSerch = new MainCommand(
            //    _ => data = repository.Get());
        }
    }
}

