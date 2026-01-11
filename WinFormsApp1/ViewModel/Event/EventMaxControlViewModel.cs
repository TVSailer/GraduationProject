//using Admin.ViewModels;
//using DataAccess.Postgres.Models;
//using DataAccess.Postgres.Repository;
//using Logica;
//using System.Diagnostics.CodeAnalysis;
//using System.Windows.Input;
//using System.Xml.Linq;

//namespace WinFormsApp1.ViewModel.Event
//{
//    public class EventMaxControlViewModel : EventMinControlViewModel
//    {
//        public ICommand OnDelete { get; private set; }

//        [NotNull]
//        public EventEntity? EventEntity
//        {
//            get;
//            set
//            {
//                if (value is null) throw new ArgumentNullException();

//                Title = value.Title;
//                Description = value.Description;
//                Date = value.Date;
//                Location = value.Location;
//                Category = value.Location;
//                MaxParticipants = value.MaxParticipants.ToString();
//                Organizer = value.Organizer;
//                RegisLink = value.RegistrationLink;

//                value.ImgsEvent?.ForEach(img => SelectedImg.Add(img.Url, false));

//                field = value;
//            }
//        }

//        public EventMaxControlViewModel(EventRepository eventRepository) : base(eventRepository)
//        {
//            OnDelete = new MainCommand(
//                _ =>
//                {
//                    eventRepository.Delete(EventEntity);
//                    OnBack.Execute(null);
//                });

//            actjionSave = new MainCommand(
//                _ =>
//                {
//                    if (Validatoreg.TryValidObject(this, false))
//                    {
//                        List<ImgEventEntity> imgs = new();

//                        SelectedImg.ForEach(i => imgs.Add(new ImgEventEntity(i.Key)));

//                        eventRepository.Update(EventEntity.Id,
//                            new EventEntity(Title, Description, Date, Location, Category, RegisLink, Organizer, int.Parse(MaxParticipants), imgs));

//                        LogicaMessage.MessageOk("Мероприятие успешно отредактировано!");
//                        OnBack.Execute(null);
//                    }
//                });
//        }

//        public override IViewModel<EventEntity> Initialize(object value)
//        {
//            throw new NotImplementedException();
//        }

//        public override void SetData(EventEntity value)
//        {
//            EventEntity = value;
//        }
//    }
//}
