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

public struct LessonMangment{}

public class LessonModule : NinjectModule
{
    public override void Load()
    {
        Kernel.Bind<IRequest>().To<SendEntity<LessonEntity>>();
        Kernel.Bind<IRequestHandler<SendEntity<LessonEntity>>>().To<InitializeDetailsPanelHandler<LessonEntity, LessonDetailsPanel>>();

        Kernel.Bind<IRequestHandler<InitializeUI<LessonAddingPanel>>>().To<InitializeUIHandler<LessonAddingPanel>>();
        Kernel.Bind<IRequestHandler<InitializeUI<LessonDetailsPanel>>>().To<InitializeUIHandler<LessonDetailsPanel>>();
        Kernel.Bind<IRequestHandler<InitializeUI<LessonMangment>>>().To<InitializeUIHandler<LessonMangment>>();

        Kernel.Bind<Repository<LessonEntity>>().To<LessonsRepository>();
        Kernel.Bind<Repository<LessonCategoryEntity>>().To<LessonCategoryRepositroy>();

        Kernel.Bind<UIBuilder<LessonAddingPanel>>().ToSelf();
        Kernel.Bind<UIBuilder<LessonDetailsPanel>>().ToSelf();
        Kernel.Bind<UIBuilder<LessonMangment>>().ToSelf();

        Kernel.Bind<IViewModel<LessonAddingPanel>>().To<LessonAddingPanel>().InSingletonScope();
        Kernel.Bind<IViewModel<LessonDetailsPanel>>().To<LessonDetailsPanel>().InSingletonScope();

        Kernel.Bind<SerchEntity<LessonEntity>, LessonSerch>().To<LessonSerch>().InSingletonScope();

        Kernel.Bind<IView<LessonAddingPanel>>().To<BaseUI<LessonAddingPanel, LessonEntity>>().InSingletonScope();
        Kernel.Bind<IView<LessonDetailsPanel>>().To<BaseUI<LessonDetailsPanel, LessonEntity>>().InSingletonScope();
        Kernel.Bind<IView<LessonMangment>>().To<ManagmentEntityUI<LessonMangment, LessonEntity>>();

        Kernel.Bind<ObjectCard<LessonEntity>>().To<LessonCard>();
        Kernel.Bind<CardModule<LessonEntity>>().ToSelf();
        Kernel.Bind<IParametersButtons<LessonMangment>>().To<
            ParametersManagmentButton<
                LessonMangment, 
                LessonEntity, 
                AdminMainViewModel, 
                LessonAddingPanel>>();
    }
}
