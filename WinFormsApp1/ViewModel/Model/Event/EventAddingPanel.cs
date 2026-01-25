using System.Windows.Input;
using Admin.ViewModels;
using Admin.ViewModels.Lesson;
using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;
using Logica;

namespace WinFormsApp1.ViewModelEntity.Event
{
    [LinkingCommand(nameof(ManagmentModelView<>.OnLoadAddingView))]
    public class EventAddingPanel : EventData
    {
        [ButtonInfoUI("Сохранить")] public ICommand OnSave { get; protected set; }

        public EventAddingPanel(EventRepository repository, EventCategoryRepositroy categoryRepositroy) : base(categoryRepositroy)
        {
            OnSave = new MainCommand(
                _ => TryValidObject(() => repository.Add(GenericRepositoryEntity.Entity)));
        }
    }
}
