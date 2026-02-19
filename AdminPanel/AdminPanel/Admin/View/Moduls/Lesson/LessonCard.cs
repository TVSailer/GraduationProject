using DataAccess.Postgres.Models;
using Logica;

public class LessonCard : ObjectCard<LessonEntity>
{
    private double reting;

    public LessonCard()
    {
        Size = new Size(400, 180);
    }

    public override ObjectCard<LessonEntity> Initialize(LessonEntity obj)
    {
        if (obj.Reviews.Count <= 0) return base.Initialize(obj);
        obj.Reviews.ForEach(r => reting += r.Rating);
        reting /= obj.Reviews.Count;

        return base.Initialize(obj);
    }

    public override Control Content()
        => FactoryElements.TableLayoutPanel()
        .ControlAddIsRowsPercent(FactoryElements.Label_11(entity.Name)
            .With(l => l.ForeColor = Color.DarkBlue), 40)
        .ControlAddIsRowsPercent(FactoryElements.Label_09($"🏷️ {entity.Category}")
            .With(l => l.ForeColor = Color.Gray), 30)
        .ControlAddIsRowsPercent(FactoryElements.Label_09($"👨‍🏫 {entity.Teacher}")
            .With(l => l.ForeColor = Color.Gray), 30)
        .ControlAddIsRowsPercent(FactoryElements.Label_09($"👥 {entity.Visitors.Count}/{entity.MaxParticipants}")
            .With(l => l.ForeColor = Color.DarkGreen), 30)
        .ControlAddIsRowsPercent(FactoryElements.Label_09($"★ {reting}")
            .With(l => l.ForeColor = Color.Red), 30);
}


