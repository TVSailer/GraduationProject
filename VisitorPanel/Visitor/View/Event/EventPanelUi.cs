using DataAccess.PostgreSQL.ModelsPrimitive;
using UserInterface.LayoutPanel;
using UserInterface.UiLayoutPanel.CardPanel.Args;
using UserInterface.View;
using Visitor.FieldData.Event;
using Visitor.FieldData.Event.Button;
using Visitor.FieldData.Lesson.Button;

namespace Visitor.View.Event;

public class EventPanelUi(EventButton button) : UiView<EventDataUi, EventEntity>
{
    protected override IBuilder CreateUi(BuilderLayoutPanel builderLayoutPanel)
    {
        var entity = DataUi.Entity;
        return builderLayoutPanel.Column()
            .Row()
                .Column(20)
                    .RowAutoSize().Content()
                    .Label(entity.Title)
                    .Size(18)
                    .Alignment(ContentAlignment.TopCenter)
                    .ForeColor(Color.DarkBlue)
                .End()
                .RowAutoSize().Content()
                    .Label(entity.Category.ToString())
                    .ForeColor(Color.Black)
                    .Size(12)
                .End()
                .RowAutoSize().Content()
                    .Label(entity.Location)
                    .ForeColor(Color.Black)
                    .Size(12)
                .End()
                .RowAutoSize().Content()
                    .Label(entity.Organizer)
                    .ForeColor(Color.Black)
                    .Size(12)
                .End()
                .RowAutoSize().Content()
                    .Label(entity.Schedule.ToString())
                    .Size(12)
                .End()
                .Row().Content()
                    .TextBox(entity.Description)
                    .Multiline()
                    .ReadOnly()
                    .Size(12)
                .End()
            .End()
                .Column(40).Content()
                .ImageLayoutPanel(DataUi.RepositoryImgEntity)
            .End()
            .End()
            .RowAbsolute(80).Content().ButtonLayoutPanel(button.GetButtons(new ClickedArgs<EventEntity>(entity))).End();
    }
}