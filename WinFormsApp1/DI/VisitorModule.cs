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

public class VisitorDetailsPanelUI : VisitorFieldData{}
public class VisitorAddingPanelUI : VisitorFieldData{}
public record VisitorMangment {}

public class VisitorModule : NinjectModule
{
    public override void Load()
    {
        Kernel.Bind<VisitorsRepository, Repository<VisitorEntity>>().To<VisitorsRepository>().InSingletonScope();

        Kernel.Bind<VisitorAddingPanelUI>().ToSelf();
        Kernel.Bind<VisitorDetailsPanelUI>().ToSelf();
        Kernel.Bind<VisitorMangment>().ToSelf();

        Kernel.Bind<IParametersSearch<VisitorEntity, VisitorFieldSearch>>().To<VisitorSearch>();
        Kernel.Bind<VisitorFieldSearch>().ToSelf();
        Kernel.Bind<SearchEntity<VisitorEntity, VisitorFieldSearch>>().ToSelf();

        Kernel.Bind<IView<VisitorAddingPanelUI>, IView<VisitorAddingPanelUI, VisitorEntity>>().To<BaseUI<VisitorAddingPanelUI, VisitorEntity>>();
        Kernel.Bind<IView<VisitorDetailsPanelUI>, IView<VisitorDetailsPanelUI, VisitorEntity>>().To<BaseUI<VisitorDetailsPanelUI, VisitorEntity>>();
        Kernel.Bind<IView<VisitorMangment>>().To<ManagmentEntityUi<VisitorMangment, VisitorEntity, VisitorFieldSearch, VisitorDetailsPanelUI>>();

        Kernel.Bind<ObjectCard<VisitorEntity>>().To<VisitorCard>();

        Kernel.Bind<IParametersButtons<VisitorMangment>>().To<ManagmentButton<VisitorMangment, VisitorEntity, VisitorAddingPanelUI>>();
        Kernel.Bind<IParametersButtons<VisitorAddingPanelUI>>().To<VisitorAddingPanelButton>();
        Kernel.Bind<IParametersButtons<VisitorDetailsPanelUI>>().To<VisitorDetailsPanelButton>();
        
    }
}