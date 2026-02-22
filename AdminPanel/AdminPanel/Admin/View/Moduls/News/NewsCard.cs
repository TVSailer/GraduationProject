using Admin.View;
using DataAccess.Postgres.Models;
using Logica.UILayerPanel;

public class NewsCard : ObjectCard<NewsEntity>
{
    public override Control Content()
        => LayoutPanel.CreateColumn()
        .RowAutoSize().ContentEnd(FactoryElements.Label_11(Entity.Title).With(l => l.ForeColor = Color.DarkBlue))
        .RowAutoSize().ContentEnd(FactoryElements.Label_10($"👤 {Entity.Author}").With(l => l.ForeColor = Color.Gray))
        .RowAutoSize().ContentEnd(FactoryElements.Label_10($"📅 {Entity.Date}").With(l => l.ForeColor = Color.Gray))
        .RowAutoSize().ContentEnd(FactoryElements.Label_10($"🏷️ {Entity.Category}").With(l => l.ForeColor = Color.DarkGreen))
        .Build();
}
