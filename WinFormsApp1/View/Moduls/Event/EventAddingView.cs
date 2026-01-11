//using Admin.View.ViewForm;
//using Logica;
//using WinFormsApp1.View;

//namespace Admin.View.Moduls.Event
//{
//    public partial class EventAddingView  
//    {
//        private ErrorProvider errorProvider = new() { BlinkStyle = ErrorBlinkStyle.NeverBlink };
//        private readonly EventMinControlViewModel context;
//        private readonly AdminMainView form;

//        public EventAddingView(AdminMainView mainForm, EventMinControlViewModel context)
//        {
//            this.context = context;
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
//                .ControlAddIsRowsAbsoluteV2(FactoryElements.LabelTitle("➕ Добавление мероприятия"), 70)
//                .ControlAddIsRowsAbsoluteV2(CreateFormFields(), 450)
//                .ControlAddIsRowsPercentV2(CreateImagesSection(), 20)
//                .ControlAddIsRowsAbsoluteV2(CreateButtonPanel(), 90);

//        private TableLayoutPanel CreateFormFields()
//        {
//            var labelIsControls = new[]
//            {
//                new LabelIsControl(
//                    FactoryElements.Label_11("📝 Название мероприятия:*"),
//                    FactoryElements.TextBox("Введите название мероприятия")
//                       .With(t => t.TextChanged += (s, e) => context.Title = t.Text)
//                       .With(t => OnErrorProvider(nameof(context.Title), t)), 45),
//                new LabelIsControl(
//                    FactoryElements.Label_11("📄 Описание:*"),
//                    FactoryElements.TextBoxMultiline("Введите описание мероприятия")
//                        .With(t => t.TextChanged += (s, e) => context.Description = t.Text)
//                        .With(t => OnErrorProvider(nameof(context.Description), t)), 110),
//                new LabelIsControl(
//                    FactoryElements.Label_11("📅 Дата проведения:*"),
//                    FactoryElements.DateTimePicker()
//                        .With(d => d.Format = DateTimePickerFormat.Custom)
//                        .With(d => d.CustomFormat = "dd.MM.yyyy HH:mm")
//                        .With(d => d.ShowUpDown = true)
//                        .With(d => d.MinDate = DateTime.Now)
//                        .With(t => t.TextChanged += (s, e) => context.Date = t.Text)
//                        .With(t => OnErrorProvider(nameof(context.Date), t)), 45),
//                new LabelIsControl(
//                    FactoryElements.Label_11("📍 Место проведения:*"),
//                    FactoryElements.TextBox("Введите место проведения")
//                    .With(t => t.TextChanged += (s, e) => context.Location = t.Text)
//                    .With(t => OnErrorProvider(nameof(context.Location), t)), 45),
//                new LabelIsControl(
//                    FactoryElements.Label_11("🏷️ Категория:*"),
//                    FactoryElements.TextBox("Например: Образование, Спорт, Культура")
//                    .With(t => t.TextChanged +=(s, e) => context.Category = t.Text)
//                    .With(t => OnErrorProvider(nameof(context.Category), t)), 45),
//                new LabelIsControl(
//                    FactoryElements.Label_11("🔗 Ссылка на регистрацию:*"),
//                    FactoryElements.TextBox("https://example.com/registration")
//                    .With(t => t.TextChanged += (s, e) => context.RegisLink = t.Text)
//                    .With(t => OnErrorProvider(nameof(context.RegisLink), t)), 45),
//                new LabelIsControl(
//                    FactoryElements.Label_11("👨‍💼 Организатор:*"),
//                    FactoryElements.TextBox("Введите организатора мероприятия")
//                    .With(t => t.TextChanged += (s, e) => context.Organizer = t.Text)
//                    .With(t => OnErrorProvider(nameof(context.Organizer), t)), 45),
//                new LabelIsControl(
//                    FactoryElements.Label_11("👥 Максимальное количество участников:*"),
//                    FactoryElements.NumericUpDown()
//                    .With(t => t.TextChanged += (s, e) => context.MaxParticipants = t.Text)
//                    .With(t => OnErrorProvider(nameof(context.MaxParticipants), t)), 45)
//            };

//            return FactoryElements.TableLayoutPanel()
//                .With(t => t.Dock = DockStyle.Fill)
//                .With(t => labelIsControls.ForEach(f 
//                    => t.ControlAddIsRowsAbsoluteV2(FactoryElements
//                        .TableLayoutPanel()
//                        .With(t => t.Padding = new Padding(1))
//                        .ControlAddIsColumnPercentV2(f.Label, 30)
//                        .ControlAddIsColumnPercentV2(f.Control, 70)
//                        .ControlAddIsColumnAbsoluteV2(null, 1), f.Height)));
//        }

//        private void OnErrorProvider(string propertyName, Control control)
//        {
//            context.ErrorMassegeProvider += (s, e) =>
//            {
//                if (!propertyName.Equals(e.PropertyName)) return;
//                errorProvider.SetError(control, e.ErrorMessage);
//            };
//        }

//        private TableLayoutPanel CreateImagesSection()
//            => FactoryElements.TableLayoutPanel()
//            .ControlAddIsRowsAbsoluteV2(
//                FactoryElements.Label_12("📷 Изображения:"), 50)
//            .ControlAddIsRowsPercentV2(
//                FactoryElements.FlowLayoutPanel()
//                .With(fp => context.SelectedImg.ForEach(url => fp.Controls.Add(FactoryElements.PictureBox(url.Key)
//                    .With(i => i.MouseClick +=
//                    (s, e) =>
//                    {
//                        context.SelectedImg[url.Key] = !context.SelectedImg[url.Key];
//                        i.BackColor = context.SelectedImg[url.Key] ? Color.Gray : Color.Black;
//                    }))))
//                .With(fp => context.PropertyChanged +=
//                (obj, propCh) =>
//                {
//                    if (propCh.PropertyName == nameof(context.OnAddingImg) || propCh.PropertyName == nameof(context.OnDeletingImg))
//                    {
//                        fp.Controls.Clear();
//                        context.SelectedImg.ForEach(
//                        url =>
//                        {
//                            fp.Controls.Add(FactoryElements.PictureBox(url.Key)
//                            .With(i => i.MouseClick +=
//                            (s, e) =>
//                            {
//                                context.SelectedImg[url.Key] = !context.SelectedImg[url.Key];
//                                i.BackColor = context.SelectedImg[url.Key] ? Color.Gray : Color.Black;
//                            }));
//                        });
//                    }
//                }), 10);

//        private TableLayoutPanel CreateButtonPanel()
//            => FactoryElements.TableLayoutPanel()
//                .ControlAddIsColumnPercentV2(FactoryElements.Button("❌ Удалить изображение", context, "OnDeletingImg"), 40)
//                .ControlAddIsColumnPercentV2(FactoryElements.Button("➕ Добавить изображения", context, "OnAddingImg"), 40)
//                .ControlAddIsColumnPercentV2(FactoryElements.Button("💾 Сохранить", context, "actjionSave"), 40)
//                .ControlAddIsColumnPercentV2(FactoryElements.Button("❌ Отмена", context, "OnBack"), 40);

//        public Form InitializeComponents(object? data)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}