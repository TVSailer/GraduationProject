using DataAccess.Postgres.Models;
using Logica;
using Logica.Extension;

namespace AdminApp.Forms
{
    public partial class AddEventView
    {
        private AddEventViewModel context;
        private List<LabelIsControl> labelIsControls;
        private FlowLayoutPanel images;

        public AddEventView(Form mainForm, AddEventViewModel context)
        {
            this.context = context;
            images = FactoryElements.FlowLayoutPanel();
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
            labelIsControls = new()
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
            .ControlAddIsRowsAbsoluteV2(FactoryElements.Label_12("📷 Изображения мероприятия:"), 50)
            .ControlAddIsRowsPercentV2(images, 10);

        private void AddImages()
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
                openFileDialog.Title = "Выберите изображения мероприятия";
                openFileDialog.Multiselect = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    foreach (var fileName in openFileDialog.FileNames)
                    {
                        images.Controls.Add(FactoryElements.Image(fileName)
                            .With(img => img.Click += (s, e) => FullSizeImage(fileName)));
                    }
                }
            }
        }

        private void FullSizeImage(string imgUrl)
            => new Form()
                .With(f => f.Text = $"Просмотр изображения: {System.IO.Path.GetFileName(imgUrl)}")
                .With(f => f.Size = new Size(800, 600))
                .With(f => f.StartPosition = FormStartPosition.CenterParent)
                .With(f => f.BackColor = Color.Black)
                .With(f => f.Controls.Add(
                    new PictureBox()
                    .With(pb => pb.Dock = DockStyle.Fill)
                    .With(pb => pb.SizeMode = PictureBoxSizeMode.Zoom)
                    .With(pb => pb.BackColor = Color.Black)
                    .With(pb => pb.ImageLocation = imgUrl)))
                .ShowDialog();

        private TableLayoutPanel CreateButtonPanel()
            => FactoryElements.TableLayoutPanel()
                .ControlAddIsColumnPercentV2(FactoryElements.Button("❌ Удалить изображение", context, "OnDeletingImg"), 40)
                .ControlAddIsColumnPercentV2(FactoryElements.Button("➕ Добавить изображения", context, "OnAddingImg"), 40)
                .ControlAddIsColumnPercentV2(FactoryElements.Button("💾 Сохранить", context, "OnSave"), 40)
                .ControlAddIsColumnPercentV2(FactoryElements.Button("❌ Отмена", context, "OnBack"), 40);
    }
}