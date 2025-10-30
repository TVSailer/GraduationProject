using DataAccess.Postgres.Models;
using Logica;
using Logica.Extension;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private List<LessonEntity> lessons = new()
        {
            new LessonEntity(new TeacherEntity("asdg", "lasdgj", "geq"), 5,3,5, 6, "egeh", "alhjg"),
            new LessonEntity(new TeacherEntity("asdg", "lasdgj", "geq"), 5,3,5, 6, "egeh", "alhjg"),
            new LessonEntity(new TeacherEntity("asdg", "lasdgj", "geq"), 5,3,5, 6, "egeh", "alhjg"),
            new LessonEntity(new TeacherEntity("asdg", "lasdgj", "geq"), 5,3,5, 6, "egeh", "alhjg"),
            new LessonEntity(new TeacherEntity("asdg", "lasdgj", "geq"), 5,3,5, 6, "egeh", "alhjg"),
        };
        public Form1()
        {
            StartPosition = FormStartPosition.CenterScreen;
            WindowState = FormWindowState.Maximized;

            Controls.Add(
                FactoryElements
                .CreateTableLayoutPanel()
                .ControlAddIsRowsAbsolute(
                    FactoryElements
                    .CreateTableLayoutPanel()
                    .ControlAddIsColumnPercent(FactoryElements.CreateLabel("Название", ContentAlignment.TopCenter), 20)
                    .ControlAddIsColumnPercent(FactoryElements.CreateLabel("Преподователь", ContentAlignment.TopCenter), 20)
                    .ControlAddIsColumnPercent(FactoryElements.CreateLabel("Категория", ContentAlignment.TopCenter), 20)
                    .ControlAddIsColumnPercent(FactoryElements.CreateLabel("Кол. уч.", ContentAlignment.TopCenter), 20)
                    .ControlAddIsColumnPercent(FactoryElements.CreateLabel("Рейтинг", ContentAlignment.TopCenter), 20)
                    , 70)
                .ControlAddIsRowsPercent(DisplayItems(lessons.ToArray(), CreateLessonCard), 75));
        }

        private TableLayoutPanel DisplayItems<T>(T[] items, Func<T, TableLayoutPanel> func)
        {
            var table = FactoryElements
                .CreateTableLayoutPanel();

            foreach (var eventItem in items)
                table.ControlAddIsRowsAbsolute(func?.Invoke(eventItem), 40);
            return table
                .ControlAddIsRowsPercent(new Panel(), 20);
        }

        private TableLayoutPanel CreateLessonCard(LessonEntity lesson)
            => new TableLayoutPanel()
            .Do(t => t.Dock = DockStyle.Fill)
            .Do(t => t.BorderStyle = BorderStyle.FixedSingle)
            .ControlAddIsColumnPercent(
                new LinkLabel()
                    .Do(l => l.Text = lesson.Name)
                    .Do(l => l.Dock = DockStyle.Fill)
                    .Do(l => l.TextAlign = ContentAlignment.TopCenter)
                    .Do(l => l.LinkBehavior = LinkBehavior.HoverUnderline), 20)
            .ControlAddIsColumnPercent(
                new Label()
                    .Do(l => l.Text = $"{lesson.Teacher.Name} {lesson.Teacher.Name} {lesson.Teacher.Name}")
                    .Do(l => l.TextAlign = ContentAlignment.TopCenter)
                    .Do(l => l.Dock = DockStyle.Fill), 20)
            .ControlAddIsColumnPercent(
                new Label()
                    .Do(l => l.Text = lesson.Category)
                    .Do(l => l.TextAlign = ContentAlignment.TopCenter)
                    .Do(l => l.Dock = DockStyle.Fill), 20)
            .ControlAddIsColumnPercent(
                new Label()
                    .Do(l => l.Text = $"{lesson.CurrentParticipants}/{lesson.MaxParticipants}")
                    .Do(l => l.TextAlign = ContentAlignment.TopCenter)
                    .Do(l => l.Dock = DockStyle.Fill), 20)
            .ControlAddIsColumnPercent(
                new Label()
                    .Do(l => l.Text = $"{lesson.Rating:0.0} ({lesson.ReviewCount} отзывов)")
                    .Do(l => l.TextAlign = ContentAlignment.TopCenter)
                    .Do(l => l.Dock = DockStyle.Fill), 20);
    }
}
