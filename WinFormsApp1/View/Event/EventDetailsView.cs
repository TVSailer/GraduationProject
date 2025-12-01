using DataAccess.Postgres.Models;
using Logica;
using Logica.Extension;
using WinFormsApp1.ViewModel.Event;

namespace WinFormsApp1.View.Event
{

    public partial class EventDetailsView
    {
        private readonly EventDetailsViewModel context;
        private readonly EventEntity eventEntity;

        public EventDetailsView(EventDetailsViewModel context, Form mainForm)
        {
            this.context = context;
            eventEntity = context.EventEntity;
            InitializeEventComponent(mainForm);
        }

        private Form InitializeEventComponent(Form form)
            => form
                .With(f => f.Controls.Clear())
                .With(f => f.Text = $"Подробности: {eventEntity.Title}")
                .With(f => f.Controls.Add(CreateUI()));

        private TableLayoutPanel CreateUI()
            => FactoryElements
                .TableLayoutPanel()
                .ControlAddIsRowsAbsoluteV2(FactoryElements.LabelTitle(eventEntity.Title), 50)
                .ControlAddIsRowsAbsoluteV2(CreateInfoPanel(), 500)
                .ControlAddIsRowsPercentV2(CreateGalleryPanel(), 20)
                .ControlAddIsRowsAbsoluteV2(Buttons(), 90);


        private TableLayoutPanel CreateInfoPanel()
        {
            var fields = new[]
            {
                new { Label = "Название:", Attributee = "Title", OnProperty = OnPropertyAddEventViewModel.Title },
                new { Label = "📅 Дата проведения:", Attributee = "Date", OnProperty = OnPropertyAddEventViewModel.Date },
                new { Label = "📍 Место проведения:",Attributee = "Location", OnProperty = OnPropertyAddEventViewModel.Location },
                new { Label = "🏷️ Категория:", Attributee = "Category", OnProperty = OnPropertyAddEventViewModel.Category },
                new { Label = "👨‍💼 Организатор:", Attributee = "Organizer", OnProperty = OnPropertyAddEventViewModel.Organizer },
                new { Label = "👥 Участники:", Attributee = "MaxParticipants", OnProperty = OnPropertyAddEventViewModel.MaxParticipants },
                new { Label = "🔗 Ссылка на регистрацию:", Attributee = "RegistrationLink", OnProperty = OnPropertyAddEventViewModel.RegisLink },
                new { Label = "📝 Описание:", Attributee = "Description", OnProperty = OnPropertyAddEventViewModel.Description }
            };


            return FactoryElements.TableLayoutPanel()
                .With(t => t.BackColor = Color.WhiteSmoke)
                .With(t => fields.ForEach(f => 
                    t.ControlAddIsRowsAbsoluteV2(
                        FactoryElements.TableLayoutPanel()
                        .ControlAddIsColumnAbsoluteV2(
                            FactoryElements.Label_11(f.Label)
                            .With(l => l.ForeColor = Color.DarkSlateGray), 400)
                        .ControlAddIsColumnPercentV2(null, 25)
                        .ControlAddIsColumnPercentV2(
                            FactoryElements.TextBox("")
                            .With(l => context.ControlOnProperty.Add(f.OnProperty, l))
                            .With(l => l.DataBindings.Add(new Binding("Text", context, f.Attributee, false, DataSourceUpdateMode.OnPropertyChanged)))
                            .With(l => l.BackColor = Color.White)
                            .If(f.Label == "📝 Описание:", l => l
                                .With(l => l.AutoSize = false)
                                .With(l => l.Height = 70)
                                .With(l => l.Dock = DockStyle.Fill)), 50), 50)));}

        private TableLayoutPanel CreateGalleryPanel()
            => FactoryElements
                .TableLayoutPanel()
                .ControlAddIsRowsAbsoluteV2(
                    FactoryElements
                    .Label_12("📷 Приложенные фотографии:"), 50)
                .ControlAddIsRowsPercentV2(LoadImages(), 25);

        private FlowLayoutPanel LoadImages()
            => FactoryElements.FlowLayoutPanel()
                .With(fp => context.SelectedImg.ForEach(url => fp.Controls.Add(FactoryElements.Image(url.Key))))
                .With(fp => context.PropertyChanged +=
                (obj, propCh) =>
                {
                    if (propCh.PropertyName == "OnAddingImg" || propCh.PropertyName == "OnDeletingImg")
                    {
                        fp.Controls.Clear();

                        context.SelectedImg.ForEach(
                        url =>
                        {
                            fp.Controls.Add(FactoryElements.Image(url.Key)
                            .With(i => i.MouseClick +=
                            (s, e) =>
                            {
                                context.SelectedImg[url.Key] = !context.SelectedImg[url.Key];
                                i.BackColor = context.SelectedImg[url.Key] ? Color.Gray : Color.Black;
                            }));
                        });
                    }
                });

        private TableLayoutPanel Buttons()
            => FactoryElements
                .TableLayoutPanel()
                .ControlAddIsColumnPercentV2(FactoryElements.Button("🗑️ Удалить", context, "OnDelete"), 24)
                .ControlAddIsColumnPercentV2(FactoryElements.Button("✏️ Редактировать", context, "OnUpdate"), 24)
                .ControlAddIsColumnPercentV2(FactoryElements.Button("📝 Добавить изображение", context, "OnAddingImg"), 24)
                .ControlAddIsColumnPercentV2(FactoryElements.Button("📝 Удалить изображение", context, "OnDeletingImg"), 24)
                .ControlAddIsColumnPercentV2(FactoryElements.Button("⬅️ Назад", context, "OnBack"), 24);
    }
}
