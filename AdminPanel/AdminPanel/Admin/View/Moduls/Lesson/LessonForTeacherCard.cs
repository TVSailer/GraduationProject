using Admin.View;
using DataAccess.Postgres.Models;
using Extension_Func_Library;
using UserInterface;
using UserInterface.LayoutPanel;
using UserInterface.UiLayoutPanel.CardPanel;

public class LessonForTeacherCard : ObjectCard<LessonEntity>
{
    public override Control Content()
        => new BuilderLayoutPanel().CreateColumn()
            .Row().ContentEnd(FactoryElements.Label_11(Entity.Name).With(l => l.ForeColor = Color.DarkBlue))
            .Build();
}