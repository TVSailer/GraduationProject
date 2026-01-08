using DataAccess.Postgres.Models;
using Logica;
using Microsoft.Office.Interop.Word;
using WinFormsApp1.View;

namespace Admin.View.Moduls.News
{
    public class NewsCard : ObjectCard<NewsEntity>
    {
        public NewsCard(NewsEntity newsEntity)
            : base()
        {
            Size = new Size(400, 170);
            CreateContent();
        }

        public override Control Content()
            => FactoryElements.TableLayoutPanel()
            .ControlAddIsRowsPercentV2(FactoryElements.Label_11(entity.Title)
                .With(l => l.ForeColor = Color.DarkBlue), 40)
            .ControlAddIsRowsPercentV2(FactoryElements.Label_09($"👤 {entity.Author}")
                .With(l => l.ForeColor = Color.Gray), 30)
            .ControlAddIsRowsPercentV2(FactoryElements.Label_09($"📅 {entity.Date}")
                .With(l => l.ForeColor = Color.Gray), 30)
            .ControlAddIsRowsPercentV2(FactoryElements.Label_09($"🏷️ {entity.Category}")
                .With(l => l.ForeColor = Color.DarkGreen), 30);
    }
}
