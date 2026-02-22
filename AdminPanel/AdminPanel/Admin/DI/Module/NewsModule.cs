using Admin.View;
using Admin.View.ViewForm;
using Admin.ViewModel.Interface;
using Admin.ViewModel.Managment;
using Admin.ViewModel.Model.Event;
using Admin.ViewModel.Model.Event.Buttons;
using Admin.ViewModel.Model.News;
using Admin.ViewModel.Model.News.Buttons;
using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;
using Ninject.Modules;
using WinFormsApp1.ViewModelEntity.Event;

namespace Admin.DI;

public record NewsManagment : IFieldData;
public class NewsAddingFieldData(NewsCategoryRepository newsCategoryRepository)
    : NewsFieldData(newsCategoryRepository);
public class NewsDetailsFieldData(NewsCategoryRepository newsCategoryRepository)
    : NewsFieldData(newsCategoryRepository);


public class NewsModule : NinjectModule
{
    public override void Load()
    {
        Kernel.Bind<Repository<NewsEntity>>().To<NewsRepository>().InSingletonScope();
        Kernel.Bind<Repository<NewsCategoryEntity>>().To<NewsCategoryRepository>().InSingletonScope();

        Kernel.Bind<IParametersSearch<NewsEntity, NewsFieldSearch>>().To<NewsSearch>();

        Kernel.Bind<IView<NewsAddingFieldData>>().To<BaseUI<NewsAddingFieldData, NewsEntity, NewsAddingButton>>();
        Kernel.Bind<IView<NewsDetailsFieldData, NewsEntity>>().To<BaseUI<NewsDetailsFieldData, NewsEntity, NewsDetailsButton>>();
        Kernel.Bind<IView<NewsManagment>>().To<ManagmentEntityUi<
            NewsManagment,
            NewsEntity,
            NewsFieldSearch,
            NewsCard,
            NewsManagmentButton>>();

        Kernel.Bind<NewsManagmentButton>().ToSelf();
        Kernel.Bind<NewsAddingButton>().ToSelf();
        Kernel.Bind<NewsDetailsButton>().ToSelf();
    }
}