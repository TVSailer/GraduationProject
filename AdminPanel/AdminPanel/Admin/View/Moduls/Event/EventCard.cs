using DataAccess.Postgres.Models;
using Extension_Func_Library;
using UserInterface;
using UserInterface.UiLayoutPanel.CardPanel;

namespace Admin.View.Moduls.Event;

public class EventCard : ObjectCard<EventEntity>
{
    public override Control Content()
        => FactoryElements.TableLayoutPanel()
            .ControlAddIsRowsPercent(
                FactoryElements.Label_11(Entity.Title)
                    .With(t => t.ForeColor = Color.DarkBlue), 40)
            .ControlAddIsRowsPercent(
                FactoryElements.Label_09($"📅 {Entity.Schedule} | 📍 {Entity.Location}")
                    .With(t => t.ForeColor = Color.Gray), 30)
            .ControlAddIsRowsPercent(
                FactoryElements.Label_09($"👨‍💼 {Entity.Organizer}")
                    .With(t => t.ForeColor = Color.Gray), 30)
            .ControlAddIsRowsPercent(
                FactoryElements.Label_09($"👥 {Entity.CurrentParticipants / (Entity.MaxParticipants == 0 ? 1 : Entity.MaxParticipants)}")
                    .With(t => t.ForeColor = Color.DarkGreen), 30);
}