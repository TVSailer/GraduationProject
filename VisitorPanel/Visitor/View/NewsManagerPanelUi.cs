using DataAccess.PostgreSQL.Models;
using DataAccess.PostgreSQL.Repository;
using UserInterface.LayoutPanel;
using UserInterface.UiLayoutPanel.CardPanel.Args;
using UserInterface.View;
using Visitor.DI.Module;
using Visitor.FieldData.News.Button;
using Visitor.View.News;

namespace Visitor.View;

public class NewsManagerPanelUi(NewsManager dataUi, NewsRepository repository, NewsManagerButtons clickeds) : UiView<NewsManager>
{
    protected override IBuilder CreateUi(BuilderLayoutPanel builderLayoutPanel)
        => builderLayoutPanel.Column()
            .Row().Content()
            .CardTableLayoutPanel<NewsEntity, NewsCard>(repository.Get().ToArray())
            .Initialize()
            .End()
            .Row(80, SizeType.Absolute).Content().ButtonLayoutPanel(clickeds.GetButtons(new ClickedArgs<NewsManager>(dataUi))).End();
}