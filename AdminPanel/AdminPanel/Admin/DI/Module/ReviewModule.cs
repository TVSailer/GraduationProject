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
        Kernel.Bind<IView<ReviewFieldData, ReviewEntity>>().To<BaseUI<ReviewFieldData, ReviewEntity, ReviewDetailsButton>>();
        Kernel.Bind<IView<ReviewManagment>>().To<ReviewsCardUi>();

        Kernel.Bind<ReviewManagmentButton>().ToSelf();
        Kernel.Bind<ReviewDetailsButton>().ToSelf();
    }
}