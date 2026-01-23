using Admin.ViewModels;
using Admin.ViewModels.Lesson;
using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;
using Logica;
using System.Windows.Input;
using CSharpFunctionalExtensions;

namespace WinFormsApp1.ViewModelEntity.Event
{
    [LinkingCommand(nameof(ManagmentModelView<>.OnLoadDetailsView))]
    public class EventDetailsPanel : EventData
    {
        [ButtonInfoUI("Удалить")] public ICommand OnDelete { get; protected set; }
        [ButtonInfoUI("Обновить")] public ICommand OnUpdate { get; protected set; }

        public EventDetailsPanel(EventRepository eventRepository, EventCategoryRepositroy categoryRepositroy) : base(categoryRepositroy)
        {
            OnDelete = new MainCommand(
                _ =>
                {
                    eventRepository.Delete(GenericRepositoryEntity.Entity);
                    OnBack.Execute(null);
                });
            
            OnUpdate = new MainCommand(
                _ => TryValidObject(() => eventRepository.Update(GenericRepositoryEntity.Entity.Id, GenericRepositoryEntity.Entity)));
        }
    }
}
