using DataAccess.Postgres.Models;
using Logica;
using WinFormsApp1.View;

namespace Admin.View.Moduls.Event
{
    public class EventCard : ObjectCard<EventEntity>
    {
        public EventCard(EventEntity eventEntity) : base(eventEntity)
        {
            Size = new Size(400, 170);
            CreateContent();
        }

        public override Control Content()
            => FactoryElements.TableLayoutPanel()
                .ControlAddIsRowsPercentV2(
                    FactoryElements.Label_11(entity.Title)
                    .With(t => t.ForeColor = Color.DarkBlue), 40)
                .ControlAddIsRowsPercentV2(
                    FactoryElements.Label_09($"📅 {entity.Date} | 📍 {entity.Location}")
                    .With(t => t.ForeColor = Color.Gray), 30)
                .ControlAddIsRowsPercentV2(
                    FactoryElements.Label_09($"👨‍💼 {entity.Organizer}")
                    .With(t => t.ForeColor = Color.Gray), 30)
                .ControlAddIsRowsPercentV2(
                    FactoryElements.Label_09($"👥 {entity.CurrentParticipants/entity.MaxParticipants}")
                    .With(t => t.ForeColor = Color.DarkGreen), 30);
    }
}
