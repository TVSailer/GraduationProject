using DataAccess.PostgreSQL.Models;
using UserInterface.LayoutPanel;
using UserInterface.UiLayoutPanel.CardPanel;

namespace Visitor.View.News;

public class NewsCard : ObjectCard<NewsEntity>
{
    public NewsCard()
    {
        Height = 500;
        Dock = DockStyle.Top;
        Margin = new Padding(5);
    }

    public override Control Content()
        => new BuilderLayoutPanel().Column()
            .RowAutoSize().Content()
            .Label(Entity.Title)
                .Size(14)
                .ForeColor(Color.DarkBlue)
            .End()
            .RowAutoSize().Content()
                .Label(Entity.Date)
                .Size(12)
                .ForeColor(Color.Gray)
            .End()
            .RowAutoSize().Content()
                .Label(Entity.Author)
                .Size(12)
                .ForeColor(Color.Gray)
            .End()
                .RowAutoSize()
                    .Column(48).Content()
                        .Label($"{Entity.Content}")
                        .Size(12)
                        .ForeColor(Color.DarkGreen)
                    .End()
                    .Column(52).Content().ImageLayoutPanel(new RepositoryImage(Entity.Imgs.Select(i => i.Url).ToArray()))
                    .End()
                .End()
            .Build();
}