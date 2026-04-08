using Ninject.Modules;
using UserInterface.View.Base;
using Visitor.View.News;
using Visitor.ViewModel.News;

namespace Visitor.DI.Module;

public class NewsModule : NinjectModule

{
    public override void Load()
    {
        Kernel.Bind<IView<NewsManagerPanelViewModel>>().To<NewsManagerPanelView>();
    }
}