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
            .ControlAddIsColumnPercentV2(null, 25)
            .ControlAddIsColumnAbsoluteV2(null, 600)
            .ControlAddIsRowsAbsoluteV2(FactoryElements.LabelTitle(""), 70)
            .ControlAddIsRowsAbsoluteV2(Button("👤 Профиль"), 50)
            .ControlAddIsRowsAbsoluteV2(Button("📰 Новости"), 50)
            .ControlAddIsRowsAbsoluteV2(Button("🎭 Мероприятиями", DataContext, "OnLoadEventsView"), 50)
            .ControlAddIsRowsAbsoluteV2(Button("🎨 Кружки"), 50)
            .ControlAddIsRowsAbsoluteV2(Button("📊 Посещаемоть"), 50)
            .ControlAddIsColumnPercentV2(null, 25)
            .ControlAddIsRowsPercentV2(null, 25);

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
            .ControlAddIsRowsAbsoluteV2(titleLabel, 70)
            .ControlAddIsRowsPercentV2(
                FactoryElements.TableLayoutPanel()
                .With(
                    t => 
                    {
                        entitys.ForEach(e => t.ControlAddIsRowsAbsoluteV2(EventCard(e), 270));
                        t.ControlAddIsRowsPercentV2(null);
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
            .ControlAddIsRowsAbsoluteV2(titleLabel, 50)
            .ControlAddIsRowsAbsoluteV2(dateLocationLabel, 35)
            .ControlAddIsRowsAbsoluteV2(categoryOrganizerLabel, 35)
            .ControlAddIsRowsAbsoluteV2(descriptionLabel, 60)
            .ControlAddIsRowsAbsoluteV2(participantsLabel, 35)
            .ControlAddIsRowsAbsoluteV2(registerLink, 35);
    }
}
