using Logica;

public partial class ViewVisitor
{
    public class ShowAddReviewForm : Form
    {
        public int UserRating { get; set; }
        public string UserName { get; set; }
        public string UserComent { get; set; }
        public Club Club { get; set; }

        private BaseStyle style = new VisitorViewStyle();
        private BaseCreatingElements elementFactory;

        public ShowAddReviewForm(Club club, ViewVisitor viewVisitor)
        {
            elementFactory = new CreatingElements(style);
            Club = club;

            InitForm();

            var mainTable = elementFactory.CreateTableLayoutPanel()
                .AddingRowsStyles(
                    new RowStyle(SizeType.Absolute, 30),
                    new RowStyle(SizeType.Absolute, 30),
                    new RowStyle(SizeType.Absolute, 30),
                    new RowStyle(SizeType.Absolute, 170),
                    new RowStyle(SizeType.Absolute, 40))
                .ControlsAdd(new Label{
                    Text = club != null ? $"Отзыв о кружке \"{club.Name}\"" : "Новый отзыв",
                    Font = style.TitleFont,
                    Dock = DockStyle.Top,
                    TextAlign = ContentAlignment.MiddleCenter}, 0, 0)
                .ControlsAdd(RatingPanel(), 0, 1)
                .ControlsAdd(AuthorPanel(), 0, 2)
                .ControlsAdd(ComentPanel(), 0, 3)
                .ControlsAdd(elementFactory.CreateButton("Отправить", viewVisitor.SubmitReview, this), 0, 4)
                .ControlsAdd(new Panel(), 0, 5);

            Controls.Add(mainTable);
        }

        private void InitForm()
        {
            Text = "Добавить отзыв";
            Size = new Size(600, 400);
            StartPosition = FormStartPosition.CenterParent;
            Padding = new Padding(20);
            FormBorderStyle = FormBorderStyle.FixedDialog;
        }
        
        private TableLayoutPanel RatingPanel()
        {
            var ratingCombo = new ComboBox{ DropDownStyle = ComboBoxStyle.DropDownList};
            ratingCombo.Items.AddRange(new object[] { "Очень ужастно", "Ужастно", "Удолетворительно", "Хорошо", "Отлично" });
            ratingCombo.SelectedIndex = 4;// 5 по умолчанию
            ratingCombo.SelectedIndexChanged += (send, e) => UserRating = ratingCombo.SelectedIndex;

            var table = new TableLayoutPanel {Dock = DockStyle.Fill}
            .AddingColumnsStyles(
                new ColumnStyle(SizeType.Absolute, 65),
                new ColumnStyle(SizeType.Absolute, 130))
            .ControlsAdd(new Label{
                Text = "Оценка:",
                Font = style.Font,
                Dock = DockStyle.Bottom}, 0, 0)
            .ControlsAdd(ratingCombo, 1, 0)
            .ControlsAdd(new Panel(), 2, 1);

            return table;
        }
        private TableLayoutPanel AuthorPanel()
            => new TableLayoutPanel { Dock = DockStyle.Fill}
                .AddingColumnsStyles(
                    new ColumnStyle(SizeType.Absolute, 80),
                    new ColumnStyle(SizeType.Absolute, 130))
                .ControlsAdd(
                    new Label{
                        Text = "Ваше имя: ",
                        Font = style.Font,
                        Dock = DockStyle.Bottom}, 0, 0)
                .ControlsAdd(elementFactory.CreateTextBox("", (text) => UserName = (string)text), 1, 0)
                .ControlsAdd(new Panel(), 2, 1);
        private TableLayoutPanel ComentPanel()
            => new TableLayoutPanel(){Dock = DockStyle.Fill}
            .AddingRowsStyles(
                new RowStyle(SizeType.Absolute, 20))
            .ControlsAdd(new Label{
                Text = "Коментарий: ",
                Font = style.Font}, 0, 0)
            .ControlsAdd(elementFactory.CreateTextBox("", (text) => UserComent = (string)text), 0, 1);
    }
}
