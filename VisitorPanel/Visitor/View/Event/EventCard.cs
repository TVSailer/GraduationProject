using DataAccess.PostgreSQL.Models;
using UserInterface.LayoutPanel;
using UserInterface.UiLayoutPanel.CardPanel;

namespace Visitor.View.Event;

public class EventCard : ObjectCard<EventEntity>
{
    public EventCard()
    {
        Size = new Size(300, 370);
        Dock = DockStyle.Top;
        Margin = new Padding(5);
    }

    public override Control Content()
        => new BuilderLayoutPanel().Column()
            .RowAutoSize().Content().Image(Entity.UrlTitleImag).End()
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
            .End()
            .Build();
}