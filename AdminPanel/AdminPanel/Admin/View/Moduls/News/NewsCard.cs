using Admin.View;
using DataAccess.Postgres.Models;
using Logica;

public class NewsCard : ObjectCard<NewsEntity>
{
    public override Control Content()
        => FactoryElements.TableLayoutPanel()
        .ControlAddIsRowsPercent(FactoryElements.Label_11(Entity.Title)
            .With(l => l.ForeColor = Color.DarkBlue), 40)
        .ControlAddIsRowsPercent(FactoryElements.Label_09($"👤 {Entity.Author}")
            .With(l => l.ForeColor = Color.Gray), 30)
        .ControlAddIsRowsPercent(FactoryElements.Label_09($"📅 {Entity.Date}")
            .With(l => l.ForeColor = Color.Gray), 30)
        .ControlAddIsRowsPercent(FactoryElements.Label_09($"🏷️ {Entity.Category}")
            .With(l => l.ForeColor = Color.DarkGreen), 30);
}
