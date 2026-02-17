using Logica;

namespace WinFormsApp2
{
    using DataAccess.Postgres;
    using DataAccess.Postgres.Models;
    using DataAccess.Postgres.Repository;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Windows.Input;
    using WinFormsApp2.Visitor.View;
    using WinFormsApp2.Visitor.View.Controls;
    using WinFormsApp2.Visitor.ViewModel;

    namespace Visitor.ViewModel
    {
        public class VisitorViewModel : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler? PropertyChanged;

            private readonly ApplicationDbContext _dbContext;
            private VisitorEntity _currentVisitor;

            public ICommand LoadEventsViewCommand { get; private set; }
            public ICommand LoadNewsViewCommand { get; private set; }
            public ICommand LoadLessonsViewCommand { get; private set; }
            public ICommand LoadProfileViewCommand { get; private set; }
            public ICommand LoadAttendanceViewCommand { get; private set; }

            private object _currentView;
            public object CurrentView
            {
                get => _currentView;
                set
                {
                    _currentView = value;
                    OnPropertyChanged();
                }
            }

            public VisitorEntity CurrentVisitor
            {
                get => _currentVisitor;
                set
                {
                    _currentVisitor = value;
                    OnPropertyChanged();
                }
            }

            public VisitorViewModel(ApplicationDbContext dbContext, VisitorEntity visitor = null)
            {
                _dbContext = dbContext;
                CurrentVisitor = visitor ?? new VisitorEntity();

                InitializeCommands();
                LoadDefaultView();
            }

            private void InitializeCommands()
            {
                LoadEventsViewCommand = new MainCommand(_ =>
                    CurrentView = new EventsViewModel(_dbContext, this));

                //LoadNewsViewCommand = new MainCommand(_ =>
                //    CurrentView = new NewsViewModel(_dbContext));

                //LoadLessonsViewCommand = new MainCommand(_ =>
                //    CurrentView = new LessonsViewModel(_dbContext, this));

                //LoadProfileViewCommand = new MainCommand(_ =>
                //    CurrentView = new ProfileViewModel(CurrentVisitor));

                //LoadAttendanceViewCommand = new MainCommand(_ =>
                //    CurrentView = new AttendanceViewModel(_dbContext, CurrentVisitor));
            }

            private void LoadDefaultView() => LoadEventsViewCommand.Execute(null);

            protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
                => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

namespace Visitor.ViewModel
    {
        public class EventsViewModel : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler? PropertyChanged;

            private readonly EventRepository _eventRepository;
            private readonly VisitorViewModel _parentViewModel;
            private List<EventEntity> _events;

            public ICommand ViewEventDetailsCommand { get; private set; }
            public ICommand RegisterForEventCommand { get; private set; }
            public ICommand BackToMainCommand { get; private set; }

            public List<EventEntity> Events
            {
                get => _events;
                set
                {
                    _events = value;
                    OnPropertyChanged();
                }
            }

            public EventsViewModel(ApplicationDbContext dbContext, VisitorViewModel parentViewModel)
            {
                _eventRepository = new EventRepository(dbContext);
                _parentViewModel = parentViewModel;
                Events = _eventRepository.Get();

                InitializeCommands();
            }

            private void InitializeCommands()
            {
                ViewEventDetailsCommand = new MainCommand(eventId =>
                {
                    if (eventId is int id)
                    {
                        var eventEntity = _eventRepository.Get(id);
                        new EventDetailsView(eventEntity, this).ShowDialog();
                    }
                });

                RegisterForEventCommand = new MainCommand(eventId =>
                {
                    if (eventId is int id)
                    {
                        var result = LogicaMessage.MessageYesNo("Вы действительно хотите зарегистрироваться на это мероприятие?");
                        if (result)
                        {
                            // Регистрационная логика
                            LogicaMessage.MessageSuccess("Вы успешно зарегистрированы на мероприятие!");
                        }
                    }
                });

                BackToMainCommand = new MainCommand(_ =>
                    _parentViewModel.CurrentView = _parentViewModel);
            }

            protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
                => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }


namespace Visitor.View
    {
        public partial class VisitorMainView : Form
        {
            private readonly VisitorViewModel _viewModel;

            public VisitorMainView(VisitorViewModel viewModel)
            {
                _viewModel = viewModel;
                InitializeComponent();
                InitializeDataBindings();
            }

            private void InitializeComponent()
            {
                Text = "Культурный центр - Панель посетителя";
                StartPosition = FormStartPosition.CenterScreen;
                WindowState = FormWindowState.Maximized;

                // Создание главного меню
                var mainMenu = CreateMainMenu();
                var contentPanel = CreateContentPanel();

                // Основная таблица
                var mainTable = FactoryElements.TableLayoutPanel()
                    .ControlAddIsRowsAbsolute(mainMenu, 60)
                    .ControlAddIsRowsPercent(contentPanel, 100);

                Controls.Add(mainTable);
            }

            private MenuStrip CreateMainMenu()
            {
                var menuStrip = FactoryElements.CreateMenuStrip(
                    FactoryElements.CreateToolStripMenu("Меню",
                        new StripMenuItem("Мероприятия", () => _viewModel.LoadEventsViewCommand.Execute(null)),
                        new StripMenuItem("Новости", () => _viewModel.LoadNewsViewCommand.Execute(null)),
                        new StripMenuItem("Кружки", () => _viewModel.LoadLessonsViewCommand.Execute(null)),
                        new StripMenuItem("Посещаемость", () => _viewModel.LoadAttendanceViewCommand.Execute(null)),
                        new StripMenuItem("Профиль", () => _viewModel.LoadProfileViewCommand.Execute(null)),
                        new StripMenuItem("Выход", Close)
                    )
                );

                return menuStrip;
            }

            private Panel CreateContentPanel()
            {
                var contentPanel = new Panel
                {
                    Dock = DockStyle.Fill,
                    Name = "contentPanel"
                };

                // Привязка текущего View
                _viewModel.PropertyChanged += (sender, e) =>
                {
                    if (e.PropertyName == nameof(_viewModel.CurrentView))
                    {
                        contentPanel.Controls.Clear();

                        if (_viewModel.CurrentView is Control control)
                        {
                            control.Dock = DockStyle.Fill;
                            contentPanel.Controls.Add(control);
                        }
                        else if (_viewModel.CurrentView is Form form)
                        {
                            // Для вложенных форм
                            form.TopLevel = false;
                            form.FormBorderStyle = FormBorderStyle.None;
                            form.Dock = DockStyle.Fill;
                            contentPanel.Controls.Add(form);
                            form.Show();
                        }
                    }
                };

                return contentPanel;
            }

            private void InitializeDataBindings()
            {
                // Пример привязки данных
                DataBindings.Add("Text", _viewModel, nameof(_viewModel.CurrentVisitor),
                    true, DataSourceUpdateMode.Never,
                    string.Empty, "Культурный центр - {0}");
            }
        }
    }

    namespace Visitor.View.Controls
    {
        public class VisitorEventCard : Panel
        {
            private readonly EventEntity _event;
            private readonly Action<EventEntity> _onDetailsClick;
            private readonly Action<EventEntity> _onRegisterClick;

            public VisitorEventCard(
                EventEntity eventEntity,
                Action<EventEntity> onDetailsClick = null,
                Action<EventEntity> onRegisterClick = null)
            {
                _event = eventEntity;
                _onDetailsClick = onDetailsClick;
                _onRegisterClick = onRegisterClick;

                InitializeCard();
                CreateContent();
            }

            private void InitializeCard()
            {
                Size = new Size(400, 250);
                Margin = new Padding(10);
                Padding = new Padding(15);
                BorderStyle = BorderStyle.FixedSingle;
                BackColor = Color.White;

                // Эффекты при наведении (похожие на административные карточки)
                MouseEnter += (s, e) => BackColor = Color.FromArgb(240, 248, 255); // LightCyan
                MouseLeave += (s, e) => BackColor = Color.White;
                Cursor = Cursors.Hand;
            }

            private void CreateContent()
            {
                var mainTable = FactoryElements.TableLayoutPanel()
                    .ControlAddIsRowsAbsolute(CreateHeader(), 60)
                    .ControlAddIsRowsAbsolute(CreateDetails(), 60)
                    .ControlAddIsRowsAbsolute(CreateDescription(), 80)
                    .ControlAddIsRowsAbsolute(CreateActions(), 40);

                Controls.Add(mainTable);
            }

            private TableLayoutPanel CreateHeader()
            {
                var titleLabel = FactoryElements.Label_12(_event.Title)
                    .With(l => l.Font = new Font("Times New Roman", 14, FontStyle.Bold))
                    .With(l => l.ForeColor = Color.DarkBlue)
                    .With(l => l.Cursor = Cursors.Hand)
                    .With(l => l.Click += (s, e) => _onDetailsClick?.Invoke(_event));

                var dateLabel = FactoryElements.Label_09($"{_event.Date} • {_event.Location}")
                    .With(l => l.ForeColor = Color.DarkGreen);

                return FactoryElements.TableLayoutPanel()
                    .ControlAddIsRowsAbsolute(titleLabel, 30)
                    .ControlAddIsRowsAbsolute(dateLabel, 20);
            }

            private TableLayoutPanel CreateDetails()
            {
                var categoryLabel = FactoryElements.Label_09($"🏷️ {_event.Category}")
                    .With(l => l.ForeColor = Color.Gray);

                var organizerLabel = FactoryElements.Label_09($"👨‍💼 {_event.Organizer}")
                    .With(l => l.ForeColor = Color.Gray);

                var participantsLabel = FactoryElements.Label_09($"👥 {_event.Participants}")
                    .With(l => l.ForeColor =
                        _event.CurrentParticipants < _event.MaxParticipants ?
                        Color.DarkGreen : Color.Red);

                var table = FactoryElements.TableLayoutPanel()
                    .ControlAddIsColumnPercent(categoryLabel, 33)
                    .ControlAddIsColumnPercent(organizerLabel, 33)
                    .ControlAddIsColumnPercent(participantsLabel, 34);

                return table;
            }

            private Label CreateDescription()
            {
                var description = _event.Description.Length > 150
                    ? _event.Description.Substring(0, 150) + "..."
                    : _event.Description;

                return FactoryElements.Label(description)
                    .With(l => l.Font = new Font("Times New Roman", 10))
                    .With(l => l.ForeColor = Color.DimGray);
            }

            private TableLayoutPanel CreateActions()
            {
                var detailsButton = FactoryElements.Button("Подробнее")
                    .With(b => b.BackColor = Color.LightBlue)
                    .With(b => b.Click += (s, e) => _onDetailsClick?.Invoke(_event));

                var registerButton = FactoryElements.Button("Зарегистрироваться")
                    .With(b => b.BackColor =
                        _event.CurrentParticipants < _event.MaxParticipants ?
                        Color.LightGreen : Color.LightGray)
                    .With(b => b.Enabled = _event.CurrentParticipants < _event.MaxParticipants)
                    .With(b => b.Click += (s, e) => _onRegisterClick?.Invoke(_event));

                return FactoryElements.TableLayoutPanel()
                    .ControlAddIsColumnPercent(detailsButton, 50)
                    .ControlAddIsColumnPercent(registerButton, 50);
            }
        }
    }

namespace Visitor.View
    {
        public class EventDetailsView : Form
        {
            private readonly EventEntity _event;
            private readonly EventsViewModel _viewModel;

            public EventDetailsView(EventEntity eventEntity, EventsViewModel viewModel = null)
            {
                _event = eventEntity;
                _viewModel = viewModel;

                InitializeComponent();
                CreateUI();
            }

            private void InitializeComponent()
            {
                Text = $"Мероприятие: {_event.Title}";
                Size = new Size(800, 700);
                StartPosition = FormStartPosition.CenterParent;
                BackColor = Color.White;
                Padding = new Padding(20);
                MaximizeBox = false;
                FormBorderStyle = FormBorderStyle.FixedDialog;
            }

            private void CreateUI()
            {
                var mainTable = FactoryElements.TableLayoutPanel()
                    .ControlAddIsRowsAbsolute(CreateHeader(), 100)
                    .ControlAddIsRowsAbsolute(CreateDetailsSection(), 150)
                    .ControlAddIsRowsPercent(CreateDescriptionSection(), 40)
                    .ControlAddIsRowsAbsolute(CreateImagesSection(), 200)
                    .ControlAddIsRowsAbsolute(CreateActionsSection(), 70);

                Controls.Add(mainTable);
            }

            private TableLayoutPanel CreateHeader()
            {
                var titleLabel = FactoryElements.Label(_event.Title)
                    .With(l => l.Font = new Font("Times New Roman", 22, FontStyle.Bold))
                    .With(l => l.ForeColor = Color.DarkBlue)
                    .With(l => l.TextAlign = ContentAlignment.MiddleCenter);

                var dateLocationLabel = FactoryElements.Label($"{_event.Date} • {_event.Location}")
                    .With(l => l.Font = new Font("Times New Roman", 14, FontStyle.Regular))
                    .With(l => l.ForeColor = Color.DarkGreen)
                    .With(l => l.TextAlign = ContentAlignment.MiddleCenter);

                var categoryLabel = FactoryElements.Label($"Категория: {_event.Category}")
                    .With(l => l.Font = new Font("Times New Roman", 12, FontStyle.Italic))
                    .With(l => l.ForeColor = Color.Gray)
                    .With(l => l.TextAlign = ContentAlignment.MiddleCenter);

                return FactoryElements.TableLayoutPanel()
                    .ControlAddIsRowsAbsolute(titleLabel, 40)
                    .ControlAddIsRowsAbsolute(dateLocationLabel, 30)
                    .ControlAddIsRowsAbsolute(categoryLabel, 20);
            }

            private TableLayoutPanel CreateDetailsSection()
            {
                var detailsTable = FactoryElements.TableLayoutPanel()
                    .AddingColumnsStyles(
                        new ColumnStyle(SizeType.Percent, 40),
                        new ColumnStyle(SizeType.Percent, 60))
                    .AddingRowsStyles(
                        new RowStyle(SizeType.Absolute, 30),
                        new RowStyle(SizeType.Absolute, 30),
                        new RowStyle(SizeType.Absolute, 30),
                        new RowStyle(SizeType.Absolute, 30),
                        new RowStyle(SizeType.Absolute, 30));

                // Организатор
                detailsTable.Controls.Add(
                    FactoryElements.Label_11("Организатор:")
                        .With(l => l.TextAlign = ContentAlignment.MiddleLeft)
                        .With(l => l.ForeColor = Color.DarkSlateGray),
                    0, 0);

                detailsTable.Controls.Add(
                    FactoryElements.Label(_event.Organizer)
                        .With(l => l.Font = new Font("Times New Roman", 11, FontStyle.Bold))
                        .With(l => l.TextAlign = ContentAlignment.MiddleLeft),
                    1, 0);

                // Участники
                detailsTable.Controls.Add(
                    FactoryElements.Label_11("Участники:")
                        .With(l => l.TextAlign = ContentAlignment.MiddleLeft)
                        .With(l => l.ForeColor = Color.DarkSlateGray),
                    0, 1);

                var participantsLabel = FactoryElements.Label(_event.Participants)
                    .With(l => l.Font = new Font("Times New Roman", 11, FontStyle.Bold))
                    .With(l => l.TextAlign = ContentAlignment.MiddleLeft)
                    .With(l => l.ForeColor =
                        _event.CurrentParticipants < _event.MaxParticipants
                        ? Color.DarkGreen
                        : Color.Red);

                detailsTable.Controls.Add(participantsLabel, 1, 1);

                // Статус
                detailsTable.Controls.Add(
                    FactoryElements.Label_11("Статус:")
                        .With(l => l.TextAlign = ContentAlignment.MiddleLeft)
                        .With(l => l.ForeColor = Color.DarkSlateGray),
                    0, 2);

                var statusText = _event.CurrentParticipants < _event.MaxParticipants
                    ? "Есть свободные места"
                    : "Мест нет";
                var statusColor = _event.CurrentParticipants < _event.MaxParticipants
                    ? Color.DarkGreen
                    : Color.Red;

                detailsTable.Controls.Add(
                    FactoryElements.Label(statusText)
                        .With(l => l.Font = new Font("Times New Roman", 11, FontStyle.Bold))
                        .With(l => l.ForeColor = statusColor)
                        .With(l => l.TextAlign = ContentAlignment.MiddleLeft),
                    1, 2);

                // Ссылка на регистрацию
                detailsTable.Controls.Add(
                    FactoryElements.Label_11("Регистрация:")
                        .With(l => l.TextAlign = ContentAlignment.MiddleLeft)
                        .With(l => l.ForeColor = Color.DarkSlateGray),
                    0, 3);

                var linkLabel = new LinkLabel
                {
                    Text = "Перейти к регистрации",
                    Font = new Font("Times New Roman", 11, FontStyle.Bold),
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleLeft,
                    LinkColor = Color.Blue,
                    ActiveLinkColor = Color.DarkBlue,
                    LinkBehavior = LinkBehavior.HoverUnderline
                };

                linkLabel.Click += (s, e) =>
                {
                    if (!string.IsNullOrWhiteSpace(_event.RegistrationLink))
                    {
                        try
                        {
                            Validatoreg.OpenLink(_event.RegistrationLink);
                        }
                        catch (Exception ex)
                        {
                            LogicaMessage.MessageError($"Не удалось открыть ссылку: {ex.Message}");
                        }
                    }
                    else
                    {
                        LogicaMessage.MessageWarning("Ссылка на регистрацию не указана");
                    }
                };

                detailsTable.Controls.Add(linkLabel, 1, 3);

                return FactoryElements.TableLayoutPanel()
                    .ControlAddIsRowsAbsolute(
                        FactoryElements.Label_12("📋 Детали мероприятия:")
                            .With(l => l.TextAlign = ContentAlignment.MiddleLeft),
                        25)
                    .ControlAddIsRowsAbsolute(detailsTable, 125);
            }

            private TextBox CreateDescriptionSection()
            {
                var descriptionBox = new TextBox
                {
                    Text = _event.Description,
                    Multiline = true,
                    ReadOnly = true,
                    Dock = DockStyle.Fill,
                    Font = new Font("Times New Roman", 11),
                    ScrollBars = ScrollBars.Vertical,
                    BorderStyle = BorderStyle.FixedSingle,
                    BackColor = Color.FromArgb(248, 249, 250),
                    Padding = new Padding(10)
                };

                var container = FactoryElements.TableLayoutPanel()
                    .ControlAddIsRowsAbsolute(
                        FactoryElements.Label_12("📝 Описание мероприятия:")
                            .With(l => l.TextAlign = ContentAlignment.MiddleLeft),
                        25)
                    .ControlAddIsRowsPercent(descriptionBox, 100);

                return descriptionBox;
            }

            private FlowLayoutPanel CreateImagesSection()
            {
                var imagesLabel = FactoryElements.Label_12("📷 Изображения мероприятия:")
                    .With(l => l.TextAlign = ContentAlignment.MiddleLeft);

                var imagesPanel = FactoryElements.FlowLayoutPanel()
                    .With(p => p.AutoScroll = true)
                    .With(p => p.Height = 180);

                // Загрузка изображений
                if (_event.ImgsEvent != null && _event.ImgsEvent.Any())
                {
                    foreach (var img in _event.ImgsEvent)
                    {
                        if (!string.IsNullOrWhiteSpace(img.Url))
                        {
                            var pictureBox = FactoryElements.Image(img.Url)
                                .With(pb => pb.Size = new Size(200, 150))
                                .With(pb => pb.Cursor = Cursors.Hand);

                            imagesPanel.Controls.Add(pictureBox);
                        }
                    }
                }
                else
                {
                    imagesPanel.Controls.Add(
                        FactoryElements.Label("Изображения отсутствуют")
                            .With(l => l.TextAlign = ContentAlignment.MiddleCenter)
                            .With(l => l.Font = new Font("Times New Roman", 11, FontStyle.Italic))
                            .With(l => l.ForeColor = Color.Gray)
                    );
                }

                var container = FactoryElements.TableLayoutPanel()
                    .ControlAddIsRowsAbsolute(imagesLabel, 25)
                    .ControlAddIsRowsAbsolute(imagesPanel, 175);

                return imagesPanel;
            }

            private TableLayoutPanel CreateActionsSection()
            {
                var registerButton = FactoryElements.Button("Зарегистрироваться")
                    .With(b => b.BackColor =
                        _event.CurrentParticipants < _event.MaxParticipants
                        ? Color.FromArgb(76, 175, 80) // Зеленый
                        : Color.FromArgb(158, 158, 158)) // Серый
                    .With(b => b.ForeColor = Color.White)
                    .With(b => b.Font = new Font("Times New Roman", 12, FontStyle.Bold))
                    .With(b => b.Enabled = _event.CurrentParticipants < _event.MaxParticipants)
                    .With(b => b.Click += (s, e) =>
                    {
                        if (_viewModel != null)
                        {
                            _viewModel.RegisterForEventCommand.Execute(_event.Id);
                            Close();
                        }
                        else
                        {
                            var result = LogicaMessage.MessageYesNo(
                                $"Вы хотите зарегистрироваться на мероприятие \"{_event.Title}\"?");

                            if (result)
                            {
                                LogicaMessage.MessageSuccess("Вы успешно зарегистрированы!");
                                Close();
                            }
                        }
                    });

                var closeButton = FactoryElements.Button("Закрыть")
                    .With(b => b.BackColor = Color.FromArgb(33, 150, 243)) // Синий
                    .With(b => b.ForeColor = Color.White)
                    .With(b => b.Click += (s, e) => Close());

                return FactoryElements.TableLayoutPanel()
                    .ControlAddIsColumnPercent(registerButton, 50)
                    .ControlAddIsColumnPercent(closeButton, 50);
            }
        }
    }

    namespace Visitor.View
    {
        public class EventsView : UserControl
        {
            private readonly EventsViewModel _viewModel;
            private FlowLayoutPanel _cardsPanel;

            public EventsView(EventsViewModel viewModel)
            {
                _viewModel = viewModel;
                InitializeComponent();
                LoadEvents();
            }

            private void InitializeComponent()
            {
                Dock = DockStyle.Fill;
                BackColor = Color.White;

                var titleLabel = FactoryElements.LabelTitle("📅 Мероприятия")
                    .With(l => l.TextAlign = ContentAlignment.MiddleCenter);

                _cardsPanel = FactoryElements.FlowLayoutPanel()
                    .With(p => p.AutoScroll = true);

                var backButton = FactoryElements.Button("← Назад")
                    .With(b => b.BackColor = Color.LightGray)
                    .With(b => b.DataBindings.Add(
                        new Binding("Command", _viewModel, nameof(_viewModel.BackToMainCommand))));

                var mainTable = FactoryElements.TableLayoutPanel()
                    .ControlAddIsRowsAbsolute(titleLabel, 70)
                    .ControlAddIsRowsPercent(_cardsPanel, 85)
                    .ControlAddIsRowsAbsolute(backButton, 40);

                Controls.Add(mainTable);
            }

            private void LoadEvents()
            {
                _cardsPanel.Controls.Clear();

                foreach (var eventItem in _viewModel.Events)
                {
                    var card = new VisitorEventCard(
                        eventItem,
                        onDetailsClick: e =>
                        {
                            // Открываем новую детальную страницу
                            var detailsForm = new EventDetailsView(e, _viewModel);
                            detailsForm.ShowDialog();
                        },
                        onRegisterClick: e => _viewModel.RegisterForEventCommand.Execute(e.Id)
                    );

                    _cardsPanel.Controls.Add(card);
                }

                if (_viewModel.Events.Count == 0)
                {
                    _cardsPanel.Controls.Add(
                        FactoryElements.Label("Нет доступных мероприятий")
                            .With(l => l.TextAlign = ContentAlignment.MiddleCenter)
                            .With(l => l.Font = new Font("Times New Roman", 14, FontStyle.Italic))
                            .With(l => l.ForeColor = Color.Gray)
                    );
                }
            }
        }
    }


    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            // В реальном приложении здесь будет аутентификация
            using (var dbContext = new ApplicationDbContext())
            {
                var visitor = new DataAccess.Postgres.Models.VisitorEntity
                {
                    Name = "Иван",
                    Surname = "Иванов",
                    Patronymic = "Иванович"
                };

                var viewModel = new VisitorViewModel(dbContext, visitor);
                Application.Run(new VisitorMainView(viewModel));
            }
        }
    }
}
