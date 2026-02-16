using DataAccess.Postgres.Models;
using Logica;

public class TeacherCard : ObjectCard<TeacherEntity>
{
    public TeacherCard()
    {
        Size = new Size(1000, 50);
        Margin = new Padding(1);
        Padding = new Padding(1);
    }

    public override ObjectCard<TeacherEntity> Initialize(TeacherEntity obj)
    {
        return base.Initialize(obj);
    }

    public override Control Content()
        => FactoryElements.TableLayoutPanel()
            .ControlAddIsColumnPercent(
                FactoryElements.Label_11($"{entity}")
                .With(l => l.ForeColor = Color.DarkBlue), 50)
            .ControlAddIsColumnPercent(
                FactoryElements.Label_11($"📞 {entity.NumberPhone}")
                .With(l => l.ForeColor = Color.Gray), 30)
            .ControlAddIsColumnPercent(
                FactoryElements.Label_11($"🎨 Кружков: {entity.Lessons.Count}")
                .With(l => l.ForeColor = Color.DarkGreen), 20);
}
