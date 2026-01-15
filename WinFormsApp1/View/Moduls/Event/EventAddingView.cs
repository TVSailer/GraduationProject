//using Admin.View.ViewForm;
//using Logica;
//using WinFormsApp1.View;

//namespace Admin.View.Moduls.Event
//{
//    public partial class EventAddingView  
//    {
//        private ErrorProvider errorProvider = new() { BlinkStyle = ErrorBlinkStyle.NeverBlink };
//        private readonly EventMinControlViewModel Context;
//        private readonly AdminMainView form;

//        public EventAddingView(AdminMainView mainForm, EventMinControlViewModel Context)
//        {
//            this.Context = Context;
//            form = mainForm;
//        }

//        private class LabelIsControl
//        {
//            public Label Label { get; private set; }
//            public Control Control { get; private set; }
//            public int Height { get; private set; }

//            public LabelIsControl(Label label, Control control, int heinght)
//            {
//                Label = label;
//                Control = control;
//                Height = heinght;
//            }
//        }

//        public Form InitializeComponents()
//            => form
//                .With(m => m.Controls.Clear())
//                .With(m => m.Text = "Добавление мероприятия")
//                .With(m => m.Controls.Add(CreateUI()));

//        private TableLayoutPanel CreateUI()
//            => FactoryElements
//                .TableLayoutPanel()
//                .ControlAddIsRowsAbsolute(FactoryElements.LabelTitle("➕ Добавление мероприятия"), 70)
//                .ControlAddIsRowsAbsolute(CreateFormFields(), 450)
//                .ControlAddIsRowsPercentV2(CreateImagesSection(), 20)
//                .ControlAddIsRowsAbsolute(CreateButtonPanel(), 90);

//        private TableLayoutPanel CreateFormFields()
//        {
//            var labelIsControls = new[]
//            {
//                new LabelIsControl(
//                    FactoryElements.Label_11("📝 Название мероприятия:*"),
//                    FactoryElements.TextBox("Введите название мероприятия")
//                       .With(t => t.TextChanged += (s, e) => Context.Title = t.Text)
//                       .With(t => OnErrorProvider(nameof(Context.Title), t)), 45),
//                new LabelIsControl(
//                    FactoryElements.Label_11("📄 Описание:*"),
//                    FactoryElements.TextBoxMultiline("Введите описание мероприятия")
//                        .With(t => t.TextChanged += (s, e) => Context.Description = t.Text)
//                        .With(t => OnErrorProvider(nameof(Context.Description), t)), 110),
//                new LabelIsControl(
//                    FactoryElements.Label_11("📅 Дата проведения:*"),
//                    FactoryElements.DateTimePicker()
//                        .With(d => d.Format = DateTimePickerFormat.Custom)
//                        .With(d => d.CustomFormat = "dd.MM.yyyy HH:mm")
//                        .With(d => d.ShowUpDown = true)
//                        .With(d => d.MinDate = DateTime.Now)
//                        .With(t => t.TextChanged += (s, e) => Context.Date = t.Text)
//                        .With(t => OnErrorProvider(nameof(Context.Date), t)), 45),
//                new LabelIsControl(
//                    FactoryElements.Label_11("📍 Место проведения:*"),
//                    FactoryElements.TextBox("Введите место проведения")
//                    .With(t => t.TextChanged += (s, e) => Context.Location = t.Text)
//                    .With(t => OnErrorProvider(nameof(Context.Location), t)), 45),
//                new LabelIsControl(
//                    FactoryElements.Label_11("🏷️ Категория:*"),
//                    FactoryElements.TextBox("Например: Образование, Спорт, Культура")
//                    .With(t => t.TextChanged +=(s, e) => Context.Category = t.Text)
//                    .With(t => OnErrorProvider(nameof(Context.Category), t)), 45),
//                new LabelIsControl(
//                    FactoryElements.Label_11("🔗 Ссылка на регистрацию:*"),
//                    FactoryElements.TextBox("https://example.com/registration")
//                    .With(t => t.TextChanged += (s, e) => Context.RegisLink = t.Text)
//                    .With(t => OnErrorProvider(nameof(Context.RegisLink), t)), 45),
//                new LabelIsControl(
//                    FactoryElements.Label_11("👨‍💼 Организатор:*"),
//                    FactoryElements.TextBox("Введите организатора мероприятия")
//                    .With(t => t.TextChanged += (s, e) => Context.Organizer = t.Text)
//                    .With(t => OnErrorProvider(nameof(Context.Organizer), t)), 45),
//                new LabelIsControl(
//                    FactoryElements.Label_11("👥 Максимальное количество участников:*"),
//                    FactoryElements.NumericUpDown()
//                    .With(t => t.TextChanged += (s, e) => Context.MaxParticipants = t.Text)
//                    .With(t => OnErrorProvider(nameof(Context.MaxParticipants), t)), 45)
//            };

//            return FactoryElements.TableLayoutPanel()
//                .With(t => t.Dock = DockStyle.Fill)
//                .With(t => labelIsControls.ForEach(f 
//                    => t.ControlAddIsRowsAbsolute(FactoryElements
//                        .TableLayoutPanel()
//                        .With(t => t.Padding = new Padding(1))
//                        .ControlAddIsColumnPercent(f.Label, 30)
//                        .ControlAddIsColumnPercent(f.Control, 70)
//                        .ControlAddIsColumnAbsolute(null, 1), f.Height)));
//        }

//        private void OnErrorProvider(string propertyName, Control control)
//        {
//            Context.ErrorMassegeProvider += (s, e) =>
//            {
//                if (!propertyName.Equals(e.PropertyName)) return;
//                errorProvider.SetError(control, e.ErrorMessage);
//            };
//        }

//        private TableLayoutPanel CreateImagesSection()
//            => FactoryElements.TableLayoutPanel()
//            .ControlAddIsRowsAbsolute(
//                FactoryElements.Label_12("📷 Изображения:"), 50)
//            .ControlAddIsRowsPercentV2(
//                FactoryElements.FlowLayoutPanel()
//                .With(fp => Context.SelectedImg.ForEach(url => fp.Controls.Add(FactoryElements.PictureBox(url.Key)
//                    .With(i => i.MouseClick +=
//                    (s, e) =>
//                    {
//                        Context.SelectedImg[url.Key] = !Context.SelectedImg[url.Key];
//                        i.BackColor = Context.SelectedImg[url.Key] ? Color.Gray : Color.Black;
//                    }))))
//                .With(fp => Context.PropertyChanged +=
//                (obj, propCh) =>
//                {
//                    if (propCh.PropertyName == nameof(Context.OnAddingImg) || propCh.PropertyName == nameof(Context.OnDeletingImg))
//                    {
//                        fp.Controls.Clear();
//                        Context.SelectedImg.ForEach(
//                        url =>
//                        {
//                            fp.Controls.Add(FactoryElements.PictureBox(url.Key)
//                            .With(i => i.MouseClick +=
//                            (s, e) =>
//                            {
//                                Context.SelectedImg[url.Key] = !Context.SelectedImg[url.Key];
//                                i.BackColor = Context.SelectedImg[url.Key] ? Color.Gray : Color.Black;
//                            }));
//                        });
//                    }
//                }), 10);

//        private TableLayoutPanel CreateButtonPanel()
//            => FactoryElements.TableLayoutPanel()
//                .ControlAddIsColumnPercent(FactoryElements.Button("❌ Удалить изображение", Context, "OnDeletingImg"), 40)
//                .ControlAddIsColumnPercent(FactoryElements.Button("➕ Добавить изображения", Context, "OnAddingImg"), 40)
//                .ControlAddIsColumnPercent(FactoryElements.Button("💾 Сохранить", Context, "actjionSave"), 40)
//                .ControlAddIsColumnPercent(FactoryElements.Button("❌ Отмена", Context, "OnBack"), 40);

//        public Form InitializeComponents(object? data)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}