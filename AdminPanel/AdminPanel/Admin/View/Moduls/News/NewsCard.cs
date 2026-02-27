using DataAccess.Postgres.Models;
using Extension_Func_Library;
using User_Interface_Library;
using User_Interface_Library.LayerPanel;
using User_Interface_Library.UiLayoutPanel.CardPanel;

namespace Admin.View.Moduls.News;

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