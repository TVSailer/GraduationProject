using Admin.FieldData.Model.News;
using Admin.FieldData.Model.News.Buttons;
using Admin.View;
using Admin.View.Moduls.News;
using DataAccess.PostgreSQL.Models;
using DataAccess.PostgreSQL.Repository;
using Ninject.Modules;
using UserInterface.View;

namespace Admin.DI.Module;

public record NewsManager;


public class NewsModule : NinjectModule
{
    public override void Load()
    {
        Kernel.Bind<Repository<NewsEntity>>().To<NewsRepository>().InSingletonScope();

        Kernel.Bind<UiView<NewsFieldData>>().To<NewsPanelUi<NewsAddingButton>>();
        Kernel.Bind<UiView<NewsFieldData, NewsEntity>>().To<NewsPanelUi<NewsDetailsButton>>();
        Kernel.Bind<UiView<NewsManager>>().To<ManagerEntityUi<
            NewsManager,
            NewsEntity,
            NewsFieldSearch,
            NewsCard,
            NewsManagerClicked>>();
    }
}