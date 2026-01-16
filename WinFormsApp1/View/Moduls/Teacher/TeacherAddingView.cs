//using Admin.View.ViewForm;
//using Admin.ViewModels.Teachers;
//using Logica;
//using WinFormsApp1.View;

//namespace Admin.View.Moduls.TeacherFIO
//{
//    public class TeacherAddingView 
//    {
//        private ErrorProvider errorProvider = new() { BlinkStyle = ErrorBlinkStyle.NeverBlink };
//        private readonly TeacherAddingViewModel context;
//        private readonly AdminMainView form;

//        public TeacherAddingView(AdminMainView mainView, TeacherAddingViewModel modelView)
//        {
//            form = mainView;
//            context = modelView;
//        }

//        public Form InitializeComponents()
//            => form
//            .With(f => f.Controls.Clear())
//            .With(f => f.Text = "Добавление преподователя")
//            .With(f => f.Controls.Add(CreateUI()));

//        private TableLayoutPanel CreateUI()
//            => FactoryElements
//                .TableLayoutPanel()
//                .ControlAddIsRow(FactoryElements.LabelTitle("➕ Добавление преподователя"), 70)
//                .ControlAddIsRow(CreateFormFields(), 450)
//                .ControlAddIsRowsPercent()
//                .ControlAddIsRow(CreateButtonPanel(), 90);

//        private TableLayoutPanel CreateFormFields()
//            => FactoryElements.TableLayoutPanel()
//                .ControlAddIsColumnPercent(FactoryElements.TableLayoutPanel()
//                    .ControlAddIsRow(FactoryElements.TableLayoutPanel()
//                        .ControlAddIsColumnPercent(FactoryElements.Label_11("Имя:*"), 30)
//                        .ControlAddIsColumnPercent(FactoryElements.TextBox("Введите имя")
//                            .With(t => t.TextChanged += (s, e) => context.Name = t.Text)
//                            .With(t => OnErrorProvider(nameof(context.Name), t)), 70)
//                        .ControlAddIsColumnAbsolute(null, 5), 60)
//                    .ControlAddIsRow(FactoryElements.TableLayoutPanel()
//                        .ControlAddIsColumnPercent(FactoryElements.Label_11("Фамилия:*"), 30)
//                        .ControlAddIsColumnPercent(FactoryElements.TextBox("Введите фамилию")
//                            .With(t => t.TextChanged += (s, e) => context.Surname = t.Text)
//                            .With(t => OnErrorProvider(nameof(context.Surname), t)), 70)
//                        .ControlAddIsColumnAbsolute(null, 5), 60)
//                    .ControlAddIsRow(FactoryElements.TableLayoutPanel()
//                        .ControlAddIsColumnPercent(FactoryElements.Label_11("Отчество:*"), 30)
//                        .ControlAddIsColumnPercent(FactoryElements.TextBox("Введите отчество")
//                            .With(t => t.TextChanged += (s, e) => context.Patronymic = t.Text)
//                            .With(t => OnErrorProvider(nameof(context.Patronymic), t)), 70)
//                        .ControlAddIsColumnAbsolute(null, 5), 60)
//                    .ControlAddIsRow(FactoryElements.TableLayoutPanel()
//                        .ControlAddIsColumnPercent(FactoryElements.Label_11("Дата рождения:*"), 30)
//                        .ControlAddIsColumnPercent(FactoryElements.DateTimePicker()
//                            .With(d => d.Format = DateTimePickerFormat.Custom)
//                            .With(d => d.CustomFormat = "dd.MM.yyyy")
//                            .With(d => d.ShowUpDown = true)
//                            .With(t => t.TextChanged += (s, e) => context.DateBirth = t.Text)
//                            .With(t => OnErrorProvider(nameof(context.DateBirth), t)), 70)
//                        .ControlAddIsColumnAbsolute(null, 5), 60)
//                    .ControlAddIsRow(FactoryElements.TableLayoutPanel()
//                        .ControlAddIsColumnPercent(FactoryElements.Label_11("Номер тел.:*"), 30)
//                        .ControlAddIsColumnPercent(FactoryElements.TextBox("Введите номер тел.")
//                            .With(t => t.TextChanged += (s, e) => context.NumberPhone = t.Text)
//                            .With(t => OnErrorProvider(nameof(context.NumberPhone), t)), 70)
//                        .ControlAddIsColumnAbsolute(null, 5), 60), 80)
//                .ControlAddIsColumnPercent(null, 10)
//                .ControlAddIsColumnAbsolute(FactoryElements.PictureBox("")
//                    .With(i => i.Dock = DockStyle.Fill)
//                    .With(i => i.Click += (s, e) => context.OnAddingImg.Execute(null))
//                    .With(i => i.DataBindings.Add(new Binding(nameof(i.ImageLocation), context, nameof(context.UrlFaceImg)))), 300)
//                .ControlAddIsColumnPercent(null, 10);

//        private void OnErrorProvider(string propertyName, Control control)
//        {
//            context.ErrorMassegeProvider += (s, e) =>
//            {
//                if (!propertyName.Equals(e.PropertyName)) return;
//                errorProvider.SetError(control, e.ErrorMessage);
//            };
//        }

//        private TableLayoutPanel CreateButtonPanel()
//            => FactoryElements.TableLayoutPanel()
//                .ControlAddIsColumnPercent(FactoryElements.Button("❌ Удалить изображение", context, nameof(context.OnDeletingImg)), 40)
//                .ControlAddIsColumnPercent(FactoryElements.Button(""), 40)
//                .ControlAddIsColumnPercent(FactoryElements.Button("💾 Сохранить", context, nameof(context.actjionSave)), 40)
//                .ControlAddIsColumnPercent(FactoryElements.Button("❌ Отмена", context, nameof(context.OnBack)), 40);
//    }
//}
