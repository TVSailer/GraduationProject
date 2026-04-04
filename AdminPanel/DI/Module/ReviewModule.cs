using Admin.View.Moduls.Review;
using Admin.ViewModel.Model.Review;
using Ninject.Modules;
using UserInterface.View.Base;

namespace Admin.DI.Module;

public class ReviewModule : NinjectModule
{
    public override void Load()
    {
        Kernel.Bind<IView<ReviewDetailsPanelViewModel>>().To<ReviewDetailsPanelView>();
        Kernel.Bind<IView<ReviewManagerViewModel>>().To<ReviewsManagerPanelView>();
    }
}