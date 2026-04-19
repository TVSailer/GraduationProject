using Domain.Entitys;
using UserInterface.LayoutPanel;
using UserInterface.LayoutPanel.Extension;
using UserInterface.UiObjects.Card;

namespace Admin.View.Lesson;

public class LessonCard : ObjectCard<LessonEntity>
{
    public LessonCard()
    {
        Size = new Size(450, 155);
    }

    public override IBuilder Content(BuilderLayoutPanel builderLayoutPanel)
        => builderLayoutPanel.Column()
            .RowAutoSize().Content().Label(Entity.Title).ForeColor(Color.DarkBlue).Size(14).End()
            .RowAutoSize().Content().Label($"🏷️ {Entity.Category}").Size(11).ForeColor(Color.Gray).End()
            .RowAutoSize().Content().Label($"👨‍🏫 {Entity.Teacher}").Size(11).ForeColor(Color.Gray).End()
            .RowAutoSize().Content().Label($"👥 {Entity.Visitors.Count}/{Entity.MaxParticipants}").Size(11).ForeColor(Color.DarkGreen).End()
            .RowAutoSize().Content().Label($"★ {Entity.GetRating()}").Size(11).ForeColor(Color.Red).End();
}