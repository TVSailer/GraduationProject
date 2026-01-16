using DataAccess.Postgres;
using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;
using Logica;
using System.Windows.Input;

public partial class VisitorView : Form
{
    public VisitorView(ApplicationDbContext dbContext)
    {
        DataContext = new VisitorModelView(dbContext, this);
        InitializeComponent();
    }

    public Form InitializeComponent()
        => this
            .With(m => m.Controls.Clear())
            .With(m => m.Text = "")
            .With(m => m.WindowState = FormWindowState.Maximized)
            .With(m => m.StartPosition = FormStartPosition.CenterParent)
            .With(m => m.BackColor = Color.White)
            .With(m => m.Controls.Add(MainMenu()));

    private TableLayoutPanel MainMenu()
        => FactoryElements.TableLayoutPanel()
            .With(t => t.Padding = new Padding(30))
            .With(t => t.Dock = DockStyle.Fill)
            .ControlAddIsColumnPercent(null, 25)
            .ControlAddIsColumnAbsolute(null, 600)
            .ControlAddIsRowsAbsolute(FactoryElements.LabelTitle(""), 70)
            .ControlAddIsRowsAbsolute(Button("👤 Профиль"), 50)
            .ControlAddIsRowsAbsolute(Button("📰 Новости"), 50)
            .ControlAddIsRowsAbsolute(Button("🎭 Мероприятиями", DataContext, "OnLoadEventsView"), 50)
            .ControlAddIsRowsAbsolute(Button("🎨 Кружки"), 50)
            .ControlAddIsRowsAbsolute(Button("📊 Посещаемоть"), 50)
            .ControlAddIsColumnPercent(null, 25)
            .ControlAddIsRowsPercent(null, 25);

    private ButtonBase Button(string text)
        => FactoryElements.Button(text, 12)
            .With(b => b.BackColor = Color.LightGray);

    private Control Button(string text, object context, string dataMember)
        => FactoryElements.Button(text, 12, context, dataMember)
            .With(b => b.BackColor = Color.LightGray);
}

public class VisitorModelView
{
    private ApplicationDbContext dbContext;
    private VisitorView visitorView;

    public ICommand OnLoadMainMenuView { get; private set; }
    public ICommand OnLoadEventsView { get; private set; }
    public ICommand OnLoadNewsView;
    public ICommand OnLoadLessonsView;
    public ICommand OnLoadAttendancesView;

    public VisitorModelView(ApplicationDbContext dbContext, VisitorView visitorView)
    {
        OnLoadMainMenuView = new MainCommand(_
            => visitorView.InitializeComponent());

        OnLoadEventsView = new MainCommand(_
            => new EventModelView(visitorView, OnLoadMainMenuView, new EventRepository(dbContext)));

        this.dbContext = dbContext;
        this.visitorView = visitorView;
    }
}

public class EventModelView
{
    public EventModelView(Form mainForm, ICommand back, EventRepository eventRepository)
    {
        new EventView(mainForm, eventRepository.Get());
    }
}

public class EventView
{
    public EventView(Form form, List<EventEntity> entitys)
    {
        LoadEventView(form, entitys);
    }

    private void LoadEventView(Form form, List<EventEntity> entitys)
    {
        form.Controls.Clear();

        var titleLabel = FactoryElements.LabelTitle("Ближайшие мероприятия");


        var mainTable = FactoryElements.TableLayoutPanel()
            .ControlAddIsRowsAbsolute(titleLabel, 70)
            .ControlAddIsRowsPercent(
                FactoryElements.TableLayoutPanel()
                .With(
                    t => 
                    {
                        entitys.ForEach(e => t.ControlAddIsRowsAbsolute(EventCard(e), 270));
                        t.ControlAddIsRowsPercent(null);
                    }));

        form.Controls.Add(mainTable);
    }

    private TableLayoutPanel EventCard(EventEntity eventItem)
    {

        var titleLabel = FactoryElements.LinkLabelTitle(eventItem.Title, 
            () => new ShowEventDetails(eventItem).ShowDialog());

        var dateLocationLabel = FactoryElements.Label_10($"{eventItem.Date:dd.MM.yyyy HH:mm} • {eventItem.Location}")
            .With(l => l.ForeColor = Color.DarkGreen);

        var categoryOrganizerLabel = FactoryElements.Label_10($"{eventItem.Category} • {eventItem.Organizer}")
            .With(l => l.ForeColor = Color.Gray);

        var descriptionLabel = FactoryElements.Label_10(eventItem.Description)
            .With(l => l.ForeColor = Color.Black);

        var participantsLabel = FactoryElements.Label_10($"Участники: {eventItem.CurrentParticipants}/{eventItem.MaxParticipants}")
            .With(l => l.ForeColor = Color.DarkOrange);

        var registerLink = FactoryElements.LinkLabel_10("Зарегистрироваться →", 
            () => Validatoreg.OpenLink(eventItem.RegistrationLink));

        return FactoryElements.TableLayoutPanel()
            .With(t => t.BorderStyle = BorderStyle.FixedSingle)
            .With(t => t.Padding = new Padding(15))
            .ControlAddIsRowsAbsolute(titleLabel, 50)
            .ControlAddIsRowsAbsolute(dateLocationLabel, 35)
            .ControlAddIsRowsAbsolute(categoryOrganizerLabel, 35)
            .ControlAddIsRowsAbsolute(descriptionLabel, 60)
            .ControlAddIsRowsAbsolute(participantsLabel, 35)
            .ControlAddIsRowsAbsolute(registerLink, 35);
    }
}
