using Admin.View;
using Admin.View.Moduls.UIModel;
using Admin.View.Moduls.Visitor;
using Admin.View.ViewForm;
using Admin.ViewModel.Managment;
using Admin.ViewModel.Model.Visitor;
using Admin.ViewModel.Model.Visitor.Buttons;
using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;
using MediatR;
using Ninject.Modules;

namespace Admin.DI;

public class VisitorDetailsPanelUi : VisitorFieldData;
public class VisitorAddingPanelUi : VisitorFieldData;
public class VisitorCardPanelUi : VisitorFieldData;
public record VisitorMangment {}

public class VisitorModule : NinjectModule
{
    public override void Load()
    {
        Kernel.Bind<VisitorsRepository, Repository<VisitorEntity>>().To<VisitorsRepository>().InSingletonScope();

        Kernel.Bind<IParametersSearch<VisitorEntity, VisitorFieldSearch>>().To<VisitorSearch>();

        Kernel.Bind<IView<VisitorAddingPanelUi>, IView<VisitorAddingPanelUi, VisitorEntity>>().To<BaseUI<VisitorAddingPanelUi, VisitorEntity>>();
        Kernel.Bind<IView<VisitorDetailsPanelUi>, IView<VisitorDetailsPanelUi, VisitorEntity>>().To<VisitorDetailsUi>();
        Kernel.Bind<IView<VisitorCardPanelUi>, IView<VisitorCardPanelUi, VisitorEntity>>().To<VisitorCardUi>();
        Kernel.Bind<IView<VisitorMangment>>().To<ManagmentEntityUi<VisitorMangment, VisitorEntity, VisitorFieldSearch, VisitorDetailsPanelUi>>();

        Kernel.Bind<ObjectCard<VisitorEntity>>().To<VisitorCard>();

        Kernel.Bind<IParametersButtons<VisitorMangment>>().To<ManagmentVisitorButton>();
        Kernel.Bind<IParametersButtons<VisitorAddingPanelUi>>().To<VisitorAddingPanelButton>();
        Kernel.Bind<IParametersButtons<VisitorDetailsPanelUi>>().To<VisitorDetailsPanelButton>();
        Kernel.Bind<IParametersButtons<VisitorCardPanelUi>>().To<VisitorCardPanelButton>();
        
    }
}