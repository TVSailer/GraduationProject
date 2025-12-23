using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;
using Logica;
using System.Windows.Input;

namespace WinFormsApp1.ViewModel.Event
{
    public class EventDetailsViewModel : EventDataViewModel
    {
        public readonly EventEntity EventEntity;
        public ICommand OnDelete { get; private set; }

        public EventDetailsViewModel(EventRepository eventRepository, int idEvent) : base(eventRepository)
        {
            EventEntity = eventRepository.Get(idEvent);

            EventEntity.ImgsEvent?.ForEach(img => SelectedImg.Add(img.Url, false));

            Title = EventEntity.Title;
            Description = EventEntity.Description;
            Date = EventEntity.Date;
            Location = EventEntity.Location;
            Category = EventEntity.Location;
            MaxParticipants = EventEntity.MaxParticipants.ToString();
            Organizer = EventEntity.Organizer;
            RegisLink = EventEntity.RegistrationLink;

            OnDelete = new MainCommand(
                _ =>
                {
                    eventRepository.Delete(EventEntity.Id);
                    OnBack.Execute(null);
                });

            OnSave = new MainCommand(
                _ =>
                {
                    if (Validatoreg.TryValidObject(this, false))
                    {
                        List<ImgEventEntity> imgs = new();

                        SelectedImg.ForEach(i => imgs.Add(new ImgEventEntity(i.Key)));

                        eventRepository.Update(idEvent,
                            new EventEntity(Title, Description, Date, Location, Category, RegisLink, Organizer, int.Parse(MaxParticipants), imgs));

                        LogicaMessage.MessageOk("Мероприятие успешно отредактировано!");
                        OnBack.Execute(null);
                    }
                });
        }
    }
}
