using DataAccess.Postgres.Models;
using Logica;

public partial class ViewVisitor
{
    public class ShowClubDetails : Form
    {
        private BaseCreatingElements elementFactory;
        private BaseStyle style;

        public ShowClubDetails(LessonEntity club, ViewVisitor viewVisitor)
        {
            Init(club);

            style = new VisitorViewStyle();
            elementFactory = new CreatingElements(style);

            var titleLabel = new Label
            {
                Text = club.Name,
                Font = style.TitleFont,
                Dock = DockStyle.Top,
                TextAlign = ContentAlignment.MiddleCenter
            };

            var ratingLabel = new Label
            {
                Text = $"★ {club.Rating:0.0} • {club.ReviewCount} отзывов • {club.CurrentParticipants}/{club.MaxParticipants} участников",
                Font = new Font(style.Font, FontStyle.Bold),
                Dock = DockStyle.Top,
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = Color.DarkOrange,
            };

            var infoLabel = new Label
            {
                Text = $"Руководитель: {club.Name}\nРасписание: {club.Schedule}\nМесто: {club.Location}\nКатегория: {club.Category}",
                Font = style.Font,
                Dock = DockStyle.Fill,
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
                BorderStyle = BorderStyle.FixedSingle
            };

            var buttonTable = elementFactory
                .CreateTableLayoutPanel()
                .AddingRowsStyles(new RowStyle(SizeType.Absolute, 40))
                .AddingColumnsStyles(new ColumnStyle(SizeType.Percent, 30))
                .ControlAddIsColumnAbsolute(elementFactory
                    .CreateButton("Посмотреть отзыв", viewVisitor.ShowClubReviews, club), 150)
                .ControlAddIsColumnAbsolute(elementFactory
                    .CreateButton("Добавить отзыв", viewVisitor.ShowAddingReviewForm, club), 150);

            var mainTable = elementFactory.CreateTableLayoutPanel()
                .ControlAddIsRowsAbsolute(titleLabel, 30)
                .ControlAddIsRowsAbsolute(ratingLabel, 25)
                .ControlAddIsRowsAbsolute(infoLabel, 100)
                .ControlAddIsRowsAbsolute(descriptionText, 300)
                .ControlAddIsRowsAbsolute(buttonTable, 60)
                .ControlsAdd(new Panel(), 0, 6);

            Controls.Add(mainTable);
        }

        public void Init(LessonEntity club)
        {
            Text = club.Name;
            Size = new Size(700, 600);
            StartPosition = FormStartPosition.CenterParent;
            Padding = new Padding(20);
            FormBorderStyle = FormBorderStyle.FixedDialog;
        }
    }
}
