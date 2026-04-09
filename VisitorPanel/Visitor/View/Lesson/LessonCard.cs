using Domain.Entitys;
using UserInterface.LayoutPanel;
using UserInterface.LayoutPanel.Extension;
using UserInterface.UiObjects.Card;

namespace Visitor.View.Lesson;

public class LessonCard : ObjectCard<LessonEntity>
{
    public LessonCard()
    {
        Size = new Size(480, 200);
        Dock = DockStyle.Top;
        Margin = new Padding(5);
    }

    public override IBuilder Content(BuilderLayoutPanel builderLayoutPanel)
    => builderLayoutPanel.Column()
            .RowAutoSize().Content()
                .Label(Entity.Title)
                    .Size(14)
                    .ForeColor(Color.DarkBlue)
                    .Alignment(ContentAlignment.TopCenter)
                .End()
            .RowAutoSize().Content()
                .Label($"★ {Entity.GetRating()} • {Entity.Reviews.Count} отзывов")
                    .Size(12)
                    .ForeColor(Color.Orange)
                .End()
            .RowAutoSize().Content()
                .Label(Entity.Teacher.ToString())
                    .Size(12)
                    .ForeColor(Color.Gray)
                .End()
            .RowAutoSize().Content()
                .Label(Entity.Category.ToString())
                    .Size(12)
                    .ForeColor(Color.Gray)
                .End()
            .RowAutoSize().Content()
                .Label($"{Entity.Visitors.Count}/{Entity.MaxParticipants}")
                    .Size(12)
                    .ForeColor(Color.DarkGreen)
                .End();
}