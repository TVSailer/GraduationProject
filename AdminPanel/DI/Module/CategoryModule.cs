using Admin.View.Category;
using Admin.ViewModel.Category;
using Ninject.Modules;
using UserInterface.View.Base;

namespace Admin.DI.Module;

public class CategoryModule : NinjectModule
{
    public override void Load()
    {
        Kernel.Bind<IForma<CategoryPanelViewModel>>().To<CategoryPanelView>();
    }
}