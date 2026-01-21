using Admin.ViewModels;
using Admin.ViewModels.Lesson;
using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;
using Logica;
using System.Windows.Input;

namespace WinFormsApp1.ViewModelEntity.Event
{
    public class EventDetailsPanel : EventData, IDetalsPanel<EventEntity>
    {
        [ButtonInfoUI("Удалить")] public ICommand OnDelete { get; protected set; }
        [ButtonInfoUI("Обновить")] public ICommand OnUpdate { get; protected set; }

        public EventDetailsPanel(EventRepository eventRepository)
        {
            OnDelete = new MainCommand(
                _ =>
                {
                    eventRepository.Delete(Entity);
                    OnBack.Execute(null);
                });

            OnUpdate = new MainCommand(
                _ => TryValidObject(() => eventRepository.Update(Entity.Id, Entity)));
        }
    }
}
