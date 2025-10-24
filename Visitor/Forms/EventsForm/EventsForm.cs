using Logica;

public partial class ViewVisitor : Form
{
    private void LoadEventsMenuStrip()
    {
        Controls.Clear();

        var titleLabel = new Label
        {
            Text = "Ближайшие мероприятия",
            Font = style.TitleFont,
            TextAlign = ContentAlignment.MiddleLeft,
            Dock = DockStyle.Fill,
            ForeColor = Color.DarkBlue
        };

        var headerPanel = elementFactory.CreateTableLayoutPanel()
            .AddingColumnsStyles(
            new ColumnStyle(SizeType.Percent, 100F),
            new ColumnStyle(SizeType.Absolute, 100))
            .ControlsAdd(titleLabel, 0, 0);

        displayItems = new Panel
        {
            Dock = DockStyle.Top,
            AutoSize = true,
            AutoScroll = true
        };

        var mainTable = elementFactory.CreateTableLayoutPanel()
            .AddingColumnsStyles()
            .AddingRowsStyles(
            new RowStyle(SizeType.Absolute, 25),
            new RowStyle(SizeType.Absolute, 70),
            new RowStyle(SizeType.Percent, 100F))
            .ControlsAdd(menuStrip, 0, 0)
            .ControlsAdd(headerPanel, 0, 1)
            .ControlsAdd(displayItems, 0, 2);

        Controls.Add(mainTable);
        LoadTestEvents();
    }

    private TableLayoutPanel CreateEventCard(EventItem eventItem, int yPosition)
    {
        var titleLabel = new LinkLabel
        {
            Text = eventItem.Title,
            Font = style.TitleFont,
            LinkColor = Color.DarkBlue,
            Dock = DockStyle.Fill,
            LinkBehavior = LinkBehavior.HoverUnderline
        };
        titleLabel.Click += (s, e) => new ShowEventDetails(eventItem).ShowDialog();

        var dateLocationLabel = new Label
        {
            Text = $"{eventItem.Date:dd.MM.yyyy HH:mm} • {eventItem.Location}",
            Font = new Font(style.Font, FontStyle.Bold),
            ForeColor = Color.DarkGreen,
            Dock = DockStyle.Fill
        };

        var categoryOrganizerLabel = new Label
        {
            Text = $"{eventItem.Category} • {eventItem.Organizer}",
            Font = new Font(style.Font, FontStyle.Italic),
            ForeColor = Color.Gray,
            Dock = DockStyle.Fill
        };

        var descriptionLabel = new Label
        {
            Text = eventItem.Description,
            Font = style.Font,
            ForeColor = Color.Black,
            Dock = DockStyle.Fill
        };

        var participantsLabel = new Label
        {
            Text = $"Участники: {eventItem.CurrentParticipants}/{eventItem.MaxParticipants}",
            Font = new Font(style.Font, FontStyle.Regular),
            ForeColor = Color.DarkOrange,
            Dock = DockStyle.Fill
        };

        var registerLink = new LinkLabel
        {
            Text = "Зарегистрироваться →",
            Font = new Font(style.Font, FontStyle.Bold),
            LinkColor = Color.Blue,
            Dock = DockStyle.Fill,
            LinkBehavior = LinkBehavior.AlwaysUnderline
        };
        registerLink.Click += (s, e) => Validatoreg.OpenRegistrationLink(eventItem.RegistrationLink);

        var tableCard = new TableLayoutPanel
        {
            Location = new Point(0, yPosition),
            Size = new Size(displayItems.Width - 25, 220),
            BorderStyle = BorderStyle.FixedSingle,
            Padding = new Padding(15),
        };

        tableCard
            .AddingRowsStyles(
                new RowStyle(SizeType.Absolute, 25),
                new RowStyle(SizeType.Absolute, 20),
                new RowStyle(SizeType.Absolute, 18),
                new RowStyle(SizeType.Absolute, 60),
                new RowStyle(SizeType.Absolute, 20),
                new RowStyle(SizeType.Absolute, 20))
            .ControlsAdd(titleLabel, 0, 0)
            .ControlsAdd(dateLocationLabel, 0, 1)
            .ControlsAdd(categoryOrganizerLabel, 0, 2)
            .ControlsAdd(descriptionLabel, 0, 3)
            .ControlsAdd(participantsLabel, 0, 4)
            .ControlsAdd(registerLink, 0, 5);

        return tableCard;
    }
}
