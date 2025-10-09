using Logica;

public partial class ViewVisitor : Form
{
    private List<Club> clubs = new List<Club>();
    private void LoadLessonsMenuStrip()
    {
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
            new RowStyle(SizeType.Absolute, 10),
            new RowStyle(SizeType.Absolute, 70),
            new RowStyle(SizeType.Percent, 100F))
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
        titleLabel.Click += (s, e) => ShowClubDetails(club);

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

    private void ShowClubDetails(Club club)
    {
        var detailsForm = new Form
        {
            Text = club.Name,
            Size = new Size(700, 600),
            StartPosition = FormStartPosition.CenterParent,
            Padding = new Padding(20),
            FormBorderStyle = FormBorderStyle.FixedDialog,
        };

        var titleLabel = new Label
        {
            Text = club.Name,
            Font = style.TitleFont,
            Dock = DockStyle.Top,
            Height = 30,
            TextAlign = ContentAlignment.MiddleCenter
        };

        var ratingLabel = new Label
        {
            Text = $"★ {club.Rating:0.0} • {club.ReviewCount} отзывов • {club.CurrentParticipants}/{club.MaxParticipants} участников",
            Font = new Font(style.Font, FontStyle.Bold),
            Dock = DockStyle.Top,
            Height = 25,
            TextAlign = ContentAlignment.MiddleCenter,
            ForeColor = Color.DarkOrange,
        };

        var infoLabel = new Label
        {
            Text = $"Руководитель: {club.Leader}\nРасписание: {club.Schedule}\nМесто: {club.Location}\nКатегория: {club.Category}",
            Font = style.Font,
            Dock = DockStyle.Top,
            Height = 80,
            TextAlign = ContentAlignment.MiddleLeft
        };

        var descriptionText = new TextBox
        {
            Font = new Font(Font.FontFamily, 11),
            Text = club.Description,
            Multiline = true,
            ReadOnly = true,
            Dock = DockStyle.Fill,
            ScrollBars = ScrollBars.Vertical,
            BorderStyle = BorderStyle.FixedSingle,
            BackColor = SystemColors.Window
        };

        var buttonsPanel = new Panel
        {
            Dock = DockStyle.Bottom,
            Height = 40
        };

        var reviewsButton = elementFactory.CreateButton("Посмотреть отзывы");
        reviewsButton.Size = new Size(150, 30);
        reviewsButton.Location = new Point(10, 5);
        reviewsButton.Click += (s, e) =>
        {
            ShowClubReviews(club);
        };

        var addReviewButton = elementFactory.CreateButton("Добавить отзыв");
        addReviewButton.Size = new Size(150, 30);
        addReviewButton.Location = new Point(170, 5);
        addReviewButton.Click += (s, e) => ShowAddReviewForm(club);

        var closeButton = elementFactory.CreateButton("Закрыть");
        closeButton.Size = new Size(100, 30);
        closeButton.Location = new Point(330, 5);
        closeButton.Click += (s, e) => detailsForm.Close();

        buttonsPanel.Controls.AddRange(new Control[] { reviewsButton, addReviewButton, closeButton });

        detailsForm.Controls.Add(descriptionText);
        detailsForm.Controls.Add(infoLabel);
        detailsForm.Controls.Add(ratingLabel);
        detailsForm.Controls.Add(titleLabel);
        detailsForm.Controls.Add(buttonsPanel);

        detailsForm.ShowDialog();
    }

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
            reviewsForm.Close();
            ShowAddReviewForm(club);
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

    private void ShowAddReviewForm(Club club = null)
    {
        var reviewForm = new Form
        {
            Text = "Добавить отзыв",
            Size = new Size(500, 400),
            StartPosition = FormStartPosition.CenterParent,
            Padding = new Padding(20),
            FormBorderStyle = FormBorderStyle.FixedDialog,
        };

        var titleLabel = new Label
        {
            Text = club != null ? $"Отзыв о кружке \"{club.Name}\"" : "Новый отзыв",
            Font = style.TitleFont,
            Dock = DockStyle.Top,
            Height = 30,
            TextAlign = ContentAlignment.MiddleCenter
        };

        var clubCombo = new ComboBox
        {
            Dock = DockStyle.Top,
            Height = 30,
            DropDownStyle = ComboBoxStyle.DropDownList
        };
        clubCombo.Items.AddRange(clubs.Select(c => c.Name).ToArray());

        if (club != null)
            clubCombo.SelectedItem = club.Name;

        var ratingPanel = new Panel
        {
            Dock = DockStyle.Top,
            Height = 40
        };

        var ratingLabel = new Label
        {
            Text = "Оценка:",
            Location = new Point(10, 10),
            Size = new Size(60, 20),
            Font = style.Font
        };

        var ratingCombo = new ComboBox
        {
            Location = new Point(80, 8),
            Size = new Size(100, 20),
            DropDownStyle = ComboBoxStyle.DropDownList
        };
        ratingCombo.Items.AddRange(new object[] { "1", "2", "3", "4", "5" });
        ratingCombo.SelectedIndex = 4; // 5 по умолчанию

        ratingPanel.Controls.Add(ratingLabel);
        ratingPanel.Controls.Add(ratingCombo);

        var authorLabel = new Label
        {
            Text = "Ваше имя:",
            Dock = DockStyle.Top,
            Height = 20,
            Font = style.Font
        };

        var authorBox = new TextBox
        {
            Dock = DockStyle.Top,
            Height = 30
        };

        var commentLabel = new Label
        {
            Text = "Комментарий:",
            Dock = DockStyle.Top,
            Height = 20,
            Font = style.Font
        };

        var commentBox = new TextBox
        {
            Dock = DockStyle.Fill,
            Multiline = true,
            ScrollBars = ScrollBars.Vertical
        };

        var buttonsPanel = new Panel
        {
            Dock = DockStyle.Bottom,
            Height = 40
        };

        var submitButton = elementFactory.CreateButton("Отправить");
        submitButton.Size = new Size(100, 30);
        submitButton.Location = new Point(10, 5);
        submitButton.Click += (s, e) => SubmitReview(clubCombo, ratingCombo, authorBox, commentBox, reviewForm);

        var cancelButton = elementFactory.CreateButton("Отмена");
        cancelButton.Size = new Size(100, 30);
        cancelButton.Location = new Point(120, 5);
        cancelButton.Click += (s, e) => reviewForm.Close();

        buttonsPanel.Controls.Add(submitButton);
        buttonsPanel.Controls.Add(cancelButton);

        if (club == null)
        {
            reviewForm.Controls.Add(clubCombo);
        }

        reviewForm.Controls.Add(commentBox);
        reviewForm.Controls.Add(commentLabel);
        reviewForm.Controls.Add(authorBox);
        reviewForm.Controls.Add(authorLabel);
        reviewForm.Controls.Add(ratingPanel);
        reviewForm.Controls.Add(titleLabel);
        reviewForm.Controls.Add(buttonsPanel);

        reviewForm.ShowDialog();
    }

    private void SubmitReview(ComboBox clubCombo, ComboBox ratingCombo, TextBox authorBox, TextBox commentBox, Form form)
    {
        if (clubCombo.SelectedItem == null)
        {
            MessageBox.Show("Выберите кружок", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (string.IsNullOrWhiteSpace(authorBox.Text))
        {
            MessageBox.Show("Введите ваше имя", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (string.IsNullOrWhiteSpace(commentBox.Text))
        {
            MessageBox.Show("Введите комментарий", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var club = clubs.FirstOrDefault(c => c.Name == clubCombo.SelectedItem.ToString());
        if (club != null)
        {
            var review = new Review
            {
                Author = authorBox.Text,
                Date = DateTime.Now,
                Rating = ratingCombo.SelectedIndex + 1,
                Comment = commentBox.Text
            };

            club.Reviews.Add(review);
            club.ReviewCount = club.Reviews.Count;
            club.Rating = club.Reviews.Average(r => r.Rating);

            MessageBox.Show("Отзыв успешно добавлен!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            form.Close();
            DisplayItems(clubs.ToArray(), CreateClubCard); // Обновляем список кружков
        }
    }
}

public class Club
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Category { get; set; }
    public string Leader { get; set; }
    public string Schedule { get; set; }
    public string Location { get; set; }
    public int MaxParticipants { get; set; }
    public int CurrentParticipants { get; set; }
    public double Rating { get; set; }
    public int ReviewCount { get; set; }
    public List<Review> Reviews { get; set; } = new List<Review>();
}

public class Review
{
    public string Author { get; set; }
    public DateTime Date { get; set; }
    public int Rating { get; set; }
    public string Comment { get; set; }
}