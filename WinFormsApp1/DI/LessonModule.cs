using Admin.Commands_Handlers.Managment;
using Admin.View;
using Admin.View.Moduls.UIModel;
using Admin.View.ViewForm;
using Admin.ViewModel.Interface;
using Admin.ViewModel.Lesson;
using Admin.ViewModel.Managment;
using Admin.ViewModels.Lesson;
using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;
using MediatR;
using Ninject.Modules;

public class LessonModule : NinjectModule
{
    public override void Load()
    {
        Kernel.Bind<IRequest>().To<SendEntity<LessonEntity>>();
        Kernel.Bind<IRequestHandler<SendEntity<LessonEntity>>>()
            .To<InitializeDetailsPanelHandler<LessonEntity, LessonDetailsPanel>>();

        Kernel.Bind<IRequest>().To<InitializeUI<LessonEntity, LessonDetailsPanel>>();
        Kernel.Bind<IRequestHandler<InitializeUI<LessonEntity, LessonDetailsPanel>>>()
            .To<InitializeUIHandler<LessonEntity, LessonDetailsPanel>>();

        Kernel.Bind<Repository<LessonEntity>>().To<LessonsRepository>();
        Kernel.Bind<Repository<LessonCategoryEntity>>().To<LessonCategoryRepositroy>();

        Kernel.Bind<IViewModele<LessonEntity>, IAddingPanel<LessonEntity>, LessonAddingPanel>().To<LessonAddingPanel>()
            .InSingletonScope();
        Kernel.Bind<IViewModele<LessonEntity>, IDetailsPanel<LessonEntity>, LessonDetailsPanel>()
            .To<LessonDetailsPanel>().InSingletonScope();

        Kernel.Bind<IView<LessonDetailsPanel>>().To<UI<LessonEntity, LessonDetailsPanel>>().InSingletonScope();
        Kernel.Bind<IView<LessonAddingPanel>>().To<UI<LessonEntity, LessonAddingPanel>>().InSingletonScope();

        var ui = new UIBuilder<Lesson>();

        // Kernel.Bind<ObjectCard<LessonEntity>>().To<LessonCard>();

        Kernel.Bind<CardModule<LessonEntity, LessonCard>>().ToSelf();
        Kernel.Bind<IParametersButtons<Lesson>>()
            .To<ParametersManagmentButton<Lesson, LessonEntity, AdminMainViewModel, LessonAddingPanel>>();
        Kernel.Bind<ManagementView<LessonEntity, LessonCard, Lesson>>().ToSelf();
        Kernel.Bind<SerchManagment<LessonEntity>, LessonSerch>().To<LessonSerch>().InSingletonScope();
    }
}

public struct Lesson : IParam
{
}

public interface IParam
{
}