using DataAccess.PostgreSQL.ModelsPrimitive;
using ExtensionFunc;
using UserInterface;
using UserInterface.LayoutPanel;
using UserInterface.UiLayoutPanel.CardPanel;

namespace Admin.View.Moduls.News;

public class NewsCard : ObjectCard<NewsEntity>
{
    public NewsCard()
    {
        Size = new Size(300, 120);
    }

    public override Control Content()
        => new BuilderLayoutPanel().Column()
            .RowAutoSize().ContentEnd(FactoryElements.Label_11(Entity.Title).With(l => l.ForeColor = Color.DarkBlue))
            .RowAutoSize().ContentEnd(FactoryElements.Label_10($"👤 {Entity.Author}").With(l => l.ForeColor = Color.Gray))
            .RowAutoSize().ContentEnd(FactoryElements.Label_10($"📅 {Entity.Date}").With(l => l.ForeColor = Color.Gray))
            .RowAutoSize().ContentEnd(FactoryElements.Label_10($"🏷️ {Entity.Category}").With(l => l.ForeColor = Color.DarkGreen))
            .Build();
}