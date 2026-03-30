using Domain.Entitys;
using UserInterface.LayoutPanel;
using UserInterface.LayoutPanel.Extension;
using UserInterface.UiObjects.Card;

namespace Admin.View.Moduls.Lesson;

public class LessonCard : ObjectCard<LessonEntity>
{
    public LessonCard()
    {
        Size = new Size(300, 125);
    }

    public override IBuilder Content(BuilderLayoutPanel builderLayoutPanel)
        => builderLayoutPanel.Column()
            .RowAutoSize().Content().Label(Entity.Title).ForeColor(Color.DarkBlue).End()
            .RowAutoSize().Content().Label($"🏷️ {Entity.Category}").Size(9).ForeColor(Color.Gray).End()
            .RowAutoSize().Content().Label($"👨‍🏫 {Entity.Teacher}").Size(9).ForeColor(Color.Gray).End()
            .RowAutoSize().Content().Label($"👥 {Entity.Visitors.Count}/{Entity.MaxParticipants}").Size(9).ForeColor(Color.DarkGreen).End()
            .RowAutoSize().Content().Label($"★ {Entity.Rating()}").Size(9).ForeColor(Color.Red).End();
}