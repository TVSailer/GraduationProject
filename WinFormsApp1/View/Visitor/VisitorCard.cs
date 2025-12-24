using DataAccess.Postgres.Models;
using Logica;
using WinFormsApp1.View;

namespace Admin.View.Visitor
{
    public class VisitorCard : ObjectCard
    {
        private VisitorEntity visitor;

        public VisitorCard(VisitorEntity visitorEntity)
            : base()
        {
            Size = new Size(1200, 50);
            Margin = new Padding(1);
            Padding = new Padding(1);
            visitor = visitorEntity;
            CreateContent();
        }

        public override Control Content()
           => FactoryElements.TableLayoutPanel()
            .ControlAddIsColumnPercentV2(FactoryElements.Label_11($"{visitor.ToString()}")
                .With(l => l.ForeColor = Color.DarkBlue), 40)
            .ControlAddIsColumnPercentV2(FactoryElements.Label_11($"🎂 {visitor.DateBirth}")
                .With(l => l.ForeColor = Color.Gray), 25)
            .ControlAddIsColumnPercentV2(FactoryElements.Label_11($"📞 {visitor.NumberPhone}")
                .With(l => l.ForeColor = Color.Gray), 25)
            .ControlAddIsColumnPercentV2(FactoryElements.Label_11($"🎯 Посещает кружков: {visitor.Lessons.Count}")
                .With(l => l.ForeColor = Color.DarkGreen), 30);
    }
}
