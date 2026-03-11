using Admin.FieldData.Model.Review;
using Admin.View.Moduls.Review;
using Ninject.Modules;
using UserInterface.View;

namespace Admin.DI.Module;

public record ReviewManager;

public class ReviewModule : NinjectModule
{
    public override void Load()
    {
        Kernel.Bind<UiView<ReviewFieldData, ReviewEntity>>().To<ReviewPanelUi>();
        Kernel.Bind<UiView<ReviewManager>>().To<ReviewsCardUi>();
    }
}