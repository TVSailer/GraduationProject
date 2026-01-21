//using Admin.View.ViewForm;
//using Logica;
//using WinFormsApp1.View;

//namespace Admin.View.Moduls.Event
//{
//    public partial class EventAddingView  
//    {
//        private ErrorProvider errorProvider = new() { BlinkStyle = ErrorBlinkStyle.NeverBlink };
//        private readonly EventData context;
//        private readonly AdminMainView form;

//        public EventAddingView(AdminMainView mainForm, EventData context)
//        {
//            this.context = context;
//            form = mainForm;
//        }

//        private class LabelIsControl
//        {
//            public Label Label { get; private set; }
//            public NameMethod NameMethod { get; private set; }
//            public int Height { get; private set; }

//            public LabelIsControl(Label label, NameMethod Control, int heinght)
//            {
//                Label = label;
//                NameMethod = Control;
//                Height = heinght;
//            }
//        }

//        public Form InitializeComponents()
//            => form
//                .With(m => m.Controls.Clear())
//                .With(m => m.LabelText = "Добавление мероприятия")
//                .With(m => m.Controls.Add(CreateUI()));

//        private TableLayoutPanel CreateUI()
//            => FactoryElements
//                .TableLayoutPanel()
//                .ControlAddIsRow(FactoryElements.LabelTitle("➕ Добавление мероприятия"), 70)
//                .ControlAddIsRow(CreateFormFields(), 450)
//                .ControlAddIsRowsPercent(CreateImagesSection(), 20)
//                .ControlAddIsRow(CreateButtonPanel(), 90);

//        private TableLayoutPanel CreateFormFields()
//        {
//            var labelIsControls = new[]
//            {
//                new LabelIsControl(
//                    FactoryElements.Label_11("📝 Название мероприятия:*"),
//                    FactoryElements.TextBox("Введите название мероприятия")
//                       .With(t => t.TextChanged += (s, e) => context.Title = t.LabelText)
//                       .With(t => OnErrorProvider(nameof(context.Title), t)), 45),
//                new LabelIsControl(
//                    FactoryElements.Label_11("📄 Описание:*"),
//                    FactoryElements.TextBoxMultiline("Введите описание мероприятия")
//                        .With(t => t.TextChanged += (s, e) => context.Description = t.LabelText)
//                        .With(t => OnErrorProvider(nameof(context.Description), t)), 110),
//                new LabelIsControl(
//                    FactoryElements.Label_11("📅 Дата проведения:*"),
//                    FactoryElements.DateTimePickerCustom()
//                        .With(d => d.Format = DateTimePickerFormat.Custom)
//                        .With(d => d.CustomFormat = "dd.MM.yyyy HH:mm")
//                        .With(d => d.ShowUpDown = true)
//                        .With(d => d.MinDate = DateTime.Now)
//                        .With(t => t.TextChanged += (s, e) => context.Date = t.LabelText)
//                        .With(t => OnErrorProvider(nameof(context.Date), t)), 45),
//                new LabelIsControl(
//                    FactoryElements.Label_11("📍 Место проведения:*"),
//                    FactoryElements.TextBox("Введите место проведения")
//                    .With(t => t.TextChanged += (s, e) => context.Location = t.LabelText)
//                    .With(t => OnErrorProvider(nameof(context.Location), t)), 45),
//                new LabelIsControl(
//                    FactoryElements.Label_11("🏷️ Категория:*"),
//                    FactoryElements.TextBox("Например: Образование, Спорт, Культура")
//                    .With(t => t.TextChanged +=(s, e) => context.Category = t.LabelText)
//                    .With(t => OnErrorProvider(nameof(context.Category), t)), 45),
//                new LabelIsControl(
//                    FactoryElements.Label_11("🔗 Ссылка на регистрацию:*"),
//                    FactoryElements.TextBox("https://example.com/registration")
//                    .With(t => t.TextChanged += (s, e) => context.RegisLink = t.LabelText)
//                    .With(t => OnErrorProvider(nameof(context.RegisLink), t)), 45),
//                new LabelIsControl(
//                    FactoryElements.Label_11("👨‍💼 Организатор:*"),
//                    FactoryElements.TextBox("Введите организатора мероприятия")
//                    .With(t => t.TextChanged += (s, e) => context.Organizer = t.LabelText)
//                    .With(t => OnErrorProvider(nameof(context.Organizer), t)), 45),
//                new LabelIsControl(
//                    FactoryElements.Label_11("👥 Максимальное количество участников:*"),
//                    FactoryElements.NumericUpDown()
//                    .With(t => t.TextChanged += (s, e) => context.MaxParticipants = t.LabelText)
//                    .With(t => OnErrorProvider(nameof(context.MaxParticipants), t)), 45)
//            };

//            return FactoryElements.TableLayoutPanel()
//                .With(t => t.Dock = DockStyle.Fill)
//                .With(t => labelIsControls.ForEach(f 
//                    => t.ControlAddIsRow(FactoryElements
//                        .TableLayoutPanel()
//                        .With(t => t.Padding = new Padding(1))
//                        .ControlAddIsColumnPercent(f.Label, 30)
//                        .ControlAddIsColumnPercent(f.NameMethod, 70)
//                        .ControlAddIsColumnAbsolute(null, 1), f.Height)));
//        }

//        private void OnErrorProvider(string propertyName, NameMethod Control)
//        {
//            context.ErrorMassegeProvider += (s, e) =>
//            {
//                if (!propertyName.Equals(e.PropertyName)) return;
//                errorProvider.SetError(Control, e.ErrorMessage);
//            };
//        }

//        private TableLayoutPanel CreateImagesSection()
//            => FactoryElements.TableLayoutPanel()
//            .ControlAddIsRow(
//                FactoryElements.Label_12("📷 Изображения:"), 50)
//            .ControlAddIsRowsPercent(
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
//                .ControlAddIsColumnPercent(FactoryElements.Button("❌ Удалить изображение", context, "OnDeletingImg"), 40)
//                .ControlAddIsColumnPercent(FactoryElements.Button("➕ Добавить изображения", context, "OnAddingImg"), 40)
//                .ControlAddIsColumnPercent(FactoryElements.Button("💾 Сохранить", context, "actjionSave"), 40)
//                .ControlAddIsColumnPercent(FactoryElements.Button("❌ Отмена", context, "OnBack"), 40);

//        public Form InitializeComponents(object? data)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}