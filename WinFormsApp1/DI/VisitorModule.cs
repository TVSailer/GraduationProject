using Admin.View;
using Admin.View.Moduls.Visitor;
using Admin.View.ViewForm;
using Admin.ViewModel.Interface;
using Admin.ViewModel.Managment;
using Admin.ViewModel.Model.Visitor;
using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;
using Ninject.Modules;

public class VisitorModule : NinjectModule
{
    public override void Load()
    {
        Kernel.Bind<Repository<VisitorEntity>>().To<VisitorsRepository>();

        Kernel.Bind<IViewModele<VisitorEntity>>().To<VisitorAddingPanel>().InSingletonScope();
        Kernel.Bind<IViewModele<VisitorEntity>>().To<VisitorDetailsPanel>().InSingletonScope();

        Kernel.Bind<IView<VisitorEntity>>().To<UI<VisitorEntity, VisitorAddingPanel>>().InSingletonScope();
        Kernel.Bind<IView<VisitorEntity>>().To<UI<VisitorEntity, VisitorDetailsPanel>>().InSingletonScope();

        Kernel.Bind<ManagmentModelView<VisitorEntity>>().ToSelf();
        Kernel.Bind<ManagementView<VisitorEntity, VisitorCard>>().ToSelf();
        Kernel.Bind<SerchManagment<VisitorEntity>>().To<VisitorSerch>().InSingletonScope();

    }
}