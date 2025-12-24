using DataAccess.Postgres.Models;
using Logica;


namespace WinFormsApp1.View.Event
{
    public class EventCard : ObjectCard
    {
        private EventEntity ev;

        public EventCard(EventEntity eventEntity) : base(eventEntity.Id)
        {
            Size = new Size(400, 170);
            ev = eventEntity;
            CreateContent();
        }

        public override Control Content()
            => FactoryElements.TableLayoutPanel()
                .ControlAddIsRowsPercentV2(
                    FactoryElements.Label_11(ev.Title)
                    .With(t => t.ForeColor = Color.DarkBlue), 40)
                .ControlAddIsRowsPercentV2(
                    FactoryElements.Label_09($"📅 {ev.Date} | 📍 {ev.Location}")
                    .With(t => t.ForeColor = Color.Gray), 30)
                .ControlAddIsRowsPercentV2(
                    FactoryElements.Label_09($"👨‍💼 {ev.Organizer}")
                    .With(t => t.ForeColor = Color.Gray), 30)
                .ControlAddIsRowsPercentV2(
                    FactoryElements.Label_09($"👥 {ev.Participants}")
                    .With(t => t.ForeColor = Color.DarkGreen), 30);
    }
}
