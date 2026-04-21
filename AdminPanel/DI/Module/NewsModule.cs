using Admin.View.News;
using Admin.ViewModel.News;
using Ninject.Modules;
using UserInterface.View.Base;

namespace Admin.DI.Module;

public record NewsManager;


public class NewsModule : NinjectModule
{
    public override void Load()
    {
        Kernel.Bind<IView<NewsManagerPanelViewModel>>().To<NewsManagerPanelView>();
        Kernel.Bind<IView<NewsAddingPanelViewModel>>().To<NewsAddingPanelView>();
        Kernel.Bind<IView<NewsDetailsPanelViewModel>>().To<NewsDetailsPanelView>();
    }
}