using DataAccess.Postgres.Models;
using Logica;
using Microsoft.Office.Interop.Word;
using WinFormsApp1.View;

namespace Admin.View.News
{
    public class NewsCard : ObjectCard
    {
        private NewsEntity news;

        public NewsCard(NewsEntity newsEntity)
            : base()
        {
            Size = new Size(400, 170);
            news = newsEntity;
            CreateContent();
        }

        public override Control Content()
            => FactoryElements.TableLayoutPanel()
            .ControlAddIsRowsPercentV2(FactoryElements.Label_11(news.Title)
                .With(l => l.ForeColor = Color.DarkBlue), 40)
            .ControlAddIsRowsPercentV2(FactoryElements.Label_09($"👤 {news.Author}")
                .With(l => l.ForeColor = Color.Gray), 30)
            .ControlAddIsRowsPercentV2(FactoryElements.Label_09($"📅 {news.Date}")
                .With(l => l.ForeColor = Color.Gray), 30)
            .ControlAddIsRowsPercentV2(FactoryElements.Label_09($"🏷️ {news.Category}")
                .With(l => l.ForeColor = Color.DarkGreen), 30);
    }
}
