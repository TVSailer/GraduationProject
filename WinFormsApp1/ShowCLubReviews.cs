using Logica;

public partial class ViewVisitor
{
    public class ShowCLubReviews : Form
    {
        public ShowCLubReviews(Club club, ViewVisitor viewVisitor)
        {
            Init(club);

            FactoryElements.Style = new VisitorViewStyle();

            var titleLabel = new Label
            {
                Text = $"Отзывы о кружке \"{club.Name}\"",
                Font = FactoryElements.Style.TitleFont,
                Dock = DockStyle.Top,
                TextAlign = ContentAlignment.MiddleCenter
            };

            var ratingLabel = new Label
            {
                Text = $"Средняя оценка: ★ {club.Rating:0.0} ({club.ReviewCount} отзывов)",
                Font = new Font(FactoryElements.Style.Font, FontStyle.Bold),
                Dock = DockStyle.Top,
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = Color.DarkOrange
            };

            var mainTable = FactoryElements.CreateTableLayoutPanel()
                .ControlAddIsRowsAbsolute(titleLabel, 30)
                .ControlAddIsRowsAbsolute(ratingLabel, 25)
                .ControlAddIsRowsAbsolute(CreadCardsReviews(club), 300)
                .ControlAddIsRowsAbsolute(FactoryElements
                    .CreateButton("Добавить отзыв", viewVisitor.ShowAddingReviewForm, club), 40)
                .ControlsAdd(new Panel(), 0, 4);

            Controls.Add(mainTable);
        }

        private Panel CreadCardsReviews(Club club)
        {
            var reviewsPanel = new Panel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true
            };

            int yPosition = 10;
            foreach (var review in club.Reviews.OrderByDescending(r => r.Date))
            {
                var reviewCard = CreateReviewCard(review, yPosition);
                reviewsPanel.Controls.Add(reviewCard);
                yPosition += reviewCard.Height;
            }
            reviewsPanel.Height = yPosition;

            return reviewsPanel;
        }

        public void Init(Club club)
        {
            Text = $"Отзывы - {club.Name}";
            Size = new Size(600, 500);
            StartPosition = FormStartPosition.CenterParent;
            Padding = new Padding(20);
            FormBorderStyle = FormBorderStyle.FixedDialog;
        }

        private Panel CreateReviewCard(Review review, int yPosition)
        {
            var authorLabel = new Label
            {
                Text = review.Author,
                Font = new Font(FactoryElements.Style.Font, FontStyle.Bold),
                Dock = DockStyle.Fill
            };

            var dateLabel = new Label
            {
                Text = review.Date.ToString("dd.MM.yyyy HH:mm"),
                Font = new Font(FactoryElements.Style.Font, FontStyle.Italic),
                ForeColor = Color.Gray,
                Dock = DockStyle.Fill
            };

            var ratingLabel = new Label
            {
                Text = $"Оценка: {new string('★', review.Rating)}{new string('☆', 5 - review.Rating)}",
                Font = new Font(FactoryElements.Style.Font, FontStyle.Regular),
                ForeColor = Color.DarkOrange,
                Dock = DockStyle.Fill
            };

            var commentLabel = new Label
            {
                Text = review.Comment,
                Font = FactoryElements.Style.Font,
                Dock = DockStyle.Fill
            };

            return new TableLayoutPanel{
                BorderStyle = BorderStyle.FixedSingle,
                Dock = DockStyle.Top}
                .ControlAddIsRowsAbsolute(authorLabel, 20)
                .ControlAddIsRowsAbsolute(dateLabel, 20)
                .ControlAddIsRowsAbsolute(ratingLabel, 20)
                .ControlAddIsRowsAbsolute(commentLabel, 200);
        }
    }
}
