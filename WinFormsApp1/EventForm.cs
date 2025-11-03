using Logica;
using Logica.Extension;
using AdminApp.Controls;

namespace AdminApp.Forms
{
    public partial class AdminMainForm
    {
        private void InitializeComponentEvent()
            => this
                .With(m => m.Text = "Управление мероприятиями")
                .With(m => m.WindowState = FormWindowState.Maximized)
                .With(m => m.StartPosition = FormStartPosition.CenterParent)
                .With(m => m.BackColor = Color.White)
                .With(m => m.Controls.Clear())
                .With(m => m.Controls.Add(CreateUI()));

        private TableLayoutPanel CreateUI()
            => new TableLayoutPanel()
                .With(t => t.Padding = new Padding(15))
                .With(t => t.Dock = DockStyle.Fill)
                .ControlAddIsRowsAbsoluteV2(new Label().LabelTitle("🎭 Управление мероприятиями"), 70)
                .ControlAddIsRowsPercentV2(LoadEventCards(), 70)
                .ControlAddIsRowsAbsoluteV2(
                    new TableLayoutPanel()
                        .With(t => t.Dock = DockStyle.Fill)
                        .ControlAddIsColumnPercentV2(new Button().Button("➕ Добавить"), 40)
                        .ControlAddIsColumnPercentV2(new Button().Button("✏️ Редактировать"), 40)
                        .ControlAddIsColumnPercentV2(new Button().Button("🗑️ Удалить"), 40)
                        .ControlAddIsColumnPercentV2(new Button().Button("⬅️ Назад", InitializeComponent), 40)
                        .ControlAddIsColumnPercentV2(new Button().Button("🔄 Обновить"), 40), 70);


        private Control LoadEventCards()
        {
            var cardsPanel = new FlowLayoutPanel()
                        .With(p => p.Dock = DockStyle.Fill)
                        .With(p => p.AutoScroll = true)
                        .With(p => p.BackColor = Color.WhiteSmoke)
                        .With(p => p.Padding = new Padding(10));

            var events = new[]
            {
                new { Id = 1, Title = "Выпускной вечер", Date = "25.05.2024", Location = "Актовый зал", Organizer = "Администрация", Participants = "120/150" },
                new { Id = 2, Title = "Новогодний бал", Date = "28.12.2024", Location = "Школьный двор", Organizer = "Ученический совет", Participants = "200/250" },
                new { Id = 3, Title = "Научная конференция", Date = "15.03.2024", Location = "Конференц-зал", Organizer = "Научный отдел", Participants = "50/60" },
                new { Id = 4, Title = "Спортивная олимпиада", Date = "10.04.2024", Location = "Стадион", Organizer = "Спортивный клуб", Participants = "80/100" }
            };

            foreach (var eventItem in events)
            {
                var card = new EventCard(eventItem.Id, eventItem.Title, eventItem.Date,
                    eventItem.Location, eventItem.Organizer, eventItem.Participants);
                //card.OnCardClicked += (s, e) => ;
                cardsPanel.Controls.Add(card);
            }

            return cardsPanel;
        }
    }

}
