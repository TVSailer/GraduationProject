using Domain.Entitys;
using UserInterface.LayoutPanel;
using UserInterface.UiObjects.Card;

namespace Admin.View.Teacher;

public class TeacherCard : ObjectCard<TeacherEntity>
{
    public TeacherCard()
    {
        Size = new Size(450, 145);
    }

    public override IBuilder Content(BuilderLayoutPanel builderLayoutPanel)
        => builderLayoutPanel.Column()
            .Row(30).Content().Label($"{Entity}").ForeColor(Color.DarkBlue).Size(14).End()
            .Row(23).Content().Label($"🎂 {Entity.DateBirth}").Size(11).ForeColor(Color.Gray).End()
            .Row(23).Content().Label($"📞 {Entity.NumberPhone}").Size(11).ForeColor(Color.Gray).End()
            .Row(24).Content().Label($"🎨 {Entity.Lessons.Count}").Size(11).ForeColor(Color.DarkGreen).End()
            ;
}