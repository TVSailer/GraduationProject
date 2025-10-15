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
    {
        var reviewsForm = new Form
        {
            Text = $"Отзывы - {club.Name}",
            Size = new Size(600, 500),
            StartPosition = FormStartPosition.CenterParent,
            Padding = new Padding(20),
            FormBorderStyle = FormBorderStyle.FixedDialog,
        };

        var titleLabel = new Label
        {
            Text = $"Отзывы о кружке \"{club.Name}\"",
            Font = style.TitleFont,
            Dock = DockStyle.Top,
            Height = 30,
            TextAlign = ContentAlignment.MiddleCenter
        };

        var ratingLabel = new Label
        {
            Text = $"Средняя оценка: ★ {club.Rating:0.0} ({club.ReviewCount} отзывов)",
            Font = new Font(style.Font, FontStyle.Bold),
            Dock = DockStyle.Top,
            Height = 25,
            TextAlign = ContentAlignment.MiddleCenter,
            ForeColor = Color.DarkOrange
        };

        var reviewsPanel = new Panel
        {
            Dock = DockStyle.Fill,
            AutoScroll = true
        };

        int yPosition = 10;
        foreach (var review in club.Reviews.OrderByDescending(r => r.Date))
        {
            var reviewCard = CreateReviewCard(review, reviewsPanel.Width - 40, yPosition);
            reviewsPanel.Controls.Add(reviewCard);
            yPosition += reviewCard.Height + 10;
        }
        reviewsPanel.Height = yPosition;

        var buttonsPanel = new Panel
        {
            Dock = DockStyle.Bottom,
            Height = 40
        };

        var addReviewButton = elementFactory.CreateButton("Добавить отзыв");
        addReviewButton.Size = new Size(120, 30);
        addReviewButton.Location = new Point(10, 5);
        addReviewButton.Click += (s, e) =>
        {
            ShowAddingReviewForm(club);
        };

        var closeButton = elementFactory.CreateButton("Закрыть");
        closeButton.Size = new Size(100, 30);
        closeButton.Location = new Point(140, 5);
        closeButton.Click += (s, e) => reviewsForm.Close();

        buttonsPanel.Controls.Add(addReviewButton);
        buttonsPanel.Controls.Add(closeButton);

        reviewsForm.Controls.Add(reviewsPanel);
        reviewsForm.Controls.Add(ratingLabel);
        reviewsForm.Controls.Add(titleLabel);
        reviewsForm.Controls.Add(buttonsPanel);

        reviewsForm.ShowDialog();
    }

    private Panel CreateReviewCard(Review review, int width, int yPosition)
    {
        var card = new Panel
        {
            Location = new Point(0, yPosition),
            Size = new Size(width, 100),
            BorderStyle = BorderStyle.FixedSingle,
            Padding = new Padding(10)
        };

        var authorLabel = new Label
        {
            Text = review.Author,
            Font = new Font(style.Font, FontStyle.Bold),
            Location = new Point(10, 10),
            Size = new Size(200, 20)
        };

        var dateLabel = new Label
        {
            Text = review.Date.ToString("dd.MM.yyyy HH:mm"),
            Font = new Font(style.Font, FontStyle.Italic),
            Location = new Point(220, 10),
            Size = new Size(150, 20),
            ForeColor = Color.Gray
        };

        var ratingLabel = new Label
        {
            Text = $"Оценка: {new string('★', review.Rating)}{new string('☆', 5 - review.Rating)}",
            Font = new Font(style.Font, FontStyle.Regular),
            Location = new Point(10, 35),
            Size = new Size(200, 20),
            ForeColor = Color.DarkOrange
        };

        var commentLabel = new Label
        {
            Text = review.Comment,
            Font = style.Font,
            Location = new Point(10, 60),
            Size = new Size(width - 40, 30)
        };

        card.Controls.AddRange(new Control[] { authorLabel, dateLabel, ratingLabel, commentLabel });

        return card;
    }

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
