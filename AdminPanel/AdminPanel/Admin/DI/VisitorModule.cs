using Admin.View;
using Admin.View.Moduls.Visitor;
using Admin.View.ViewForm;
using Admin.ViewModel.Interface;
using Admin.ViewModel.Managment;
using Admin.ViewModel.Model.Lesson.Buttons;
using Admin.ViewModel.Model.Visitor;
using Admin.ViewModel.Model.Visitor.Buttons;
using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;
using Ninject.Modules;

namespace Admin.DI;

public class VisitorDetailsFieldData : VisitorFieldData;
public class VisitorAddingFieldData : VisitorFieldData;
public class VisitorNotBelongingLessonCardPanelUi : IFieldData;
public record VisitorBelongingLesson : IFieldData;
public record VisitorManagment : IFieldData;

public class VisitorModule : NinjectModule
{
    public override void Load()
    {
        Kernel.Bind<VisitorsRepository, Repository<VisitorEntity>>().To<VisitorsRepository>().InSingletonScope();

        Kernel.Bind<IParametersSearch<VisitorEntity, VisitorFieldSearch>>().To<VisitorSearch>();

        Kernel.Bind<
            IView<VisitorAddingFieldData>, 
            IView<VisitorAddingFieldData, VisitorEntity>>().To<BaseUI<VisitorAddingFieldData, VisitorEntity, VisitorAddingButton>>();
        Kernel.Bind<
            IView<VisitorDetailsFieldData>, 
            IView<VisitorDetailsFieldData, VisitorEntity>>().To<VisitorDetailsUi>();
        Kernel.Bind<IView<VisitorNotBelongingLessonCardPanelUi>>().To<VisitorNotBelongingLessonCardUi>();
        Kernel.Bind<IView<VisitorManagment>>().To<ManagmentEntityUi<
            VisitorManagment, 
            VisitorEntity, 
            VisitorFieldSearch, 
            VisitorCard,
            VisitorManagmentButton>>();
        Kernel.Bind<IView<VisitorBelongingLesson>>().To<VisitorBelongingLessonCardUi>();

        Kernel.Bind<VisitorManagmentButton>().ToSelf();
        Kernel.Bind<VisitorAddingButton>().ToSelf();
        Kernel.Bind<VisitorDetailsButton>().ToSelf();
        Kernel.Bind<VisitorNotBelongingLessonButton>().ToSelf();
        Kernel.Bind<VisitorBelongingLessonButton>().ToSelf();
    }
}