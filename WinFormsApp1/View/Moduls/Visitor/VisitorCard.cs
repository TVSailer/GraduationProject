using DataAccess.Postgres.Models;
using Logica;
using WinFormsApp1.View;

namespace Admin.View.Moduls.Visitor
{
    public class VisitorCard : ObjectCard<VisitorEntity>
    {
        public VisitorCard()
        {
            Size = new Size(1200, 50);
            Margin = new Padding(1);
            Padding = new Padding(1);
        }

        public override ObjectCard<VisitorEntity> Initialize(VisitorEntity obj)
        {
            return base.Initialize(obj);
        }

        public override Control Content()
           => FactoryElements.TableLayoutPanel()
            .ControlAddIsColumnPercentV2(FactoryElements.Label_11($"{entity.ToString()}")
                .With(l => l.ForeColor = Color.DarkBlue), 40)
            .ControlAddIsColumnPercentV2(FactoryElements.Label_11($"🎂 {entity.DateBirth}")
                .With(l => l.ForeColor = Color.Gray), 25)
            .ControlAddIsColumnPercentV2(FactoryElements.Label_11($"📞 {entity.NumberPhone}")
                .With(l => l.ForeColor = Color.Gray), 25)
            .ControlAddIsColumnPercentV2(FactoryElements.Label_11($"🎯 Посещает кружков: {entity.Lessons.Count}")
                .With(l => l.ForeColor = Color.DarkGreen), 30);
    }
}
