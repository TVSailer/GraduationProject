using Admin.View;
using Admin.View.ViewForm;
using Admin.ViewModel.Interface;
using Admin.ViewModel.Managment;
using Admin.ViewModel.Model.Review;
using Admin.ViewModel.Model.Review.Buttons;
using Logica.Interface;
using Ninject.Modules;

namespace Admin.DI;

public record ReviewManagment : IFieldData;

public class ReviewModule : NinjectModule
{
    public override void Load()
    {
        Kernel.Bind<IView<ReviewFieldData, ReviewEntity>>().To<BaseUi<ReviewFieldData, ReviewEntity, ReviewDetailsButton>>();
        Kernel.Bind<IView<ReviewManagment>>().To<ReviewsCardUi>();
    }
}