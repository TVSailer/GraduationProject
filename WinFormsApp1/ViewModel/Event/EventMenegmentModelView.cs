using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;
using Logica;
using Logica.DI;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using WinFormsApp1;
using WinFormsApp1.View;
using WinFormsApp1.View.Event;

public class EventMenegmentModelView : INotifyPropertyChanged
{
    private List<EventEntity> eventEntities = new();
    private List<string> categorys = new() { "Пусто" };
    private string title = "";
    private string category = "";
    private string stDate = DateTime.Now.ToString();
    private string enDate = DateTime.Now.ToString();

    public ICommand OnBack { get; private set; }
    public ICommand OnLoadAddView { get; private set; }
    public ICommand OnLoadDetailsView { get; private set; }
    public ICommand OnSerch { get; private set; }
    public ICommand OnClearSerch { get; private set; }

    public string Title 
    { 
        get => title; 
        set
        {
            if (value == title)
                return;
            title = value;
            OnPropertyChanged();
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
            OnPropertyChanged();
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
            OnPropertyChanged();
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
            OnPropertyChanged();
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
            OnPropertyChanged();
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

    public event PropertyChangedEventHandler? PropertyChanged;

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
            _ => mainForm.InitializeComponent());

        OnLoadDetailsView = new MainCommand(
            _ =>
            {
                using (var scope = new ContainerScoped(AdminConteiner.Container))
                {
                    scope.GetService<EventDetailsView>().InitializeComponents();
                }
            });

        OnLoadAddView = new MainCommand(
            _ =>
            {
                using (var scope = new ContainerScoped(AdminConteiner.Container))
                {
                    scope.GetService<AddEventView>().InitializeComponents();
                }
            });
    }

    public void OnPropertyChanged([CallerMemberName] string prop = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }
}
