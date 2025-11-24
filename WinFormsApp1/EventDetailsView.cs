using Logica;
using Logica.Extension;
using DataAccess.Postgres.Models;

namespace AdminApp.Forms
{
    public partial class EventDetailsView
    {
        public readonly EventEntity Event;
        public readonly EventManagementView EventManagementForm;

        public EventDetailsView(Control context, Form mainForm)
        {
            InitializeEventComponent(mainForm);
        }

        private Form InitializeEventComponent(Form form)
            => form
                .With(f => f.Controls.Clear())
                .With(f => f.Text = $"Подробности: {Event.Title}")
                .With(f => f.Controls.Add(CreateUI()));

        private Control CreateUI()
            => FactoryElements
                .TableLayoutPanel()
                .ControlAddIsRowsAbsoluteV2(FactoryElements.LabelTitle(Event.Title), 50)
                .ControlAddIsRowsAbsoluteV2(CreateInfoPanel(), 500)
                .ControlAddIsRowsPercentV2(CreateGalleryPanel(), 20)
                .ControlAddIsRowsAbsoluteV2(Buttons(), 90);


        private Control CreateInfoPanel()
        {
            var fields = new[]
            {
                new { Label = "📅 Дата проведения:", Value = Event.Date, Attributee = "Date" },
                new { Label = "📍 Место проведения:", Value = Event.Location, Attributee = "Location" },
                new { Label = "🏷️ Категория:", Value = Event.Category, Attributee = "Category" },
                new { Label = "👨‍💼 Организатор:", Value = Event.Organizer, Attributee = "Organizer"},
                new { Label = "👥 Участники:", Value = $"{Event.Participants}", Attributee = "Participants" },
                new { Label = "🔗 Ссылка на регистрацию:", Value = Event.RegistrationLink, Attributee = "RegistrationLink"},
                new { Label = "📝 Описание:", Value = Event.Description, Attributee = "Description" }
            };


            return FactoryElements.TableLayoutPanel()
                .With(t => t.BackColor = Color.WhiteSmoke)
                .With(t => fields.ForEach(f => 
                    t.ControlAddIsRowsAbsoluteV2(
                        FactoryElements
                        .TableLayoutPanel()
                            .ControlAddIsColumnAbsoluteV2(
                                FactoryElements.Label_11(f.Label)
                                    .With(l => l.ForeColor = Color.DarkSlateGray), 400)
                            .ControlAddIsColumnPercentV2(null, 25)
                            .ControlAddIsColumnPercentV2(
                                FactoryElements.Label_11("")
                                    .With(l => l.BorderStyle = BorderStyle.FixedSingle)
                                    .With(l => l.DataBindings.Add(new Binding("Text", Event, f.Attributee, false, DataSourceUpdateMode.OnPropertyChanged)))
                                    .With(l => l.BackColor = Color.White)
                                    .If(f.Label == "📝 Описание:", l => l
                                        .With(l => l.AutoSize = false)
                                        .With(l => l.Height = 70)
                                        .With(l => l.Dock = DockStyle.Fill)), 50), 50)));}

        private Control CreateGalleryPanel()
            => FactoryElements
                .TableLayoutPanel()
                .ControlAddIsRowsAbsoluteV2(
                    FactoryElements
                    .Label_12("📷 Приложенные фотографии:"), 50)
                .ControlAddIsRowsPercentV2(LoadImages(), 25);

        private Control LoadImages()
            => new Control()
                .IfElse(
                    Event.ImgsEvent == null || !Event.ImgsEvent.Any(),
                    c => c.NewControl(
                        FactoryElements
                            .Label_10("Нет приложенных фотографий")
                            .With(l => l.ForeColor = Color.Gray)
                            .With(l => l.TextAlign = ContentAlignment.MiddleCenter)),
                    c => c.NewControl(
                        FactoryElements
                            .FlowLayoutPanel()
                            .With(fp => Event
                                .ImgsEvent
                                .ForEach(img => fp
                                    .Controls
                                    .Add(FactoryElements.Image(img.Url)
                                        .With(c => c.Click += (s, e) => FullSizeImage(img.Url)))))));

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

        private Control Buttons()
            => FactoryElements
                .TableLayoutPanel()
                .ControlAddIsColumnPercentV2(
                    FactoryElements
                    .Button("🗑️ Удалить"), 40)
                .ControlAddIsColumnPercentV2(
                    FactoryElements
                    .Button("✏️ Редактировать"), 40)
                .ControlAddIsColumnPercentV2(
                    FactoryElements
                    .Button("📝 Зарегистрироваться",
                        () => Validatoreg.OpenLink(Event.RegistrationLink)), 40)
                .ControlAddIsColumnPercentV2(
                    FactoryElements
                    .Button("⬅️ Назад"), 40);
    }
}
