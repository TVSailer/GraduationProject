using Domain.Entitys;
using UserInterface.LayoutPanel;
using UserInterface.UiObjects.Card;

namespace Admin.View.News;

public class NewsCard : ObjectCard<NewsEntity>
{
    public NewsCard()
    {
        Size = new Size(450, 130);
    }

    public override IBuilder Content(BuilderLayoutPanel builderLayoutPanel)
        => builderLayoutPanel.Column()
            .Row().Content().Label(Entity.Title).ForeColor(Color.DarkBlue).Size(14).End()
            .Row().Content().Label($"📍 {Entity.Category}").Size(11).ForeColor(Color.Gray).End()
            .Row().Content().Label($"📅 {Entity.Date}").Size(11).ForeColor(Color.Gray).End()
            .Row().Content().Label($"👨‍💼 {Entity.Author}").Size(11).ForeColor(Color.Gray).End();
}