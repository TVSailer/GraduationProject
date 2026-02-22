using Admin.View;
using DataAccess.Postgres.Models;
using Logica.UILayerPanel;

public class LessonForTeacherCard : ObjectCard<LessonEntity>
{
    public override Control Content()
        => LayoutPanel.CreateColumn()
            .Row().ContentEnd(FactoryElements.Label_11(Entity.Name).With(l => l.ForeColor = Color.DarkBlue))
            .Build();
}