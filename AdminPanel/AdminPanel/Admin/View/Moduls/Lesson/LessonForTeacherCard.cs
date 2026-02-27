using Admin.View;
using DataAccess.Postgres.Models;
using Extension_Func_Library;
using User_Interface_Library;
using User_Interface_Library.LayerPanel;
using User_Interface_Library.UiLayoutPanel.CardPanel;

public class LessonForTeacherCard : ObjectCard<LessonEntity>
{
    public override Control Content()
        => LayoutPanel.CreateColumn()
            .Row().ContentEnd(FactoryElements.Label_11(Entity.Name).With(l => l.ForeColor = Color.DarkBlue))
            .Build();
}