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
//        private readonly EventMaxControlViewModel context;
//        private readonly EventEntity eventEntity;
//        private readonly AdminMainView form;

//        public EventDetailsView(AdminMainView mainForm, EventEntity even)
//        {
//            context = AdminDI.GetService<EventMaxControlViewModel>();
//            eventEntity = context.EventEntity;
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
//                .ControlAddIsRowsAbsoluteV2(FactoryElements.LabelTitle(eventEntity.Title), 50)
//                .ControlAddIsRowsAbsoluteV2(CreateInfoPanel(), 500)
//                .ControlAddIsRowsPercentV2(CreateGalleryPanel(), 20)
//                .ControlAddIsRowsAbsoluteV2(Buttons(), 90);

//        private TableLayoutPanel CreateInfoPanel()
//        {
//            var fields = new[]
//            {
//                new { Label = "Название:", Attributee = nameof(context.Title)},
//                new { Label = "📅 Дата проведения:", Attributee = nameof(context.Date)},
//                new { Label = "📍 Место проведения:", Attributee = nameof(context.Location) },
//                new { Label = "🏷️ Категория:", Attributee = nameof(context.Category) },
//                new { Label = "👨‍💼 Организатор:", Attributee = nameof(context.Organizer) },
//                new { Label = "👥 Участники:", Attributee = nameof(context.MaxParticipants) },
//                new { Label = "🔗 Ссылка на регистрацию:", Attributee = nameof(context.RegisLink) },
//                new { Label = "📝 Описание:", Attributee = nameof(context.Description) }
//            };

//            return FactoryElements.TableLayoutPanel()
//                .With(t => t.BackColor = Color.WhiteSmoke)
//                .With(t => fields.ForEach(f => 
//                    t.ControlAddIsRowsAbsoluteV2(
//                        FactoryElements.TableLayoutPanel()
//                        .ControlAddIsColumnPercentV2(
//                            FactoryElements.Label_11(f.Label)
//                            .With(l => l.ForeColor = Color.DarkSlateGray), 30)
//                        .ControlAddIsColumnPercentV2(
//                            FactoryElements.TextBox("")
//                            .With(l => OnErrorProvider(f.Attributee, l))
//                            .With(l => l.DataBindings.Add(new Binding("Text", context, f.Attributee, false, DataSourceUpdateMode.OnPropertyChanged)))
//                            .With(l => l.BackColor = Color.White)
//                            .If(f.Label == "📝 Описание:", l => l
//                                .With(l => l.AutoSize = false)
//                                .With(l => l.Height = 70)
//                                .With(l => l.Dock = DockStyle.Fill)), 69)
//                        .ControlAddIsColumnPercentV2(null, 1), 50)));
//        }

//        private void OnErrorProvider(string propertyName, Control control)
//        {
//            context.ErrorMassegeProvider += (s, e) =>
//            {
//                if (!propertyName.Equals(e.PropertyName)) return;
//                errorProvider.SetError(control, e.ErrorMessage);
//            };
//        }

//        private TableLayoutPanel CreateGalleryPanel()
//            => FactoryElements
//                .TableLayoutPanel()
//                .ControlAddIsRowsAbsoluteV2(
//                    FactoryElements
//                    .Label_12("📷 Приложенные фотографии:"), 50)
//                .ControlAddIsRowsPercentV2(LoadImages(), 25);

//        private FlowLayoutPanel LoadImages()
//            => FactoryElements.FlowLayoutPanel()
//                .With(fp => context.SelectedImg.ForEach(url => fp.Controls.Add(Image(url.Key))))
//                .With(fp => context.PropertyChanged +=
//                (obj, propCh) =>
//                {
//                    if (propCh.PropertyName == "OnAddingImg" || propCh.PropertyName == "OnDeletingImg")
//                    {
//                        fp.Controls.Clear();

//                        context.SelectedImg.ForEach(
//                        url => fp.Controls.Add(Image(url.Key)));
//                    }
//                });

//        private PictureBox Image(string url)
//            => FactoryElements.PictureBox(url)
//                .With(i => i.MouseClick +=
//                (s, e) =>
//                {
//                    context.SelectedImg[url] = !context.SelectedImg[url];
//                    i.BackColor = context.SelectedImg[url] ? Color.Gray : Color.Black;
//                });

//        private TableLayoutPanel Buttons()
//            => FactoryElements
//                .TableLayoutPanel()
//                .ControlAddIsColumnPercentV2(FactoryElements.Button("🗑️ Удалить", context, "OnDelete"), 24)
//                .ControlAddIsColumnPercentV2(FactoryElements.Button("✏️ Редактировать", context, "actjionSave"), 24)
//                .ControlAddIsColumnPercentV2(FactoryElements.Button("📝 Добавить изображение", context, "OnAddingImg"), 24)
//                .ControlAddIsColumnPercentV2(FactoryElements.Button("📝 Удалить изображение", context, "OnDeletingImg"), 24)
//                .ControlAddIsColumnPercentV2(FactoryElements.Button("⬅️ Назад", context, "OnBack"), 24);

//        public Form InitializeComponents(object? data)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
