using DataAccess.Postgres.Repository;

public class EventAddingViewModel : EventDataViewModel
{
    public EventAddingViewModel(EventRepository eventRepository) : base(eventRepository)
    {
        MaxParticipants = "1";
    }
}
 