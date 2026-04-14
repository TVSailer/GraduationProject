using Ninject.Modules;
using Teacher.View.News;
using Teacher.ViewModel.News;
using UserInterface.View.Base;

namespace Teacher.DI.Module;

public class NewsModule : NinjectModule

{
    public override void Load()
    {
        Kernel.Bind<IView<NewsManagerPanelViewModel>>().To<NewsManagerPanelView>();
    }
}