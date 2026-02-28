using DataAccess.Postgres.Models;
using Extension_Func_Library;
using UserInterface;
using UserInterface.LayoutPanel;
using UserInterface.UiLayoutPanel.CardPanel;

namespace Admin.View.Moduls.Lesson;

public class LessonCard : ObjectCard<LessonEntity>
{
    private double _reting;

    public override ObjectCard<LessonEntity> Initialize(LessonEntity obj)
    {
        Size = new Size(300, 125);

        if (obj.Reviews.Count <= 0) return base.Initialize(obj);
        obj.Reviews.ForEach(r => _reting += r.Rating);
        _reting /= obj.Reviews.Count;

        return base.Initialize(obj);
    }

    public override Control Content()
        => new BuilderLayoutPanel().CreateColumn()
            .RowAutoSize().ContentEnd(FactoryElements.Label_11(Entity.Name).With(l => l.ForeColor = Color.DarkBlue))
            .RowAutoSize().ContentEnd(FactoryElements.Label_09($"🏷️ {Entity.Category}").With(l => l.ForeColor = Color.Gray))
            .RowAutoSize().ContentEnd(FactoryElements.Label_09($"👨‍🏫 {Entity.Teacher}").With(l => l.ForeColor = Color.Gray))
            .RowAutoSize().ContentEnd(FactoryElements.Label_09($"👥 {Entity.Visitors.Count}/{Entity.MaxParticipants}").With(l => l.ForeColor = Color.DarkGreen))
            .RowAutoSize().ContentEnd(FactoryElements.Label_09($"★ {_reting}").With(l => l.ForeColor = Color.Red))
            .Build();
}