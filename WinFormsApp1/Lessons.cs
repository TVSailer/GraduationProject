using Logica;

public partial class ViewVisitor : Form
{
    private List<Club> clubs = new List<Club>();
    private Action ActionUpdateReviewClub;

    private void LoadLessonsMenuStrip()
    {
        Controls.Clear();

        var titleLabel = new Label
        {
            Text = "Кружки и секции",
            Font = style.TitleFont,
            TextAlign = ContentAlignment.MiddleLeft,
            Dock = DockStyle.Fill,
            ForeColor = Color.DarkBlue
        };

        var headerPanel = elementFactory.CreateTableLayoutPanel()
            .AddingColumnsStyles(
            new ColumnStyle(SizeType.Percent, 100F),
            new ColumnStyle(SizeType.Absolute, 120))
            .AddingRowsStyles()
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
        LoadTestClubs();
    }

    private TableLayoutPanel CreateClubCard(Club club, int yPosition)
    {
        var titleLabel = new LinkLabel
        {
            Text = club.Name,
            Font = style.TitleFont,
            LinkColor = Color.DarkBlue,
            Dock = DockStyle.Fill,
            LinkBehavior = LinkBehavior.HoverUnderline
        };
        titleLabel.Click += (s, e) => ShowClubDetailing(club);

        var ratingLabel = new LinkLabel
        {
            Text = $"★ {club.Rating:0.0} ({club.ReviewCount} отзывов)",
            Font = new Font(style.Font, FontStyle.Bold),
            LinkColor = Color.DarkOrange,
            Dock = DockStyle.Fill,
            LinkBehavior = LinkBehavior.HoverUnderline
        };
        ratingLabel.Click += (s, e) => ShowClubReviews(club);

        var scheduleLabel = new Label
        {
            Text = $"{club.Schedule} • {club.Location}",
            Font = new Font(style.Font, FontStyle.Regular),
            ForeColor = Color.DarkGreen,
            Dock = DockStyle.Fill
        };

        var leaderLabel = new Label
        {
            Text = $"Руководитель: {club.Leader} • {club.Category}",
            Font = new Font(style.Font, FontStyle.Italic),
            ForeColor = Color.Gray,
            Dock = DockStyle.Fill
        };

        var descriptionLabel = new Label
        {
            Text = club.Description,
            Font = style.Font,
            ForeColor = Color.Black,
            Dock = DockStyle.Fill
        };

        var participantsLabel = new Label
        {
            Text = $"Участники: {club.CurrentParticipants}/{club.MaxParticipants}",
            Font = new Font(style.Font, FontStyle.Regular),
            ForeColor = Color.DarkBlue,
            Dock = DockStyle.Fill
        };

        var tableCard = new TableLayoutPanel
        {
            Location = new Point(0, yPosition),
            Size = new Size(displayItems.Width - 25, 200),
            BorderStyle = BorderStyle.FixedSingle,
            Padding = new Padding(15),
        };

        tableCard
            .ControlAddIsRowsAbsolute(titleLabel, 25)
            .ControlAddIsRowsAbsolute(ratingLabel, 20)
            .ControlAddIsRowsAbsolute(scheduleLabel, 20)
            .ControlAddIsRowsAbsolute(leaderLabel, 18)
            .ControlAddIsRowsAbsolute(descriptionLabel, 70)
            .ControlAddIsRowsAbsolute(participantsLabel, 20);

        return tableCard;
    }

    private void ShowClubDetailing(Club club)
        => new ShowClubDetails(club, this).ShowDialog();

    private void ShowClubReviews(Club club)
        => new ShowCLubReviews(club, this).ShowDialog();

    private void ShowAddingReviewForm(Club club)
        => new ShowAddReviewForm(club, this).ShowDialog();
    private void UpdateListReviewClub(Review review, string clubName)
    {
        var club = clubs.FirstOrDefault(c => c.Name == clubName);

        club.Reviews.Add(review);
        club.ReviewCount = club.Reviews.Count;
        club.Rating = club.Reviews.Average(r => r.Rating);

        LogicaMessage.MessageInfo("Отзыв успешно добавлен!");

        ActionUpdateReviewClub?.Invoke();
    }
}
