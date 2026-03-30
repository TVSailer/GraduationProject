using Domain.Entitys;
using ExtensionFunc;
using UserInterface.LayoutPanel;
using UserInterface.LayoutPanel.Extension;
using UserInterface.UiObjects.Card;

namespace Admin.View.Moduls.Lesson.Schedule;

public class ScheduleCard : ObjectCard<LessonScheduleEntity>
{
    public ScheduleCard()
    {
        Height = 35;
        Dock = DockStyle.Top;
    }

    public override IBuilder Content(BuilderLayoutPanel builderLayoutPanel)
        => builderLayoutPanel.Column()
            .RowAutoSize()
                .Column().Content()
                    .Label($"{Entity.Day.ToDescriptionString()}: ")
                    .Alignment(ContentAlignment.MiddleLeft)
                .End()
                .Column().Content()
                    .Label($"{Entity.Start}-{Entity.End}")
                    .Alignment(ContentAlignment.MiddleRight)
                .End();
}