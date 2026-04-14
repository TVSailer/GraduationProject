using Ninject.Modules;
using UserInterface.View.Base;
using Visitor.View.Review;
using Visitor.ViewModel.Review;

namespace Visitor.DI.Module;

public class ReviewModule : NinjectModule
{
    public override void Load()
    {
        Kernel.Bind<IForma<ReviewAddingPanelViewModel>>().To<ReviewAddingPanelView>();
        Kernel.Bind<IForma<ReviewDetailsPanelViewModel>>().To<ReviewDetailsPanelView>();
    }
}