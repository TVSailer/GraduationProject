using Admin.View.Moduls.Event;
using Admin.View.ViewForm;
using Admin.ViewModels.NotifuPropertyViewModel;
using CSharpFunctionalExtensions;
using DataAccess.Postgres.Repository;
using Logica;
using System.Windows.Input;
using WinFormsApp1;
using WinFormsApp1.View;

namespace Admin.ViewModels
{
    public class ManagmentModelView<TEntity> : PropertyChange
        where TEntity : Entity, new()
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

        public ManagmentModelView(AdminMainView mainForm, Repository<TEntity> repository, UIEntity<TEntity> controlView, FactoryViewModelEntity<TEntity> controlViewModel)
        {
           DataEntitys = repository.Get();

           OnBack = new MainCommand(
                _ => mainForm.InitializeComponents());

           OnLoadDetailsView = new MainCommand(
                obj =>
                {
                    if (obj is TEntity val)
                    {
                        controlViewModel.SetEntity(val);
                        controlView.InitializeComponents(controlViewModel);
                    }
                    else throw new ArgumentException();
                });

            OnLoadAddingView = new MainCommand(
                _ => controlView.InitializeComponents(controlViewModel));

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
