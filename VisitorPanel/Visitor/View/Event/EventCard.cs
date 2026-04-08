using Domain.Entitys;
using UserInterface.LayoutPanel;
using UserInterface.LayoutPanel.Extension;
using UserInterface.UiObjects.Card;

namespace Visitor.View.Event;

public class EventCard : ObjectCard<EventEntity>
{
    public EventCard()
    {
        Size = new Size(300, 450);
        Dock = DockStyle.Top;
        Margin = new Padding(5);
    }

    public override IBuilder Content(BuilderLayoutPanel builderLayoutPanel)
    => new BuilderLayoutPanel().Column()
            .RowAbsolute(300).Content()
                .Image(Entity.UrlTitleImag)
            .End()
            .RowAutoSize().Content()
                .Label(Entity.Title)
                .Size(14)
                .ForeColor(Color.DarkBlue)
            .End()
            .RowAutoSize().Content()
                .Label(Entity.Schedule.ToString())
                .Size(12)
                .ForeColor(Color.Gray)
            .End()
            .RowAutoSize().Content()
                .Label(Entity.Location)
                .Size(12)
                .ForeColor(Color.Gray)
            .End()
                .RowAutoSize().Content()
                .Label($"{Entity.Organizer}")
                .Size(12)
                .ForeColor(Color.DarkGreen)
            .End();
}