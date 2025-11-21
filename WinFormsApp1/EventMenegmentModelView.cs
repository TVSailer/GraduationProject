using AdminApp.Forms;
using DataAccess.Postgres;
using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

public class EventMenegmentModelView : INotifyPropertyChanged
{
    private EventManagementView eventManagementView;

    public readonly EventRepository EventRepository;

    public ICommand OnBack { get; private set; }
    public ICommand OnLoadAddView { get; private set; }
    public ICommand OnLoadEventManagementView { get; private set; }

    public List<EventEntity> EventEntities { get; private set; }// EventRepository.Get();

    public EventMenegmentModelView(Form mainForm, ICommand onBack, ApplicationDbContext dbContext)
    {
        EventRepository = new EventRepository(dbContext);

        OnBack = onBack;
        OnLoadEventManagementView = new MainCommand(_
            => eventManagementView.InitializeComponent(mainForm));
        OnLoadAddView = new MainCommand(_ 
            => new AddEventViewModel(mainForm, OnLoadEventManagementView, dbContext));

        EventEntities = new()
            {
                new EventEntity(
                    "Выпускной вечер",
                    "Торжественное мероприятие по случаю окончания учебного года с вручением дипломов и аттестатов.",
                    "25.05.2024",
                    "Актовый зал",
                    "Образование",
                    "https://example.com/register/1",
                    "Администрация школы", 150, 121,
                    new List<ImgEventEntity>
                    {
                        new ImgEventEntity { Url = "C://Users/tereg/Pictures/Screenshots/Screenshot 2025-03-20 151358.png" },
                        new ImgEventEntity { Url = "C://Users/tereg/Pictures/Screenshots/Screenshot 2025-03-15 113443.png" }
                    }) { },
                new EventEntity
                (
                    "Научная конференция",
                    "Ежегодная научная конференция с представлением исследовательских работ студентов и школьников.",
                    "15.03.2024",
                    "Конференц-зал",
                    "Наука",
                    "https://example.com/register/2",
                    "Научный отдел", 60, 50,
                    new List<ImgEventEntity>() { }) { }
            };

        eventManagementView = new EventManagementView(mainForm, this);
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    public void OnPropertyChanged([CallerMemberName] string prop = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }
}
