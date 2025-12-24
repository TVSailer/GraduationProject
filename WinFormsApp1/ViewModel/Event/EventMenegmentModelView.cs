using Admin.ViewModel;
using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;
using Logica;
using Logica.DI;
using System.Windows.Input;
using WinFormsApp1;
using WinFormsApp1.View;
using WinFormsApp1.View.Event;

public class EventMenegmentModelView : AbstractManagmentModelView
{
    private List<EventEntity> eventEntities = new();
    private List<string> categorys = new() { "Пусто" };
    private string title = "";
    private string category = "";
    private string stDate = DateTime.Now.ToString();
    private string enDate = DateTime.Now.ToString();

    public override ICommand OnBack { get; set; }
    public override ICommand OnLoadAddingView { get; set; }
    public override ICommand OnLoadDetailsView { get; set; }
    public override ICommand OnSerch { get; set; }
    public override ICommand OnClearSerch { get; set; }

    public string Title 
    { 
        get => title; 
        set
        {
            if (value == title)
                return;
            title = value;
        }
    }
    public string Category
    {
        get => category;
        set
        {
            if (value == category)
                return;
            category = value;
        }
    }
    public string StartDate
    {
        get => stDate;
        set
        {
            if (value == stDate)
                return;
            stDate = value;
        }
    }
    public string EndDate
    {
        get => enDate;
        set
        {
            if (value == enDate)
                return;
            enDate = value;
        }
    }

    public List<string> Categorys
    {
        get => categorys;
        private set
        {
            if (categorys.SequenceEqual(value))
                return;

            categorys = value;
        }
    }
    public List<EventEntity> EventEntities 
    {
        get => eventEntities;
        private set
        {
            if (eventEntities.SequenceEqual(value))
                return;

            eventEntities = value;
            OnPropertyChanged();
        }
    }

    public EventMenegmentModelView(AdminMainView mainForm, EventRepository eventRepository)
    {
        eventRepository.Get().ForEach(e =>
        {
            EventEntities.Add(e);
            if (!Categorys.Contains(e.Category))
                Categorys.Add(e.Category);
        });

        OnSerch = new MainCommand(
            _ =>
            {
                EventEntities = eventRepository.Get()
                .Where(e => e.Title.StartsWith(Title))
                .Where(e => Category == "Пусто" ? true : e.Category == Category)
                .Where(e => DateTime.Parse(StartDate) < DateTime.Parse(e.Date) && DateTime.Parse(EndDate) > DateTime.Parse(e.Date))
                .ToList();
            });

        OnClearSerch = new MainCommand(
            _ =>
            {
                EventEntities = eventRepository.Get();
            });

        OnBack = new MainCommand(
            _ => mainForm.InitializeComponents());

        OnLoadDetailsView = new MainCommand(
            _ =>
            {
                using (var scope = new ContainerScoped(AdminDIConteiner.Container))
                {
                    scope.GetService<EventDetailsView>().InitializeComponents();
                }
            });

        OnLoadAddingView = new MainCommand(
            _ =>
            {
                using (var scope = new ContainerScoped(AdminDIConteiner.Container))
                {
                    scope.GetService<AddingEventView>().InitializeComponents();
                }
            });
    }
}
