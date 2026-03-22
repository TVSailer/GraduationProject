using Ninject.Modules;

namespace Admin.DI.Module;

public record NewsManager;


public class NewsModule : NinjectModule
{
    public override void Load()
    {
        //Kernel.Bind<UiView<NewsFieldData>>().To<NewsPanelUi<NewsAddingButton>>();
        //Kernel.Bind<UiView<NewsFieldData, NewsEntity>>().To<NewsPanelUi<NewsDetailsButton>>();
        //Kernel.Bind<UiView<NewsManager>>().To<ManagerEntityUi<
        //    NewsManager,
        //    NewsEntity,
        //    NewsFieldSearch,
        //    NewsCard,
        //    NewsManagerClicked>>();
    }
}