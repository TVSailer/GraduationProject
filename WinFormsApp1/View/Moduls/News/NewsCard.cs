using DataAccess.Postgres.Models;
using Logica;
using Microsoft.Office.Interop.Word;
using WinFormsApp1.View;

namespace Admin.View.Moduls.News
{
    public class NewsCard : ObjectCard<NewsEntity>
    {
        public NewsCard()
        {
            Size = new Size(400, 170);
        }

        public override ObjectCard<NewsEntity> Initialize(NewsEntity obj)
        {
            return base.Initialize(obj);
        }

        public override Control Content()
            => FactoryElements.TableLayoutPanel()
            .ControlAddIsRowsPercent(FactoryElements.Label_11(entity.Title)
                .With(l => l.ForeColor = Color.DarkBlue), 40)
            .ControlAddIsRowsPercent(FactoryElements.Label_09($"👤 {entity.Author}")
                .With(l => l.ForeColor = Color.Gray), 30)
            .ControlAddIsRowsPercent(FactoryElements.Label_09($"📅 {entity.Date}")
                .With(l => l.ForeColor = Color.Gray), 30)
            .ControlAddIsRowsPercent(FactoryElements.Label_09($"🏷️ {entity.Category}")
                .With(l => l.ForeColor = Color.DarkGreen), 30);
    }
}
