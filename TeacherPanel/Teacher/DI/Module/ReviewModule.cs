using Ninject.Modules;
using Teacher.View.Review;
using Teacher.ViewModel.Review;
using UserInterface.View.Base;

namespace Teacher.DI.Module;

public class ReviewModule : NinjectModule
{
    public override void Load()
    {
        Kernel.Bind<IForma<ReviewAddingPanelViewModel>>().To<ReviewAddingPanelView>();
        Kernel.Bind<IForma<ReviewDetailsPanelViewModel>>().To<ReviewDetailsPanelView>();
    }
}