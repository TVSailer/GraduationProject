using DataAccess.PostgreSQL.ModelsPrimitive;
using UserInterface.LayoutPanel;
using UserInterface.UiLayoutPanel.CardPanel;

namespace Visitor.View.Lesson;

public class LessonCard : ObjectCard<LessonEntity>
{
    public LessonCard()
    {
        Size = new Size(300, 200);
        Dock = DockStyle.Top;
        Margin = new Padding(5);
    }

    public override Control Content()
        => new BuilderLayoutPanel().Column()
            .RowAutoSize().Content()
                .Label(Entity.Name)
                    .Size(14)
                    .ForeColor(Color.DarkBlue)
                .End()
            .RowAutoSize().Content()
                .Label($"★ {Entity.Rating()} • {Entity.Reviews.Count} отзывов")
                    .Size(12)
                    .ForeColor(Color.Orange)
                .End()
            .RowAutoSize().Content()
                .Label(Entity.Teacher.FIO.ToString())
                    .Size(12)
                    .ForeColor(Color.Gray)
                .End()
            .RowAutoSize().Content()
                .Label(Entity.Category.ToString())
                    .Size(12)
                    .ForeColor(Color.Gray)
                .End()
            .RowAutoSize().Content()
                .Label($"{Entity.CurrentParticipants()}")
                    .Size(12)
                    .ForeColor(Color.DarkGreen)
                .End()
            .Build();
}