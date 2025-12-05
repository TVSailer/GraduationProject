using DataAccess.Postgres;
using DataAccess.Postgres.Models;
using Logica;
using Logica.Extension;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System;
using System.Drawing;
using System.Windows.Forms;
using AdminApp.Controls;
using AdminApp.Forms;
using Microsoft.Extensions.Logging;
using WinFormsApp1.View;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        //private List<LessonEntity> lessons = new()
        //{
        //    new LessonEntity(new TeacherEntity("asdg", "lasdgj", "geq"), 5,3,5, 6, "egeh", "alhjg"),
        //    new LessonEntity(new TeacherEntity("asdg", "lasdgj", "geq"), 5,3,5, 6, "egeh", "alhjg"),
        //    new LessonEntity(new TeacherEntity("asdg", "lasdgj", "geq"), 5,3,5, 6, "egeh", "alhjg"),
        //    new LessonEntity(new TeacherEntity("asdg", "lasdgj", "geq"), 5,3,5, 6, "egeh", "alhjg"),
        //    new LessonEntity(new TeacherEntity("asdg", "lasdgj", "geq"), 5,3,5, 6, "egeh", "alhjg"),
        //};
        //public Form1()
        //{
        //    StartPosition = FormStartPosition.CenterScreen;
        //    WindowState = FormWindowState.Maximized;

        //    Controls.Add(
        //        FactoryElements
        //        .CreateTableLayoutPanel()
        //        .ControlAddIsRowsAbsolute(
        //            FactoryElements
        //            .CreateTableLayoutPanel()
        //            .ControlAddIsColumnPercent(FactoryElements.CreateLabel("Название", ContentAlignment.TopCenter), 20)
        //            .ControlAddIsColumnPercent(FactoryElements.CreateLabel("Преподователь", ContentAlignment.TopCenter), 20)
        //            .ControlAddIsColumnPercent(FactoryElements.CreateLabel("Категория", ContentAlignment.TopCenter), 20)
        //            .ControlAddIsColumnPercent(FactoryElements.CreateLabel("Кол. уч.", ContentAlignment.TopCenter), 20)
        //            .ControlAddIsColumnPercent(FactoryElements.CreateLabel("Рейтинг", ContentAlignment.TopCenter), 20)
        //            , 70)
        //        .ControlAddIsRowsPercent(DisplayItems(lessons.ToArray(), CreateLessonCard), 75));
        //}

        //private TableLayoutPanel DisplayItems<T>(T[] items, Func<T, TableLayoutPanel> func)
        //{
        //    var table = FactoryElements
        //        .CreateTableLayoutPanel();

        //    foreach (var eventItem in items)
        //        table.ControlAddIsRowsAbsolute(func?.Invoke(eventItem), 40);
        //    return table
        //        .ControlAddIsRowsPercent(new Panel(), 20);
        //}

        //private TableLayoutPanel CreateLessonCard(LessonEntity lesson)
        //    => new TableLayoutPanel()
        //    .With(t => t.Dock = DockStyle.Fill)
        //    .With(t => t.BackColor = Color.BlanchedAlmond)
        //    .With(t => t.Enabled = true)
        //    .With(t => t.BorderStyle = BorderStyle.FixedSingle)
        //    .With(t => t.Click += (send, e) => new Form())
        //    .ControlAddIsColumnPercent(
        //        new LinkLabel()
        //            .With(l => l.Text = lesson.Name)
        //            .With(l => l.Dock = DockStyle.Fill)
        //            .With(l => l.TextAlign = ContentAlignment.TopCenter)
        //            .With(l => l.LinkBehavior = LinkBehavior.HoverUnderline), 20)
        //    .ControlAddIsColumnPercent(
        //        new Label()
        //            .With(l => l.Text = $"{lesson.Event.Name} {lesson.Event.Name} {lesson.Event.Name}")
        //            .With(l => l.TextAlign = ContentAlignment.TopCenter)
        //            .With(l => l.Dock = DockStyle.Fill), 20)
        //    .ControlAddIsColumnPercent(
        //        new Label()
        //            .With(l => l.Text = lesson.Category)
        //            .With(l => l.TextAlign = ContentAlignment.TopCenter)
        //            .With(l => l.Dock = DockStyle.Fill), 20)
        //    .ControlAddIsColumnPercent(
        //        new Label()
        //            .With(l => l.Text = $"{lesson.CurrentParticipants}/{lesson.MaxParticipants}")
        //            .With(l => l.TextAlign = ContentAlignment.TopCenter)
        //            .With(l => l.Dock = DockStyle.Fill), 20)
        //    .ControlAddIsColumnPercent(
        //        new Label()
        //            .With(l => l.Text = $"{lesson.Rating:0.0} ({lesson.ReviewCount} отзывов)")
        //            .With(l => l.TextAlign = ContentAlignment.TopCenter)
        //            .With(l => l.Dock = DockStyle.Fill), 20);

        }
}





namespace AdminApp.Controls
{
    public class NewsCard : ObjectCard
    {
        private string _title;
        private string _author;
        private string _date;
        private string _category;

        public NewsCard(int id, string title, string author, string date, string category)
            : base(id)
        {
            _title = title;
            _author = author;
            _date = date;
            _category = category;
            CreateContent();
        }

        public override void CreateContent()
        {
            var table = FactoryElements.CreateTableLayoutPanel(1, new[] { 25, 20, 20, 20 })
                .With(t => t.Dock = DockStyle.Fill);

            var titleLabel = FactoryElements.CreateLabel(_title)
                .With(l => l.Font = new Font("Arial", 11, FontStyle.Bold))
                .With(l => l.ForeColor = Color.DarkBlue);

            var authorLabel = FactoryElements.CreateLabel($"👤 {_author}")
                .With(l => l.Font = new Font("Arial", 9))
                .With(l => l.ForeColor = Color.Gray);

            var dateLabel = FactoryElements.CreateLabel($"📅 {_date}")
                .With(l => l.Font = new Font("Arial", 9))
                .With(l => l.ForeColor = Color.Gray);

            var categoryLabel = FactoryElements.CreateLabel($"🏷️ {_category}")
                .With(l => l.Font = new Font("Arial", 9, FontStyle.Italic))
                .With(l => l.ForeColor = Color.DarkGreen);

            table.Controls.Add(titleLabel, 0, 0);
            table.Controls.Add(authorLabel, 0, 1);
            table.Controls.Add(dateLabel, 0, 2);
            table.Controls.Add(categoryLabel, 0, 3);

            this.Controls.Add(table);
        }
    }

    public class LessonCard : ObjectCard
    {
        private string _name;
        private string _category;
        private string _teacher;
        private string _schedule;
        private string _participants;

        public LessonCard(int id, string name, string category, string teacher, string schedule, string participants)
            : base(id)
        {
            _name = name;
            _category = category;
            _teacher = teacher;
            _schedule = schedule;
            _participants = participants;
            CreateContent();
        }

        public override void CreateContent()
        {
            var table = FactoryElements.CreateTableLayoutPanel(1, new[] { 25, 20, 20, 20 })
                .With(t => t.Dock = DockStyle.Fill);

            var titleLabel = FactoryElements.CreateLabel(_name)
                .With(l => l.Font = new Font("Arial", 11, FontStyle.Bold))
                .With(l => l.ForeColor = Color.DarkBlue);

            var categoryLabel = FactoryElements.CreateLabel($"🏷️ {_category}")
                .With(l => l.Font = new Font("Arial", 9))
                .With(l => l.ForeColor = Color.Gray);

            var teacherScheduleLabel = FactoryElements.CreateLabel($"👨‍🏫 {_teacher} | 🕒 {_schedule}")
                .With(l => l.Font = new Font("Arial", 9))
                .With(l => l.ForeColor = Color.Gray);

            var participantsLabel = FactoryElements.CreateLabel($"👥 {_participants}")
                .With(l => l.Font = new Font("Arial", 9))
                .With(l => l.ForeColor = Color.DarkGreen);

            table.Controls.Add(titleLabel, 0, 0);
            table.Controls.Add(categoryLabel, 0, 1);
            table.Controls.Add(teacherScheduleLabel, 0, 2);
            table.Controls.Add(participantsLabel, 0, 3);

            this.Controls.Add(table);
        }
    }

    public class TeacherCard : ObjectCard
    {
        private string _surname;
        private string _name;
        private string _patronymic;
        private string _phone;
        private int _lessonsCount;

        public TeacherCard(int id, string surname, string name, string patronymic, string phone, int lessonsCount)
            : base(id)
        {
            _surname = surname;
            _name = name;
            _patronymic = patronymic;
            _phone = phone;
            _lessonsCount = lessonsCount;
            CreateContent();
        }

        public override void CreateContent()
        {
            var table = FactoryElements.CreateTableLayoutPanel(1, new[] { 25, 20, 20, 20 })
                .With(t => t.Dock = DockStyle.Fill);

            var nameLabel = FactoryElements.CreateLabel($"{_surname} {_name} {_patronymic}")
                .With(l => l.Font = new Font("Arial", 11, FontStyle.Bold))
                .With(l => l.ForeColor = Color.DarkBlue);

            var phoneLabel = FactoryElements.CreateLabel($"📞 {_phone}")
                .With(l => l.Font = new Font("Arial", 9))
                .With(l => l.ForeColor = Color.Gray);

            var lessonsLabel = FactoryElements.CreateLabel($"🎨 Кружков: {_lessonsCount}")
                .With(l => l.Font = new Font("Arial", 9))
                .With(l => l.ForeColor = Color.DarkGreen);

            table.Controls.Add(nameLabel, 0, 0);
            table.Controls.Add(phoneLabel, 0, 1);
            table.Controls.Add(lessonsLabel, 0, 2);

            this.Controls.Add(table);
        }
    }

    public class VisitorCard : ObjectCard
    {
        private string _surname;
        private string _name;
        private string _patronymic;
        private string _phone;
        private int _lessonsCount;

        public VisitorCard(int id, string surname, string name, string patronymic, string phone, int lessonsCount)
            : base(id)
        {
            _surname = surname;
            _name = name;
            _patronymic = patronymic;
            _phone = phone;
            _lessonsCount = lessonsCount;
            CreateContent();
        }

        public override void CreateContent()
        {
            var table = FactoryElements.CreateTableLayoutPanel(1, new[] { 25, 20, 20, 20 })
                .With(t => t.Dock = DockStyle.Fill);

            var nameLabel = FactoryElements.CreateLabel($"{_surname} {_name} {_patronymic}")
                .With(l => l.Font = new Font("Arial", 11, FontStyle.Bold))
                .With(l => l.ForeColor = Color.DarkBlue);

            var phoneLabel = FactoryElements.CreateLabel($"📞 {_phone}")
                .With(l => l.Font = new Font("Arial", 9))
                .With(l => l.ForeColor = Color.Gray);

            var lessonsLabel = FactoryElements.CreateLabel($"🎯 Посещает кружков: {_lessonsCount}")
                .With(l => l.Font = new Font("Arial", 9))
                .With(l => l.ForeColor = Color.DarkGreen);

            table.Controls.Add(nameLabel, 0, 0);
            table.Controls.Add(phoneLabel, 0, 1);
            table.Controls.Add(lessonsLabel, 0, 2);

            this.Controls.Add(table);
        }
    }

    public class AttendanceCard : ObjectCard
    {
        private string _lesson;
        private string _date;
        private int _visitorsCount;
        private string _teacher;

        public AttendanceCard(int id, string lesson, string date, int visitorsCount, string teacher)
            : base(id)
        {
            _lesson = lesson;
            _date = date;
            _visitorsCount = visitorsCount;
            _teacher = teacher;
            CreateContent();
        }

        public override void CreateContent()
        {
            var table = FactoryElements.CreateTableLayoutPanel(1, new[] { 25, 20, 20, 20 })
                .With(t => t.Dock = DockStyle.Fill);

            var lessonLabel = FactoryElements.CreateLabel(_lesson)
                .With(l => l.Font = new Font("Arial", 11, FontStyle.Bold))
                .With(l => l.ForeColor = Color.DarkBlue);

            var dateLabel = FactoryElements.CreateLabel($"📅 {_date}")
                .With(l => l.Font = new Font("Arial", 9))
                .With(l => l.ForeColor = Color.Gray);

            var visitorsLabel = FactoryElements.CreateLabel($"👥 Посетителей: {_visitorsCount}")
                .With(l => l.Font = new Font("Arial", 9))
                .With(l => l.ForeColor = Color.DarkGreen);

            var teacherLabel = FactoryElements.CreateLabel($"👨‍🏫 {_teacher}")
                .With(l => l.Font = new Font("Arial", 9))
                .With(l => l.ForeColor = Color.Gray);

            table.Controls.Add(lessonLabel, 0, 0);
            table.Controls.Add(dateLabel, 0, 1);
            table.Controls.Add(visitorsLabel, 0, 2);
            table.Controls.Add(teacherLabel, 0, 3);

            this.Controls.Add(table);
        }
    }
}


namespace AdminApp.Forms
{
    public partial class NewsManagementForm : Form
    {
        private FlowLayoutPanel _cardsPanel;

        public NewsManagementForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            Text = "Управление новостями";
            Size = new Size(1000, 700);
            StartPosition = FormStartPosition.CenterParent;
            BackColor = Color.White;

            CreateUI();
            LoadNewsCards();
        }

        private void CreateUI()
        {
            var mainTable = FactoryElements.CreateTableLayoutPanel(1, new[] { 60, 500, 60 })
                .With(t => t.Padding = new Padding(15));

            var titleLabel = FactoryElements.CreateLabel("📰 Управление новостями")
                .With(l => l.Font = new Font("Arial", 16, FontStyle.Bold))
                .With(l => l.TextAlign = ContentAlignment.MiddleCenter);

            mainTable.Controls.Add(titleLabel, 0, 0);

            _cardsPanel = new FlowLayoutPanel()
                .With(p => p.Dock = DockStyle.Fill)
                .With(p => p.AutoScroll = true)
                .With(p => p.BackColor = Color.WhiteSmoke)
                .With(p => p.Padding = new Padding(10));

            mainTable.Controls.Add(_cardsPanel, 0, 1);

            var buttonPanel = CreateButtonPanel();
            mainTable.Controls.Add(buttonPanel, 0, 2);

            this.Controls.Add(mainTable);
        }

        private void LoadNewsCards()
        {
            var news = new[]
            {
                new { Id = 1, Title = "Открытие нового кружка", Author = "Администратор", Date = "15.01.2024", Category = "Образование" },
                new { Id = 2, Title = "Школьный конкурс талантов", Author = "Учитель", Date = "16.01.2024", Category = "Мероприятия" },
                new { Id = 3, Title = "Каникулы в библиотеке", Author = "Библиотекарь", Date = "17.01.2024", Category = "Культура" }
            };

            foreach (var newsItem in news)
            {
                var card = new NewsCard(newsItem.Id, newsItem.Title, newsItem.Author, newsItem.Date, newsItem.Category);
                card.Click += (s, e) => ShowNewsDetails(newsItem.Id);
                _cardsPanel.Controls.Add(card);
            }
        }

        private void ShowNewsDetails(int newsId)
        {
            LogicaMessage.MessageOk($"Подробная информация о новости #{newsId}");
        }

        private Panel CreateButtonPanel()
        {
            var panel = new Panel()
                .With(p => p.Dock = DockStyle.Fill)
                .With(p => p.Height = 50);

            var addButton = FactoryElements.CreateButton("➕ Добавить новость")
                .With(b => b.Size = new Size(150, 35))
                .With(b => b.BackColor = Color.LightGreen)
                .With(b => b.Click += (s, e) => LogicaMessage.MessageOk("Добавление новой новости"));

            var editButton = FactoryElements.CreateButton("✏️ Редактировать")
                .With(b => b.Size = new Size(140, 35))
                .With(b => b.BackColor = Color.LightBlue)
                .With(b => b.Click += (s, e) => LogicaMessage.MessageOk("Редактирование новости"));

            var deleteButton = FactoryElements.CreateButton("🗑️ Удалить")
                .With(b => b.Size = new Size(120, 35))
                .With(b => b.BackColor = Color.LightCoral)
                .With(b => b.Click += (s, e) => LogicaMessage.MessageOk("Удаление новости"));

            var refreshButton = FactoryElements.CreateButton("🔄 Обновить")
                .With(b => b.Size = new Size(120, 35))
                .With(b => b.BackColor = Color.LightYellow)
                .With(b => b.Click += (s, e) => {
                    _cardsPanel.Controls.Clear();
                    LoadNewsCards();
                    LogicaMessage.MessageSuccess("Список обновлен!");
                });

            int xPos = 20;
            foreach (var button in new[] { addButton, editButton, deleteButton, refreshButton })
            {
                button.With(b => b.Location = new Point(xPos, 10));
                xPos += button.Width + 10;
                panel.Controls.Add(button);
            }

            return panel;
        }
    }
}



namespace AdminApp.Forms
{
    public partial class LessonsManagementForm : Form
    {
        private FlowLayoutPanel _cardsPanel;

        public LessonsManagementForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            Text = "Управление кружками";
            Size = new Size(1000, 700);
            StartPosition = FormStartPosition.CenterParent;
            BackColor = Color.White;

            CreateUI();
            LoadLessonCards();
        }

        private void CreateUI()
        {
            var mainTable = FactoryElements.CreateTableLayoutPanel(1, new[] { 60, 500, 60 })
                .With(t => t.Padding = new Padding(15));

            var titleLabel = FactoryElements.CreateLabel("🎨 Управление кружками")
                .With(l => l.Font = new Font("Arial", 16, FontStyle.Bold))
                .With(l => l.TextAlign = ContentAlignment.MiddleCenter);

            mainTable.Controls.Add(titleLabel, 0, 0);

            _cardsPanel = new FlowLayoutPanel()
                .With(p => p.Dock = DockStyle.Fill)
                .With(p => p.AutoScroll = true)
                .With(p => p.BackColor = Color.WhiteSmoke)
                .With(p => p.Padding = new Padding(10));

            mainTable.Controls.Add(_cardsPanel, 0, 1);

            var buttonPanel = CreateButtonPanel();
            mainTable.Controls.Add(buttonPanel, 0, 2);

            this.Controls.Add(mainTable);
        }

        private void LoadLessonCards()
        {
            var lessons = new[]
            {
                new { Id = 1, Name = "Рисование", Category = "Искусство", Teacher = "Иванов И.И.", Schedule = "Пн, Ср 15:00", Participants = "12/15" },
                new { Id = 2, Name = "Программирование", Category = "Техника", Teacher = "Петров П.П.", Schedule = "Вт, Чт 16:00", Participants = "8/10" },
                new { Id = 3, Name = "Хоровое пение", Category = "Музыка", Teacher = "Сидорова С.С.", Schedule = "Пн, Пт 14:00", Participants = "15/20" },
                new { Id = 4, Name = "Шахматы", Category = "Спорт", Teacher = "Кузнецов К.К.", Schedule = "Ср, Пт 17:00", Participants = "10/12" }
            };

            foreach (var lesson in lessons)
            {
                var card = new LessonCard(lesson.Id, lesson.Name, lesson.Category, lesson.Teacher, lesson.Schedule, lesson.Participants);
                card.Click += (s, e) => ShowLessonDetails(lesson.Id);
                _cardsPanel.Controls.Add(card);
            }
        }

        private void ShowLessonDetails(int lessonId)
        {
            LogicaMessage.MessageOk($"Подробная информация о кружке #{lessonId}");
        }

        private Panel CreateButtonPanel()
        {
            var panel = new Panel()
                .With(p => p.Dock = DockStyle.Fill)
                .With(p => p.Height = 50);

            var addButton = FactoryElements.CreateButton("➕ Добавить кружок")
                .With(b => b.Size = new Size(150, 35))
                .With(b => b.BackColor = Color.LightGreen)
                .With(b => b.Click += (s, e) => LogicaMessage.MessageOk("Добавление кружка"));

            var editButton = FactoryElements.CreateButton("✏️ Редактировать")
                .With(b => b.Size = new Size(140, 35))
                .With(b => b.BackColor = Color.LightBlue)
                .With(b => b.Click += (s, e) => LogicaMessage.MessageOk("Редактирование кружка"));

            var deleteButton = FactoryElements.CreateButton("🗑️ Удалить")
                .With(b => b.Size = new Size(120, 35))
                .With(b => b.BackColor = Color.LightCoral)
                .With(b => b.Click += (s, e) => LogicaMessage.MessageOk("Удаление кружка"));

            var refreshButton = FactoryElements.CreateButton("🔄 Обновить")
                .With(b => b.Size = new Size(120, 35))
                .With(b => b.BackColor = Color.LightYellow)
                .With(b => b.Click += (s, e) => {
                    _cardsPanel.Controls.Clear();
                    LoadLessonCards();
                    LogicaMessage.MessageSuccess("Список кружков обновлен!");
                });

            int xPos = 20;
            foreach (var button in new[] { addButton, editButton, deleteButton, refreshButton })
            {
                button.With(b => b.Location = new Point(xPos, 10));
                xPos += button.Width + 10;
                panel.Controls.Add(button);
            }

            return panel;
        }
    }
}

namespace AdminApp.Forms
{
    public partial class TeachersManagementForm : Form
    {
        private FlowLayoutPanel _cardsPanel;

        public TeachersManagementForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            Text = "Управление преподавателями";
            Size = new Size(1000, 700);
            StartPosition = FormStartPosition.CenterParent;
            BackColor = Color.White;

            CreateUI();
            LoadTeacherCards();
        }

        private void CreateUI()
        {
            var mainTable = FactoryElements.CreateTableLayoutPanel(1, new[] { 60, 500, 60 })
                .With(t => t.Padding = new Padding(15));

            var titleLabel = FactoryElements.CreateLabel("👨‍🏫 Управление преподавателями")
                .With(l => l.Font = new Font("Arial", 16, FontStyle.Bold))
                .With(l => l.TextAlign = ContentAlignment.MiddleCenter);

            mainTable.Controls.Add(titleLabel, 0, 0);

            _cardsPanel = new FlowLayoutPanel()
                .With(p => p.Dock = DockStyle.Fill)
                .With(p => p.AutoScroll = true)
                .With(p => p.BackColor = Color.WhiteSmoke)
                .With(p => p.Padding = new Padding(10));

            mainTable.Controls.Add(_cardsPanel, 0, 1);

            var buttonPanel = CreateButtonPanel();
            mainTable.Controls.Add(buttonPanel, 0, 2);

            this.Controls.Add(mainTable);
        }

        private void LoadTeacherCards()
        {
            var teachers = new[]
            {
                new { Id = 1, Surname = "Иванов", Name = "Иван", Patronymic = "Иванович", Phone = "+7(999)123-45-67", LessonsCount = 2 },
                new { Id = 2, Surname = "Петров", Name = "Петр", Patronymic = "Петрович", Phone = "+7(888)123-45-67", LessonsCount = 1 },
                new { Id = 3, Surname = "Сидорова", Name = "Мария", Patronymic = "Ивановна", Phone = "+7(777)123-45-67", LessonsCount = 3 },
                new { Id = 4, Surname = "Кузнецов", Name = "Алексей", Patronymic = "Сергеевич", Phone = "+7(666)123-45-67", LessonsCount = 2 }
            };

            foreach (var teacher in teachers)
            {
                var card = new TeacherCard(teacher.Id, teacher.Surname, teacher.Name, teacher.Patronymic, teacher.Phone, teacher.LessonsCount);
                card.Click += (s, e) => ShowTeacherDetails(teacher.Id);
                _cardsPanel.Controls.Add(card);
            }
        }

        private void ShowTeacherDetails(int teacherId)
        {
            LogicaMessage.MessageOk($"Подробная информация о преподавателе #{teacherId}");
        }

        private Panel CreateButtonPanel()
        {
            var panel = new Panel()
                .With(p => p.Dock = DockStyle.Fill)
                .With(p => p.Height = 50);

            var addButton = FactoryElements.CreateButton("➕ Добавить преподавателя")
                .With(b => b.Size = new Size(190, 35))
                .With(b => b.BackColor = Color.LightGreen)
                .With(b => b.Click += (s, e) => LogicaMessage.MessageOk("Добавление преподавателя"));

            var editButton = FactoryElements.CreateButton("✏️ Редактировать")
                .With(b => b.Size = new Size(140, 35))
                .With(b => b.BackColor = Color.LightBlue)
                .With(b => b.Click += (s, e) => LogicaMessage.MessageOk("Редактирование преподавателя"));

            var deleteButton = FactoryElements.CreateButton("🗑️ Удалить")
                .With(b => b.Size = new Size(120, 35))
                .With(b => b.BackColor = Color.LightCoral)
                .With(b => b.Click += (s, e) => LogicaMessage.MessageOk("Удаление преподавателя"));

            var refreshButton = FactoryElements.CreateButton("🔄 Обновить")
                .With(b => b.Size = new Size(120, 35))
                .With(b => b.BackColor = Color.LightYellow)
                .With(b => b.Click += (s, e) => {
                    _cardsPanel.Controls.Clear();
                    LoadTeacherCards();
                    LogicaMessage.MessageSuccess("Список преподавателей обновлен!");
                });

            int xPos = 20;
            foreach (var button in new[] { addButton, editButton, deleteButton, refreshButton })
            {
                button.With(b => b.Location = new Point(xPos, 10));
                xPos += button.Width + 10;
                panel.Controls.Add(button);
            }

            return panel;
        }
    }
}

namespace AdminApp.Forms
{
    public partial class VisitorsManagementForm : Form
    {
        private FlowLayoutPanel _cardsPanel;

        public VisitorsManagementForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            Text = "Управление пользователями";
            Size = new Size(1000, 700);
            StartPosition = FormStartPosition.CenterParent;
            BackColor = Color.White;

            CreateUI();
            LoadVisitorCards();
        }

        private void CreateUI()
        {
            var mainTable = FactoryElements.CreateTableLayoutPanel(1, new[] { 60, 500, 60 })
                .With(t => t.Padding = new Padding(15));

            var titleLabel = FactoryElements.CreateLabel("👥 Управление пользователями")
                .With(l => l.Font = new Font("Arial", 16, FontStyle.Bold))
                .With(l => l.TextAlign = ContentAlignment.MiddleCenter);

            mainTable.Controls.Add(titleLabel, 0, 0);

            _cardsPanel = new FlowLayoutPanel()
                .With(p => p.Dock = DockStyle.Fill)
                .With(p => p.AutoScroll = true)
                .With(p => p.BackColor = Color.WhiteSmoke)
                .With(p => p.Padding = new Padding(10));

            mainTable.Controls.Add(_cardsPanel, 0, 1);

            var buttonPanel = CreateButtonPanel();
            mainTable.Controls.Add(buttonPanel, 0, 2);

            this.Controls.Add(mainTable);
        }

        private void LoadVisitorCards()
        {
            var visitors = new[]
            {
                new { Id = 1, Surname = "Сидоров", Name = "Алексей", Patronymic = "Сергеевич", Phone = "+7(777)123-45-67", LessonsCount = 3 },
                new { Id = 2, Surname = "Кузнецова", Name = "Мария", Patronymic = "Ивановна", Phone = "+7(666)123-45-67", LessonsCount = 2 },
                new { Id = 3, Surname = "Петрова", Name = "Анна", Patronymic = "Владимировна", Phone = "+7(555)123-45-67", LessonsCount = 1 },
                new { Id = 4, Surname = "Васильев", Name = "Дмитрий", Patronymic = "Александрович", Phone = "+7(444)123-45-67", LessonsCount = 2 }
            };

            foreach (var visitor in visitors)
            {
                var card = new VisitorCard(visitor.Id, visitor.Surname, visitor.Name, visitor.Patronymic, visitor.Phone, visitor.LessonsCount);
                card.Click += (s, e) => ShowVisitorDetails(visitor.Id);
                _cardsPanel.Controls.Add(card);
            }
        }

        private void ShowVisitorDetails(int visitorId)
        {
            LogicaMessage.MessageOk($"Подробная информация о пользователе #{visitorId}");
        }

        private Panel CreateButtonPanel()
        {
            var panel = new Panel()
                .With(p => p.Dock = DockStyle.Fill)
                .With(p => p.Height = 50);

            var addButton = FactoryElements.CreateButton("➕ Добавить пользователя")
                .With(b => b.Size = new Size(180, 35))
                .With(b => b.BackColor = Color.LightGreen)
                .With(b => b.Click += (s, e) => LogicaMessage.MessageOk("Добавление пользователя"));

            var editButton = FactoryElements.CreateButton("✏️ Редактировать")
                .With(b => b.Size = new Size(140, 35))
                .With(b => b.BackColor = Color.LightBlue)
                .With(b => b.Click += (s, e) => LogicaMessage.MessageOk("Редактирование пользователя"));

            var deleteButton = FactoryElements.CreateButton("🗑️ Удалить")
                .With(b => b.Size = new Size(120, 35))
                .With(b => b.BackColor = Color.LightCoral)
                .With(b => b.Click += (s, e) => LogicaMessage.MessageOk("Удаление пользователя"));

            var refreshButton = FactoryElements.CreateButton("🔄 Обновить")
                .With(b => b.Size = new Size(120, 35))
                .With(b => b.BackColor = Color.LightYellow)
                .With(b => b.Click += (s, e) => {
                    _cardsPanel.Controls.Clear();
                    LoadVisitorCards();
                    LogicaMessage.MessageSuccess("Список пользователей обновлен!");
                });

            int xPos = 20;
            foreach (var button in new[] { addButton, editButton, deleteButton, refreshButton })
            {
                button.With(b => b.Location = new Point(xPos, 10));
                xPos += button.Width + 10;
                panel.Controls.Add(button);
            }

            return panel;
        }
    }
}


namespace AdminApp.Forms
{
    public partial class AttendanceManagementForm : Form
    {
        private FlowLayoutPanel _cardsPanel;

        public AttendanceManagementForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            Text = "Управление посещаемостью";
            Size = new Size(1000, 700);
            StartPosition = FormStartPosition.CenterParent;
            BackColor = Color.White;

            CreateUI();
            LoadAttendanceCards();
        }

        private void CreateUI()
        {
            var mainTable = FactoryElements.CreateTableLayoutPanel(1, new[] { 60, 500, 60 })
                .With(t => t.Padding = new Padding(15));

            var titleLabel = FactoryElements.CreateLabel("📊 Управление посещаемостью")
                .With(l => l.Font = new Font("Arial", 16, FontStyle.Bold))
                .With(l => l.TextAlign = ContentAlignment.MiddleCenter);

            mainTable.Controls.Add(titleLabel, 0, 0);

            _cardsPanel = new FlowLayoutPanel()
                .With(p => p.Dock = DockStyle.Fill)
                .With(p => p.AutoScroll = true)
                .With(p => p.BackColor = Color.WhiteSmoke)
                .With(p => p.Padding = new Padding(10));

            mainTable.Controls.Add(_cardsPanel, 0, 1);

            var buttonPanel = CreateButtonPanel();
            mainTable.Controls.Add(buttonPanel, 0, 2);

            this.Controls.Add(mainTable);
        }

        private void LoadAttendanceCards()
        {
            var attendance = new[]
            {
                new { Id = 1, Lesson = "Рисование", Date = "10.01.2024", VisitorsCount = 12, Teacher = "Иванов И.И." },
                new { Id = 2, Lesson = "Программирование", Date = "11.01.2024", VisitorsCount = 8, Teacher = "Петров П.П." },
                new { Id = 3, Lesson = "Хоровое пение", Date = "12.01.2024", VisitorsCount = 15, Teacher = "Сидорова С.С." },
                new { Id = 4, Lesson = "Шахматы", Date = "13.01.2024", VisitorsCount = 10, Teacher = "Кузнецов К.К." }
            };

            foreach (var record in attendance)
            {
                var card = new AttendanceCard(record.Id, record.Lesson, record.Date, record.VisitorsCount, record.Teacher);
                card.Click += (s, e) => ShowAttendanceDetails(record.Id);
                _cardsPanel.Controls.Add(card);
            }
        }

        private void ShowAttendanceDetails(int attendanceId)
        {
            LogicaMessage.MessageOk($"Подробная информация о посещаемости #{attendanceId}");
        }

        private Panel CreateButtonPanel()
        {
            var panel = new Panel()
                .With(p => p.Dock = DockStyle.Fill)
                .With(p => p.Height = 50);

            var addButton = FactoryElements.CreateButton("➕ Добавить запись")
                .With(b => b.Size = new Size(150, 35))
                .With(b => b.BackColor = Color.LightGreen)
                .With(b => b.Click += (s, e) => LogicaMessage.MessageOk("Добавление записи о посещаемости"));

            var editButton = FactoryElements.CreateButton("✏️ Редактировать")
                .With(b => b.Size = new Size(140, 35))
                .With(b => b.BackColor = Color.LightBlue)
                .With(b => b.Click += (s, e) => LogicaMessage.MessageOk("Редактирование записи"));

            var deleteButton = FactoryElements.CreateButton("🗑️ Удалить")
                .With(b => b.Size = new Size(120, 35))
                .With(b => b.BackColor = Color.LightCoral)
                .With(b => b.Click += (s, e) => LogicaMessage.MessageOk("Удаление записи"));

            var statsButton = FactoryElements.CreateButton("📈 Статистика")
                .With(b => b.Size = new Size(120, 35))
                .With(b => b.BackColor = Color.LightYellow)
                .With(b => b.Click += (s, e) => LogicaMessage.MessageOk("Просмотр статистики посещаемости"));

            int xPos = 20;
            foreach (var button in new[] { addButton, editButton, deleteButton, statsButton })
            {
                button.With(b => b.Location = new Point(xPos, 10));
                xPos += button.Width + 10;
                panel.Controls.Add(button);
            }

            return panel;
        }
    }
}