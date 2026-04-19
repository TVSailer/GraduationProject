using Domain.Entitys;
using UserInterface.LayoutPanel;
using UserInterface.UiObjects.Card;

namespace Admin.View.Event;

public class EventCard : ObjectCard<EventEntity>
{
    public EventCard()
    {
        Size = new Size(450, 130);
    }

    public override IBuilder Content(BuilderLayoutPanel builderLayoutPanel)
        => builderLayoutPanel.Column()
            .Row().Content().Label(Entity.Title).ForeColor(Color.DarkBlue).Size(14).End()
            .Row().Content().Label($"📅 {Entity.Schedule}").Size(11).ForeColor(Color.Gray).End()
            .Row().Content().Label($"📍 {Entity.Location}").Size(11).ForeColor(Color.Gray).End()
            .Row().Content().Label($"👨‍💼 {Entity.Organizer}").Size(11).ForeColor(Color.Gray).End();
}