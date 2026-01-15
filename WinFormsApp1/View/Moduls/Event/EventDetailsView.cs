//using Admin.View.ViewForm;
//using DataAccess.Postgres.Models;
//using Logica;
//using WinFormsApp1;
//using WinFormsApp1.View;
//using WinFormsApp1.ViewModelEntity.Event;

//namespace Admin.View.Moduls.Event
//{

//    public partial class EventDetailsView 
//    {
//        private ErrorProvider errorProvider = new() { BlinkStyle = ErrorBlinkStyle.NeverBlink };
//        private readonly EventMaxControlViewModel Context;
//        private readonly EventEntity eventEntity;
//        private readonly AdminMainView form;

//        public EventDetailsView(AdminMainView mainForm, EventEntity even)
//        {
//            Context = AdminDI.GetService<EventMaxControlViewModel>();
//            eventEntity = Context.EventEntity;
//            form = mainForm;
//        }

//        public Form InitializeComponents()
//            => form
//                .With(f => f.Controls.Clear())
//                .With(f => f.Text = $"Подробности: {eventEntity.Title}")
//                .With(f => f.Controls.Add(CreateUI()));

//        private TableLayoutPanel CreateUI()
//            => FactoryElements
//                .TableLayoutPanel()
//                .ControlAddIsRowsAbsolute(FactoryElements.LabelTitle(eventEntity.Title), 50)
//                .ControlAddIsRowsAbsolute(CreateInfoPanel(), 500)
//                .ControlAddIsRowsPercentV2(CreateGalleryPanel(), 20)
//                .ControlAddIsRowsAbsolute(Buttons(), 90);

//        private TableLayoutPanel CreateInfoPanel()
//        {
//            var fields = new[]
//            {
//                new { Label = "Название:", Attributee = nameof(Context.Title)},
//                new { Label = "📅 Дата проведения:", Attributee = nameof(Context.Date)},
//                new { Label = "📍 Место проведения:", Attributee = nameof(Context.Location) },
//                new { Label = "🏷️ Категория:", Attributee = nameof(Context.Category) },
//                new { Label = "👨‍💼 Организатор:", Attributee = nameof(Context.Organizer) },
//                new { Label = "👥 Участники:", Attributee = nameof(Context.MaxParticipants) },
//                new { Label = "🔗 Ссылка на регистрацию:", Attributee = nameof(Context.RegisLink) },
//                new { Label = "📝 Описание:", Attributee = nameof(Context.Description) }
//            };

//            return FactoryElements.TableLayoutPanel()
//                .With(t => t.BackColor = Color.WhiteSmoke)
//                .With(t => fields.ForEach(f => 
//                    t.ControlAddIsRowsAbsolute(
//                        FactoryElements.TableLayoutPanel()
//                        .ControlAddIsColumnPercent(
//                            FactoryElements.Label_11(f.Label)
//                            .With(l => l.ForeColor = Color.DarkSlateGray), 30)
//                        .ControlAddIsColumnPercent(
//                            FactoryElements.TextBox("")
//                            .With(l => OnErrorProvider(f.Attributee, l))
//                            .With(l => l.DataBindings.Add(new Binding("Text", Context, f.Attributee, false, DataSourceUpdateMode.OnPropertyChanged)))
//                            .With(l => l.BackColor = Color.White)
//                            .If(f.Label == "📝 Описание:", l => l
//                                .With(l => l.AutoSize = false)
//                                .With(l => l.Height = 70)
//                                .With(l => l.Dock = DockStyle.Fill)), 69)
//                        .ControlAddIsColumnPercent(null, 1), 50)));
//        }

//        private void OnErrorProvider(string propertyName, Control control)
//        {
//            Context.ErrorMassegeProvider += (s, e) =>
//            {
//                if (!propertyName.Equals(e.PropertyName)) return;
//                errorProvider.SetError(control, e.ErrorMessage);
//            };
//        }

//        private TableLayoutPanel CreateGalleryPanel()
//            => FactoryElements
//                .TableLayoutPanel()
//                .ControlAddIsRowsAbsolute(
//                    FactoryElements
//                    .Label_12("📷 Приложенные фотографии:"), 50)
//                .ControlAddIsRowsPercentV2(LoadImages(), 25);

//        private FlowLayoutPanel LoadImages()
//            => FactoryElements.FlowLayoutPanel()
//                .With(fp => Context.SelectedImg.ForEach(url => fp.Controls.Add(Image(url.Key))))
//                .With(fp => Context.PropertyChanged +=
//                (obj, propCh) =>
//                {
//                    if (propCh.PropertyName == "OnAddingImg" || propCh.PropertyName == "OnDeletingImg")
//                    {
//                        fp.Controls.Clear();

//                        Context.SelectedImg.ForEach(
//                        url => fp.Controls.Add(Image(url.Key)));
//                    }
//                });

//        private PictureBox Image(string url)
//            => FactoryElements.PictureBox(url)
//                .With(i => i.MouseClick +=
//                (s, e) =>
//                {
//                    Context.SelectedImg[url] = !Context.SelectedImg[url];
//                    i.BackColor = Context.SelectedImg[url] ? Color.Gray : Color.Black;
//                });

//        private TableLayoutPanel Buttons()
//            => FactoryElements
//                .TableLayoutPanel()
//                .ControlAddIsColumnPercent(FactoryElements.Button("🗑️ Удалить", Context, "OnDelete"), 24)
//                .ControlAddIsColumnPercent(FactoryElements.Button("✏️ Редактировать", Context, "actjionSave"), 24)
//                .ControlAddIsColumnPercent(FactoryElements.Button("📝 Добавить изображение", Context, "OnAddingImg"), 24)
//                .ControlAddIsColumnPercent(FactoryElements.Button("📝 Удалить изображение", Context, "OnDeletingImg"), 24)
//                .ControlAddIsColumnPercent(FactoryElements.Button("⬅️ Назад", Context, "OnBack"), 24);

//        public Form InitializeComponents(object? data)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
