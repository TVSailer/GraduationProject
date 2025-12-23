using DataAccess.Postgres.Repository;

public class AddingEventViewModel : EventDataViewModel
{
    public AddingEventViewModel(EventRepository eventRepository) : base(eventRepository)
    {
        MaxParticipants = "1";
    }
}
 