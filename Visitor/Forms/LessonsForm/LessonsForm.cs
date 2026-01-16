//using DataAccess.Postgres.Models;
//using Logica;
//using Logica.Extension;

//public partial class VisitorView : Form
//{
//    private List<LessonEntity> clubs = new();
//    public Action ActionUpdateReviewClub;

//    private void LoadLessonsMenuStrip()
//    {
//        Controls.Clear();

//        Controls.Add(elementFactory
//            .CreateTableLayoutPanel()
//            .ControlAddIsRow(menuStrip, 25)
//            .ControlAddIsRow(
//                elementFactory
//                    .CreateTableLayoutPanel()
//                    .ControlAddIsColumnPercent(
//                        new Label()
//                            .With(l => l.Text = "Кружки и секции")
//                            .With(l => l.Font = style.TitleFont)
//                            .With(l => l.TextAlign = ContentAlignment.MiddleLeft)
//                            .With(l => l.Dock = DockStyle.Fill)
//                            .With(l => l.ForeColor = Color.DarkBlue), 100)
//            .ControlAddIsColumnAbsolute(
//                null, 120), 70)
//            .ControlAddIsRowsPercent(
//                displayItems = new Panel()
//                        .With(p => p.Dock = DockStyle.Top)
//                        .With(p => p.AutoSize = true)
//                        .With(p => p.AutoScroll = true), 100));

//        LoadTestClubs();
//    }

//    private TableLayoutPanel CreateClubCard(LessonEntity club, int yPosition) 
//        => new TableLayoutPanel()
//            .With(t => t.Location = new Point(0, yPosition))
//            .With(t => t.Size = new Size(displayItems.Width - 25, 200))
//            .With(t => t.BorderStyle = BorderStyle.FixedSingle)
//            .With(t => t.Padding = new Padding(15))
//            .ControlAddIsRow(
//                new LinkLabel()
//                    .With(l => l.Text = club.Name)
//                    .With(l => l.Font = style.TitleFont)
//                    .With(l => l.LinkColor = Color.DarkBlue)
//                    .With(l => l.Dock = DockStyle.Fill)
//                    .With(l => l.LinkBehavior = LinkBehavior.HoverUnderline)
//                    .With(l => l.Click += (s, e) => new ShowClubDetails(club, this).ShowDialog()), 25)
//            .ControlAddIsRow(
//                new LinkLabel()
//                    .With(l => l.Text = $"★ {club.Rating:0.0} ({club.ReviewCount} отзывов)")
//                    .With(l => l.Font = new Font(style.Font, FontStyle.Bold))
//                    .With(l => l.LinkColor = Color.DarkOrange)
//                    .With(l => l.Dock = DockStyle.Fill)
//                    .With(l => l.LinkBehavior = LinkBehavior.HoverUnderline)
//                    .With(l => l.Click += (s, e) => ShowClubReviews(club)), 20)
//            .ControlAddIsRow(
//                new Label()
//                    .With(l => l.Text = $"{club.Schedule} • {club.Location}")
//                    .With(l => l.Font = new Font(style.Font, FontStyle.Regular))
//                    .With(l => l.ForeColor = Color.DarkGreen)
//                    .With(l => l.Dock = DockStyle.Fill), 20)
//            .ControlAddIsRow(
//                new Label()
//                    .With(l => l.Text = $"Руководитель: {club.Teacher} • {club.Category}")
//                    .With(l => l.Font = new Font(style.Font, FontStyle.Italic))
//                    .With(l => l.ForeColor = Color.Gray)
//                    .With(l => l.Dock = DockStyle.Fill), 18)
//            .ControlAddIsRow(
//                new Label()
//                    .With(l => l.Text = club.Description)
//                    .With(l => l.Font = style.Font)
//                    .With(l => l.ForeColor = Color.Black)
//                    .With(l => l.Dock = DockStyle.Fill), 70)
//            .ControlAddIsRow(
//                new Label()
//                    .With(l => l.Text = $"Участники: {club.CurrentParticipants}/{club.MaxParticipants}")
//                    .With(l => l.Font = new Font(style.Font, FontStyle.Regular))
//                    .With(l => l.ForeColor = Color.DarkBlue)
//                    .With(l => l.Dock = DockStyle.Fill), 20);

//    public void ShowClubReviews(LessonEntity club)
//        => new ShowCLubReviews(club, this).ShowDialog();

//    public void ShowAddingReviewForm(LessonEntity club)
//        => new ShowAddReviewForm(club, this).ShowDialog();

//    private void UpdateListReviewClub(ReviewEntity review, string clubName)
//    {
//        var club = clubs.FirstOrDefault(c => c.Name == clubName);

//        club.Reviews.Add(review);
//        club.ReviewCount = club.Reviews.Count;
//        club.Rating = club.Reviews.Average(r => r.Rating);

//        LogicaMessage.MessageInfo("Отзыв успешно добавлен!");

//        ActionUpdateReviewClub?.Invoke();
//    }
//}
