using Logica;

namespace AdminApp.Forms
{
    public partial class AddEventView
    {
        private AddEventViewModel context;

        public AddEventView(Form mainForm, AddEventViewModel context)
        {
            this.context = context;
            InitializeComponent(mainForm);
        }

        private class LabelIsControl
        {
            public Label Label { get; private set; }
            public Control Control { get; private set; }
            public int Height { get; private set; }

            public LabelIsControl(Label label, Control control, int heinght)
            {
                Label = label;
                Control = control;
                Height = heinght;
            }

        }

        private void InitializeComponent(Form form)
        {
            form
                .With(m => m.Controls.Clear())
                .With(m => m.WindowState = FormWindowState.Maximized)
                .With(m => m.StartPosition = FormStartPosition.CenterParent)
                .With(m => m.BackColor = Color.White)
                .With(f => f.Text = "Добавление мероприятия")
                .With(m => m.Controls.Add(CreateUI()));
        }

        private TableLayoutPanel CreateUI()
            => FactoryElements
                .TableLayoutPanel()
                .ControlAddIsRowsAbsoluteV2(FactoryElements.LabelTitle("➕ Добавление мероприятия"), 70)
                .ControlAddIsRowsAbsoluteV2(CreateFormFields(), 450)
                .ControlAddIsRowsPercentV2(CreateImagesSection(), 20)
                .ControlAddIsRowsAbsoluteV2(CreateButtonPanel(), 90);

        private TableLayoutPanel CreateFormFields()
        {
            var labelIsControls = new[]
            {
                new LabelIsControl(
                    FactoryElements.Label_11("📝 Название мероприятия:*"),
                    FactoryElements.TextBox("Введите название мероприятия")
                        .With(t => t.TextChanged += (s, e) => context.Title = t.Text)
                        .With(t => context.ControlOnProperty.Add(OnPropertyAddEventViewModel.Title, t)), 45),
                new LabelIsControl(
                    FactoryElements.Label_11("📄 Описание:*"),
                    FactoryElements.TextBoxMultiline("Введите описание мероприятия")
                        .With(t => t.TextChanged += (s, e) => context.Description = t.Text)
                        .With(t => context.ControlOnProperty.Add(OnPropertyAddEventViewModel.Description, t)), 110),
                new LabelIsControl(
                    FactoryElements.Label_11("📅 Дата проведения:*"), 
                    FactoryElements.DateTimePicker()
                        .With(d => d.Format = DateTimePickerFormat.Custom)
                        .With(d => d.CustomFormat = "dd.MM.yyyy HH:mm")
                        .With(d => d.ShowUpDown = true)
                        .With(d => d.MinDate = DateTime.Now)
                        .With(t => t.TextChanged += (s, e) => context.Date = t.Text)
                        .With(t => context.ControlOnProperty.Add(OnPropertyAddEventViewModel.Date, t)), 45),
                new LabelIsControl(
                    FactoryElements.Label_11("📍 Место проведения:*"), 
                    FactoryElements.TextBox("Введите место проведения")
                    .With(t => t.TextChanged += (s, e) => context.Location = t.Text)
                    .With(t => context.ControlOnProperty.Add(OnPropertyAddEventViewModel.Location, t)), 45),
                new LabelIsControl(
                    FactoryElements.Label_11("🏷️ Категория:*"),
                    FactoryElements.TextBox("Например: Образование, Спорт, Культура")
                    .With(t => t.TextChanged +=(s, e) => context.Category = t.Text)
                    .With(t => context.ControlOnProperty.Add(OnPropertyAddEventViewModel.Category, t)), 45),
                new LabelIsControl(
                    FactoryElements.Label_11("🔗 Ссылка на регистрацию:*"), 
                    FactoryElements.TextBox("https://example.com/registration")
                    .With(t => t.TextChanged += (s, e) => context.RegisLink = t.Text)
                    .With(t => context.ControlOnProperty.Add(OnPropertyAddEventViewModel.RegisLink , t)), 45),
                new LabelIsControl(
                    FactoryElements.Label_11("👨‍💼 Организатор:*"),
                    FactoryElements.TextBox("Введите организатора мероприятия")
                    .With(t => t.TextChanged += (s, e) => context.Organizer = t.Text)
                    .With(t => context.ControlOnProperty.Add(OnPropertyAddEventViewModel.Organizer, t)), 45),
                new LabelIsControl(
                    FactoryElements.Label_11("👥 Максимальное количество участников:*"), 
                    FactoryElements.NumericUpDown()
                    .With(t => t.TextChanged += (s, e) => context.MaxParticipants = int.Parse(t.Text))
                    .With(t => context.ControlOnProperty.Add(OnPropertyAddEventViewModel.MaxParticipants, t)), 45)
            };

            return FactoryElements.TableLayoutPanel()
                .With(t => t.Dock = DockStyle.Fill)
                .With(t => labelIsControls.ForEach(f 
                    => t.ControlAddIsRowsAbsoluteV2(FactoryElements
                        .TableLayoutPanel()
                        .With(t => t.Padding = new Padding(1))
                        .ControlAddIsColumnPercentV2(f.Label, 30)
                        .ControlAddIsColumnPercentV2(f.Control, 70)
                        .ControlAddIsColumnAbsoluteV2(null, 1), f.Height)));
        }

        private TableLayoutPanel CreateImagesSection()
            => FactoryElements.TableLayoutPanel()
            .ControlAddIsRowsAbsoluteV2(
                FactoryElements.Label_12("📷 Изображения мероприятия:"), 50)
            .ControlAddIsRowsPercentV2(
                FactoryElements.FlowLayoutPanel()
                .With(f => context.PropertyChanged += (obj, propCh) 
                =>
                {
                    f.Controls.Clear();
                    context.SelectedImg.ForEach(
                    url =>
                    {
                        f.Controls.Add(FactoryElements.Image(url.Key)
                        .With(i => i.MouseClick +=
                        (s, e) =>
                        {
                            context.SelectedImg[url.Key] = !context.SelectedImg[url.Key];
                            i.BackColor = context.SelectedImg[url.Key] ? Color.Gray : Color.Black;
                        }));
                    });
                }), 10);

        private TableLayoutPanel CreateButtonPanel()
            => FactoryElements.TableLayoutPanel()
                .ControlAddIsColumnPercentV2(FactoryElements.Button("❌ Удалить изображение", context, "OnDeletingImg"), 40)
                .ControlAddIsColumnPercentV2(FactoryElements.Button("➕ Добавить изображения", context, "OnAddingImg"), 40)
                .ControlAddIsColumnPercentV2(FactoryElements.Button("💾 Сохранить", context, "OnSave"), 40)
                .ControlAddIsColumnPercentV2(FactoryElements.Button("❌ Отмена", context, "OnBack"), 40);
    }
}