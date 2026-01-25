using DataAccess.Postgres.Models;
using Logica;

public class ShowEventDetails : Form
{
    private EventEntity eventItem;

    public ShowEventDetails(EventEntity eventItem)
    {
        this.eventItem = eventItem;
        Init(eventItem);

        var titleLabel = new Label
        {
            Text = eventItem.Title,
            Font = FactoryElements.Style.TitleFont,
            Dock = DockStyle.Top,
            TextAlign = ContentAlignment.MiddleCenter
        };

        var infoLabel = new Label
        {
            Text = $"{eventItem.Date:dd.MM.yyyy HH:mm} • {eventItem.Location}",
            Font = new Font(FactoryElements.Style.Font, FontStyle.Bold),
            Dock = DockStyle.Top,
            TextAlign = ContentAlignment.MiddleCenter,
            ForeColor = Color.DarkGreen
        };

        var detailsLabel = new Label
        {
            Text = $"Организатор: {eventItem.Organizer}\nКатегория: {eventItem.Category}\nУчастники: {eventItem.CurrentParticipants}/{eventItem.MaxParticipants}",
            Font = FactoryElements.Style.Font,
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

        var registerLink = new LinkLabel
        {
            Text = "Перейти к регистрации на мероприятие →",
            Font = new Font(FactoryElements.Style.Font, FontStyle.Bold),
            LinkColor = Color.Blue,
            LinkBehavior = LinkBehavior.AlwaysUnderline,
            Dock = DockStyle.Fill,
            TextAlign = ContentAlignment.MiddleCenter
        };
        registerLink.Click += (s, e) => Validatoreg.TryOpenLink(eventItem.RegistrationLink);

        var mainTable = FactoryElements
            .CreateTableLayoutPanel()
            .ControlAddIsRowsAbsolute(titleLabel, 30)
            .ControlAddIsRowsAbsolute(infoLabel, 25)
            .ControlAddIsRowsAbsolute(detailsLabel, 60)
            .ControlAddIsRowsPercent(descriptionText, 40)
            .ControlAddIsRowsAbsolute(registerLink, 25)
            .ControlAddIsRowsAbsolute(FactoryElements
                .CreateButton(
                    Attributes.Close, Close), 40);

        Controls.Add(mainTable);
    }

    private void Init(EventEntity eventItem)
    {
        Text = eventItem.Title;
        Size = new Size(600, 500);
        StartPosition = FormStartPosition.CenterParent;
        Padding = new Padding(20);
        FormBorderStyle = FormBorderStyle.FixedDialog;
    }
}
