using Logica;

public partial class ViewVisitor : Form
{
    private List<Club> clubs = new List<Club>();
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
            .AddingRowsStyles(
                new RowStyle(SizeType.Absolute, 25),
                new RowStyle(SizeType.Absolute, 20),
                new RowStyle(SizeType.Absolute, 20),
                new RowStyle(SizeType.Absolute, 18),
                new RowStyle(SizeType.Absolute, 70),
                new RowStyle(SizeType.Absolute, 20))
            .ControlsAdd(titleLabel, 0, 0)
            .ControlsAdd(ratingLabel, 0, 1)
            .ControlsAdd(scheduleLabel, 0, 2)
            .ControlsAdd(leaderLabel, 0, 3)
            .ControlsAdd(descriptionLabel, 0, 4)
            .ControlsAdd(participantsLabel, 0, 5);

        return tableCard;
    }

    private void ShowClubDetailing(Club club)
        => new ShowClubDetails(club, this).ShowDialog();

    private void ShowClubReviews(Club club)
        => new ShowCLubReviews(club, this).ShowDialog();

    

    private void ShowAddingReviewForm(Club club)
        => new ShowAddReviewForm(club, this).ShowDialog();

    public void SubmitReview(ShowAddReviewForm showAddReviewForm)
    {
        if (string.IsNullOrWhiteSpace(showAddReviewForm.UserName))
        {
            MessageBox.Show("Введите ваше имя", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (string.IsNullOrWhiteSpace(showAddReviewForm.UserComent))
        {
            MessageBox.Show("Введите комментарий", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var review = new Review
        {
            Author = showAddReviewForm.UserName,
            Date = DateTime.Now,
            Rating = showAddReviewForm.UserRating + 1,
            Comment = showAddReviewForm.UserComent
        };

        var club = clubs.FirstOrDefault(c => c.Name == showAddReviewForm.Club.Name);

        club.Reviews.Add(review);
        club.ReviewCount = club.Reviews.Count;
        club.Rating = club.Reviews.Average(r => r.Rating);

        MessageBox.Show("Отзыв успешно добавлен!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
        showAddReviewForm.Close();
        DisplayItems(clubs.ToArray(), CreateClubCard); // Обновляем список кружков
    }
}
