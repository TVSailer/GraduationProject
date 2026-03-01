using DataAccess.Postgres.Models;
using Extension_Func_Library;
using UserInterface;
using UserInterface.LayoutPanel;
using UserInterface.UiLayoutPanel.CardPanel;

namespace Admin.View.Moduls.Teacher;

public class TeacherCard : ObjectCard<TeacherEntity>
{
    public TeacherCard()
    {
        Size = new Size(300, 100);
    }

    public override Control Content()
        => new BuilderLayoutPanel().CreateColumn()
            .Row(30).ContentEnd(FactoryElements.Label_11($"{Entity}")
                .With(l => l.ForeColor = Color.DarkBlue))
            .Row(23).ContentEnd(FactoryElements.Label_09($"🎂 {Entity.DateBirth}")
                .With(l => l.ForeColor = Color.Gray))
            .Row(23).ContentEnd(FactoryElements.Label_09($"📞 {Entity.NumberPhone}")
                .With(l => l.ForeColor = Color.Gray))
            .Row(24).ContentEnd(FactoryElements.Label_09($"🎨 {Entity.Lessons.Count}")
                .With(l => l.ForeColor = Color.DarkGreen))
            .Build();
}