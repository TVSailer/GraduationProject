using Domain.Entitys;
using UserInterface.LayoutPanel;
using UserInterface.UiObjects.Card;

namespace Admin.View.Moduls.Event;

public class EventCard : ObjectCard<EventEntity>
{
    public EventCard()
    {
        Size = new Size(400, 110);
    }

    public override IBuilder Content(BuilderLayoutPanel builderLayoutPanel)
        => builderLayoutPanel.Column()
            .Row().Content().Label(Entity.Title).ForeColor(Color.DarkBlue).End()
            .Row().Content().Label($"📅 {Entity.Schedule}").Size(9).ForeColor(Color.Gray).End()
            .Row().Content().Label($"📍 {Entity.Location}").Size(9).ForeColor(Color.Gray).End()
            .Row().Content().Label($"👨‍💼 {Entity.Organizer}").Size(9).ForeColor(Color.Gray).End();
}