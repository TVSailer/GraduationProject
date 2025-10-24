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
        titleLabel.Click += (s, e) => ShowEventDetails(eventItem);

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
        registerLink.Click += (s, e) => OpenRegistrationLink(eventItem.RegistrationLink);

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

    private void ShowEventDetails(EventItem eventItem)
    {
        var detailsForm = new Form
        {
            Text = eventItem.Title,
            Size = new Size(600, 500),
            StartPosition = FormStartPosition.CenterParent,
            Padding = new Padding(20),
            FormBorderStyle = FormBorderStyle.FixedDialog,
        };

        var titleLabel = new Label
        {
            Text = eventItem.Title,
            Font = style.TitleFont,
            Dock = DockStyle.Top,
            Height = 30,
            TextAlign = ContentAlignment.MiddleCenter
        };

        var infoLabel = new Label
        {
            Text = $"{eventItem.Date:dd.MM.yyyy HH:mm} • {eventItem.Location}",
            Font = new Font(style.Font, FontStyle.Bold),
            Dock = DockStyle.Top,
            Height = 25,
            TextAlign = ContentAlignment.MiddleCenter,
            ForeColor = Color.DarkGreen
        };

        var detailsLabel = new Label
        {
            Text = $"Организатор: {eventItem.Organizer}\nКатегория: {eventItem.Category}\nУчастники: {eventItem.CurrentParticipants}/{eventItem.MaxParticipants}",
            Font = style.Font,
            Dock = DockStyle.Top,
            Height = 60,
            TextAlign = ContentAlignment.MiddleLeft
        };

        var descriptionText = new TextBox
        {
            Font = new Font(Font.FontFamily, 12),
            Text = eventItem.Description,
            Multiline = true,
            ReadOnly = true,
            Dock = DockStyle.Fill,
            ScrollBars = ScrollBars.Vertical,
            BorderStyle = BorderStyle.None,
            BackColor = SystemColors.Window
        };

        var registerPanel = new Panel
        {
            Dock = DockStyle.Bottom,
            Height = 50
        };

        var registerLink = new LinkLabel
        {
            Text = "Перейти к регистрации на мероприятие →",
            Font = new Font(style.Font, FontStyle.Bold),
            LinkColor = Color.Blue,
            LinkBehavior = LinkBehavior.AlwaysUnderline,
            Dock = DockStyle.Fill,
            TextAlign = ContentAlignment.MiddleCenter
        };
        registerLink.Click += (s, e) => OpenRegistrationLink(eventItem.RegistrationLink);

        var closeButton = elementFactory.CreateButton("Закрыть");
        closeButton.Dock = DockStyle.Bottom;
        closeButton.Click += (s, e) => detailsForm.Close();

        registerPanel.Controls.Add(registerLink);

        detailsForm.Controls.Add(descriptionText);
        detailsForm.Controls.Add(detailsLabel);
        detailsForm.Controls.Add(infoLabel);
        detailsForm.Controls.Add(titleLabel);
        detailsForm.Controls.Add(registerPanel);
        detailsForm.Controls.Add(closeButton);

        detailsForm.ShowDialog();
    }

    private void OpenRegistrationLink(string url)
    {
        try
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = url,
                UseShellExecute = true
            });
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Не удалось открыть ссылку: {ex.Message}", "Ошибка",
                          MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}

public class EventItem
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; set; }
    public string Location { get; set; }
    public string Category { get; set; }
    public string RegistrationLink { get; set; }
    public string Organizer { get; set; }
    public int MaxParticipants { get; set; }
    public int CurrentParticipants { get; set; }
}
