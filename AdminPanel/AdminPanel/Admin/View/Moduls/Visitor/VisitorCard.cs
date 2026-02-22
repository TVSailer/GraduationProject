using DataAccess.Postgres.Models;
using Logica;
using Logica.UILayerPanel;

namespace Admin.View.Moduls.Visitor
{
    public class VisitorCard : ObjectCard<VisitorEntity>
    {
        public override Control Content()
           => LayoutPanel.CreateColumn()
               .Row(30).ContentEnd(FactoryElements.Label_11($"{Entity}")
                .With(l => l.ForeColor = Color.DarkBlue))
               .Row(23).ContentEnd(FactoryElements.Label_09($"🎂 {Entity.DateBirth}")
                .With(l => l.ForeColor = Color.Gray))
               .Row(23).ContentEnd(FactoryElements.Label_09($"📞 {Entity.NumberPhone}")
                .With(l => l.ForeColor = Color.Gray))
               .Row(24).ContentEnd(FactoryElements.Label_09($"🎯 {Entity.Lessons.Count}")
                .With(l => l.ForeColor = Color.DarkGreen))
               .Build();
    }
}
