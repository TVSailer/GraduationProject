﻿using Logica;
using System.ComponentModel.DataAnnotations;

public partial class ViewVisitor
{
    public class ShowAddReviewForm : Form
    {
        public int UserRating { get; set; }

        [Required(ErrorMessage = "Введите ваше имя!")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Введите комментарий!")]
        public string UserComent { get; set; }
        public Club Club { get; set; }

        public ShowAddReviewForm(Club club, ViewVisitor viewVisitor)
        {
            Club = club;

            InitForm();

            var mainTable = FactoryElements.CreateTableLayoutPanel()
                .AddingRowsStyles(
                    new RowStyle(SizeType.Absolute, 30),
                    new RowStyle(SizeType.Absolute, 30),
                    new RowStyle(SizeType.Absolute, 30),
                    new RowStyle(SizeType.Absolute, 170),
                    new RowStyle(SizeType.Absolute, 40))
                .ControlsAdd(new Label{
                    Text = club != null ? $"Отзыв о кружке \"{club.Name}\"" : "Новый отзыв",
                    Font = FactoryElements.Style.TitleFont,
                    Dock = DockStyle.Top,
                    TextAlign = ContentAlignment.MiddleCenter}, 0, 0)
                .ControlsAdd(RatingPanel(), 0, 1)
                .ControlsAdd(AuthorPanel(), 0, 2)
                .ControlsAdd(ComentPanel(), 0, 3)
                .ControlsAdd(FactoryElements.CreateButton("Отправить", SubmitReview, viewVisitor), 0, 4)
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
                Font = FactoryElements.Style.Font,
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
                        Font = FactoryElements.Style.Font,
                        Dock = DockStyle.Bottom}, 0, 0)
                .ControlsAdd(FactoryElements.CreateTextBox("", (text) => UserName = (string)text), 1, 0)
                .ControlsAdd(new Panel(), 2, 1);
        private TableLayoutPanel ComentPanel()
            => new TableLayoutPanel(){Dock = DockStyle.Fill}
            .AddingRowsStyles(
                new RowStyle(SizeType.Absolute, 20))
            .ControlsAdd(new Label{
                Text = "Коментарий: ",
                Font = FactoryElements.Style.Font}, 0, 0)
            .ControlsAdd(FactoryElements.CreateTextBox("", (text) => UserComent = (string)text), 0, 1);

        private void SubmitReview(ViewVisitor viewVisitor)
        {
            if (!Validatoreg.TryValidObject(this)) return;

            var review = new Review
            {
                Author = UserName,
                Date = DateTime.Now,
                Rating = UserRating + 1,
                Comment = UserComent
            };

            viewVisitor.UpdateListReviewClub(review, Club.Name);
            Close();
        }
    }

    
}
