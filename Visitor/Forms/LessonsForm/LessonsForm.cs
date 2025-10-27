using DataAccess.Postgres.Models;
using Logica;
using Logica.Extension;

public partial class ViewVisitor : Form
{
    private List<LessonEntity> clubs = new();
    public Action ActionUpdateReviewClub;

    private void LoadLessonsMenuStrip()
    {
        Controls.Clear();

        Controls.Add(elementFactory
            .CreateTableLayoutPanel()
            .ControlAddIsRowsAbsolute(menuStrip, 25)
            .ControlAddIsRowsAbsolute(
                elementFactory
                    .CreateTableLayoutPanel()
                    .ControlAddIsColumnPercent(
                        new Label()
                            .Do(l => l.Text = "Кружки и секции")
                            .Do(l => l.Font = style.TitleFont)
                            .Do(l => l.TextAlign = ContentAlignment.MiddleLeft)
                            .Do(l => l.Dock = DockStyle.Fill)
                            .Do(l => l.ForeColor = Color.DarkBlue), 100)
            .ControlAddIsColumnAbsolute(
                null, 120), 70)
            .ControlAddIsRowsPercent(
                displayItems = new Panel()
                        .Do(p => p.Dock = DockStyle.Top)
                        .Do(p => p.AutoSize = true)
                        .Do(p => p.AutoScroll = true), 100));

        LoadTestClubs();
    }

    private TableLayoutPanel CreateClubCard(LessonEntity club, int yPosition) 
        => new TableLayoutPanel()
            .Do(t => t.Location = new Point(0, yPosition))
            .Do(t => t.Size = new Size(displayItems.Width - 25, 200))
            .Do(t => t.BorderStyle = BorderStyle.FixedSingle)
            .Do(t => t.Padding = new Padding(15))
            .ControlAddIsRowsAbsolute(
                new LinkLabel()
                    .Do(l => l.Text = club.Name)
                    .Do(l => l.Font = style.TitleFont)
                    .Do(l => l.LinkColor = Color.DarkBlue)
                    .Do(l => l.Dock = DockStyle.Fill)
                    .Do(l => l.LinkBehavior = LinkBehavior.HoverUnderline)
                    .Do(l => l.Click += (s, e) => new ShowClubDetails(club, this).ShowDialog()), 25)
            .ControlAddIsRowsAbsolute(
                new LinkLabel()
                    .Do(l => l.Text = $"★ {club.Rating:0.0} ({club.ReviewCount} отзывов)")
                    .Do(l => l.Font = new Font(style.Font, FontStyle.Bold))
                    .Do(l => l.LinkColor = Color.DarkOrange)
                    .Do(l => l.Dock = DockStyle.Fill)
                    .Do(l => l.LinkBehavior = LinkBehavior.HoverUnderline)
                    .Do(l => l.Click += (s, e) => ShowClubReviews(club)), 20)
            .ControlAddIsRowsAbsolute(
                new Label()
                    .Do(l => l.Text = $"{club.Schedule} • {club.Location}")
                    .Do(l => l.Font = new Font(style.Font, FontStyle.Regular))
                    .Do(l => l.ForeColor = Color.DarkGreen)
                    .Do(l => l.Dock = DockStyle.Fill), 20)
            .ControlAddIsRowsAbsolute(
                new Label()
                    .Do(l => l.Text = $"Руководитель: {club.Teacher} • {club.Category}")
                    .Do(l => l.Font = new Font(style.Font, FontStyle.Italic))
                    .Do(l => l.ForeColor = Color.Gray)
                    .Do(l => l.Dock = DockStyle.Fill), 18)
            .ControlAddIsRowsAbsolute(
                new Label()
                    .Do(l => l.Text = club.Description)
                    .Do(l => l.Font = style.Font)
                    .Do(l => l.ForeColor = Color.Black)
                    .Do(l => l.Dock = DockStyle.Fill), 70)
            .ControlAddIsRowsAbsolute(
                new Label()
                    .Do(l => l.Text = $"Участники: {club.CurrentParticipants}/{club.MaxParticipants}")
                    .Do(l => l.Font = new Font(style.Font, FontStyle.Regular))
                    .Do(l => l.ForeColor = Color.DarkBlue)
                    .Do(l => l.Dock = DockStyle.Fill), 20);

    public void ShowClubReviews(LessonEntity club)
        => new ShowCLubReviews(club, this).ShowDialog();

    public void ShowAddingReviewForm(LessonEntity club)
        => new ShowAddReviewForm(club, this).ShowDialog();

    private void UpdateListReviewClub(ReviewEntity review, string clubName)
    {
        var club = clubs.FirstOrDefault(c => c.Name == clubName);

        club.Reviews.Add(review);
        club.ReviewCount = club.Reviews.Count;
        club.Rating = club.Reviews.Average(r => r.Rating);

        LogicaMessage.MessageInfo("Отзыв успешно добавлен!");

        ActionUpdateReviewClub?.Invoke();
    }
}
