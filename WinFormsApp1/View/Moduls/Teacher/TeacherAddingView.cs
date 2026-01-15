//using Admin.View.ViewForm;
//using Admin.ViewModels.Teachers;
//using Logica;
//using WinFormsApp1.View;

//namespace Admin.View.Moduls.Teacher
//{
//    public class TeacherAddingView 
//    {
//        private ErrorProvider errorProvider = new() { BlinkStyle = ErrorBlinkStyle.NeverBlink };
//        private readonly TeacherAddingViewModel Context;
//        private readonly AdminMainView form;

//        public TeacherAddingView(AdminMainView mainView, TeacherAddingViewModel modelView)
//        {
//            form = mainView;
//            Context = modelView;
//        }

//        public Form InitializeComponents()
//            => form
//            .With(f => f.Controls.Clear())
//            .With(f => f.Text = "Добавление преподователя")
//            .With(f => f.Controls.Add(CreateUI()));

//        private TableLayoutPanel CreateUI()
//            => FactoryElements
//                .TableLayoutPanel()
//                .ControlAddIsRowsAbsolute(FactoryElements.LabelTitle("➕ Добавление преподователя"), 70)
//                .ControlAddIsRowsAbsolute(CreateFormFields(), 450)
//                .ControlAddIsRowsPercentV2()
//                .ControlAddIsRowsAbsolute(CreateButtonPanel(), 90);

//        private TableLayoutPanel CreateFormFields()
//            => FactoryElements.TableLayoutPanel()
//                .ControlAddIsColumnPercent(FactoryElements.TableLayoutPanel()
//                    .ControlAddIsRowsAbsolute(FactoryElements.TableLayoutPanel()
//                        .ControlAddIsColumnPercent(FactoryElements.Label_11("Имя:*"), 30)
//                        .ControlAddIsColumnPercent(FactoryElements.TextBox("Введите имя")
//                            .With(t => t.TextChanged += (s, e) => Context.Name = t.Text)
//                            .With(t => OnErrorProvider(nameof(Context.Name), t)), 70)
//                        .ControlAddIsColumnAbsolute(null, 5), 60)
//                    .ControlAddIsRowsAbsolute(FactoryElements.TableLayoutPanel()
//                        .ControlAddIsColumnPercent(FactoryElements.Label_11("Фамилия:*"), 30)
//                        .ControlAddIsColumnPercent(FactoryElements.TextBox("Введите фамилию")
//                            .With(t => t.TextChanged += (s, e) => Context.Surname = t.Text)
//                            .With(t => OnErrorProvider(nameof(Context.Surname), t)), 70)
//                        .ControlAddIsColumnAbsolute(null, 5), 60)
//                    .ControlAddIsRowsAbsolute(FactoryElements.TableLayoutPanel()
//                        .ControlAddIsColumnPercent(FactoryElements.Label_11("Отчество:*"), 30)
//                        .ControlAddIsColumnPercent(FactoryElements.TextBox("Введите отчество")
//                            .With(t => t.TextChanged += (s, e) => Context.Patronymic = t.Text)
//                            .With(t => OnErrorProvider(nameof(Context.Patronymic), t)), 70)
//                        .ControlAddIsColumnAbsolute(null, 5), 60)
//                    .ControlAddIsRowsAbsolute(FactoryElements.TableLayoutPanel()
//                        .ControlAddIsColumnPercent(FactoryElements.Label_11("Дата рождения:*"), 30)
//                        .ControlAddIsColumnPercent(FactoryElements.DateTimePicker()
//                            .With(d => d.Format = DateTimePickerFormat.Custom)
//                            .With(d => d.CustomFormat = "dd.MM.yyyy")
//                            .With(d => d.ShowUpDown = true)
//                            .With(t => t.TextChanged += (s, e) => Context.DateBirth = t.Text)
//                            .With(t => OnErrorProvider(nameof(Context.DateBirth), t)), 70)
//                        .ControlAddIsColumnAbsolute(null, 5), 60)
//                    .ControlAddIsRowsAbsolute(FactoryElements.TableLayoutPanel()
//                        .ControlAddIsColumnPercent(FactoryElements.Label_11("Номер тел.:*"), 30)
//                        .ControlAddIsColumnPercent(FactoryElements.TextBox("Введите номер тел.")
//                            .With(t => t.TextChanged += (s, e) => Context.NumberPhone = t.Text)
//                            .With(t => OnErrorProvider(nameof(Context.NumberPhone), t)), 70)
//                        .ControlAddIsColumnAbsolute(null, 5), 60), 80)
//                .ControlAddIsColumnPercent(null, 10)
//                .ControlAddIsColumnAbsolute(FactoryElements.PictureBox("")
//                    .With(i => i.Dock = DockStyle.Fill)
//                    .With(i => i.Click += (s, e) => Context.OnAddingImg.Execute(null))
//                    .With(i => i.DataBindings.Add(new Binding(nameof(i.ImageLocation), Context, nameof(Context.UrlFaceImg)))), 300)
//                .ControlAddIsColumnPercent(null, 10);

//        private void OnErrorProvider(string propertyName, Control control)
//        {
//            Context.ErrorMassegeProvider += (s, e) =>
//            {
//                if (!propertyName.Equals(e.PropertyName)) return;
//                errorProvider.SetError(control, e.ErrorMessage);
//            };
//        }

//        private TableLayoutPanel CreateButtonPanel()
//            => FactoryElements.TableLayoutPanel()
//                .ControlAddIsColumnPercent(FactoryElements.Button("❌ Удалить изображение", Context, nameof(Context.OnDeletingImg)), 40)
//                .ControlAddIsColumnPercent(FactoryElements.Button(""), 40)
//                .ControlAddIsColumnPercent(FactoryElements.Button("💾 Сохранить", Context, nameof(Context.actjionSave)), 40)
//                .ControlAddIsColumnPercent(FactoryElements.Button("❌ Отмена", Context, nameof(Context.OnBack)), 40);
//    }
//}
