using Admin.View.ViewForm;
using Admin.ViewModel.Interface;
using Admin.ViewModel.Managment;
using Admin.ViewModel.Model.Review;
using Admin.ViewModel.Model.Review.Buttons;
using Ninject.Modules;

namespace Admin.DI;

public record ReviewManagment : IFieldData;

public class ReviewModule : NinjectModule
{
    public override void Load()
    {
        Kernel.Bind<IParametersSearch<ReviewEntity, ReviewFieldSearch>>().To<ReviewSearch>();

        Kernel.Bind<IView<ReviewDetailsFieldData, ReviewEntity>>().To<BaseUI<ReviewDetailsFieldData, ReviewEntity, ReviewDetailsButton>>();
        Kernel.Bind<IView<ReviewManagment>>().To<ReviewsCardUi>();

        Kernel.Bind<ReviewManagmentButton>().ToSelf();
        Kernel.Bind<ReviewDetailsButton>().ToSelf();
    }
}