using Domain.Entitys;
using ExtensionFunc;
using UserInterface.LayoutPanel;
using UserInterface.UiObjects.Card;
using UserInterface.UiObjects.Factory;

namespace Admin.View.Moduls.Event;

public class EventCard : ObjectCard<EventEntity>
{
    public EventCard()
    {
        Size = new Size(400, 135);
    }

    public override Control Content()
        => new BuilderLayoutPanel().Column()
            .Row().ContentEnd(FactoryElements.Label_11(Entity.Title).With(t => t.ForeColor = Color.DarkBlue))
            .Row().ContentEnd(FactoryElements.Label_09($"📅 {Entity.Schedule}").With(t => t.ForeColor = Color.Gray))
            .Row().ContentEnd(FactoryElements.Label_09($"📍 {Entity.Location}").With(t => t.ForeColor = Color.Gray))
            .Row().ContentEnd(FactoryElements.Label_09($"👨‍💼 {Entity.Organizer}").With(t => t.ForeColor = Color.Gray))
            .Build();
}