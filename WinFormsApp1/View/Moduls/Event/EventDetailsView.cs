// using Admin.View.ViewForm;
// using DataAccess.Postgres.Models;
// using Logica;
// using WinFormsApp1;
// using WinFormsApp1.View;
// using WinFormsApp1.ViewModelEntity.Event;
//
// namespace Admin.View.Moduls.Event
// {
//
//     public partial class EventDetailsView 
//     {
//         private ErrorProvider errorProvider = new() { BlinkStyle = ErrorBlinkStyle.NeverBlink };
//         private readonly EventDetailsPanel context;
//         private readonly EventEntity eventEntity;
//         private readonly AdminMainView form;
//
//         public EventDetailsView(AdminMainView mainForm, EventEntity even)
//         {
//             context = AdminDI.GetService<EventDetailsPanel>();
//             eventEntity = context.EventEntity;
//             form = mainForm;
//         }
//
//         public Form InitializeComponents()
//             => form
//                 .With(f => f.Controls.Clear())
//                 .With(f => f.LabelText = $"Подробности: {eventEntity.Title}")
//                 .With(f => f.Controls.Add(CreateUI()));
//
//         private TableLayoutPanel CreateUI()
//             => FactoryElements
//                 .TableLayoutPanel()
//                 .ControlAddIsRow(FactoryElements.LabelTitle(eventEntity.Title), 50)
//                 .ControlAddIsRow(CreateInfoPanel(), 500)
//                 .ControlAddIsRowsPercent(CreateGalleryPanel(), 20)
//                 .ControlAddIsRow(Buttons(), 90);
//
//         private TableLayoutPanel CreateInfoPanel()
//         {
//             var fields = new[]
//             {
//                 new { Label = "Название:", Attributee = nameof(context.Title)},
//                 new { Label = "📅 Дата проведения:", Attributee = nameof(context.Date)},
//                 new { Label = "📍 Место проведения:", Attributee = nameof(context.Location) },
//                 new { Label = "🏷️ Категория:", Attributee = nameof(context.Category) },
//                 new { Label = "👨‍💼 Организатор:", Attributee = nameof(context.Organizer) },
//                 new { Label = "👥 Участники:", Attributee = nameof(context.MaxParticipants) },
//                 new { Label = "🔗 Ссылка на регистрацию:", Attributee = nameof(context.RegisLink) },
//                 new { Label = "📝 Описание:", Attributee = nameof(context.Description) }
//             };
//
//             return FactoryElements.TableLayoutPanel()
//                 .With(t => t.BackColor = Color.WhiteSmoke)
//                 .With(t => fields.ForEach(f => 
//                     t.ControlAddIsRow(
//                         FactoryElements.TableLayoutPanel()
//                         .ControlAddIsColumnPercent(
//                             FactoryElements.Label_11(f.Label)
//                             .With(l => l.ForeColor = Color.DarkSlateGray), 30)
//                         .ControlAddIsColumnPercent(
//                             FactoryElements.TextBox("")
//                             .With(l => OnErrorProvider(f.Attributee, l))
//                             .With(l => l.DataBindings.Add(new Binding("LabelText", context, f.Attributee, false, DataSourceUpdateMode.OnPropertyChanged)))
//                             .With(l => l.BackColor = Color.White)
//                             .If(f.Label == "📝 Описание:", l => l
//                                 .With(l => l.AutoSize = false)
//                                 .With(l => l.Height = 70)
//                                 .With(l => l.Dock = DockStyle.Fill)), 69)
//                         .ControlAddIsColumnPercent(null, 1), 50)));
//         }
//
//         private void OnErrorProvider(string propertyName, NameMethod Control)
//         {
//             context.ErrorMassegeProvider += (s, e) =>
//             {
//                 if (!propertyName.Equals(e.PropertyName)) return;
//                 errorProvider.SetError(Control, e.ErrorMessage);
//             };
//         }
//
//         private TableLayoutPanel CreateGalleryPanel()
//             => FactoryElements
//                 .TableLayoutPanel()
//                 .ControlAddIsRow(
//                     FactoryElements
//                     .Label_12("📷 Приложенные фотографии:"), 50)
//                 .ControlAddIsRowsPercent(LoadImages(), 25);
//
//         private FlowLayoutPanel LoadImages()
//             => FactoryElements.FlowLayoutPanel()
//                 .With(fp => context.SelectedImg.ForEach(url => fp.Controls.Add(Image(url.Key))))
//                 .With(fp => context.PropertyChanged +=
//                 (obj, propCh) =>
//                 {
//                     if (propCh.PropertyName == "OnAddingImg" || propCh.PropertyName == "OnDeletingImg")
//                     {
//                         fp.Controls.Clear();
//
//                         context.SelectedImg.ForEach(
//                         url => fp.Controls.Add(Image(url.Key)));
//                     }
//                 });
//
//         private PictureBox Image(string url)
//             => FactoryElements.PictureBox(url)
//                 .With(i => i.MouseClick +=
//                 (s, e) =>
//                 {
//                     context.SelectedImg[url] = !context.SelectedImg[url];
//                     i.BackColor = context.SelectedImg[url] ? Color.Gray : Color.Black;
//                 });
//
//         private TableLayoutPanel Buttons()
//             => FactoryElements
//                 .TableLayoutPanel()
//                 .ControlAddIsColumnPercent(FactoryElements.Button("🗑️ Удалить", context, "OnDelete"), 24)
//                 .ControlAddIsColumnPercent(FactoryElements.Button("✏️ Редактировать", context, "actjionSave"), 24)
//                 .ControlAddIsColumnPercent(FactoryElements.Button("📝 Добавить изображение", context, "OnAddingImg"), 24)
//                 .ControlAddIsColumnPercent(FactoryElements.Button("📝 Удалить изображение", context, "OnDeletingImg"), 24)
//                 .ControlAddIsColumnPercent(FactoryElements.Button("⬅️ Назад", context, "OnBack"), 24);
//
//         public Form InitializeComponents(object? data)
//         {
//             throw new NotImplementedException();
//         }
//     }
// }
