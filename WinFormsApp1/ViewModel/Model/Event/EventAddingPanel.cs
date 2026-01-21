using Admin.ViewModels;
using Admin.ViewModels.Lesson;
using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;
using Logica;
using System.Windows.Input;

namespace WinFormsApp1.ViewModelEntity.Event
{
    public class EventAddingPanel : EventData, IAddingPanel<EventEntity>
    {
        [ButtonInfoUI("Сохранить")] public ICommand OnSave { get; protected set; }

        public EventAddingPanel(EventRepository repository)
        {
            OnSave = new MainCommand(
                _ => TryValidObject(() => repository.Add(Entity)));
        }
    }
}
