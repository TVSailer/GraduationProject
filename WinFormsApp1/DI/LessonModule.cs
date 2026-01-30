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

public struct LessonAddingPanelParam : IParam { }
public struct LessonDetailsPanelParam : IParam { }
public struct LessonSearchParam : IParam { }
public struct LessonManagmentEntityParam : IParam { }

public class LessonModule : NinjectModule
{
    public override void Load()
    {
        Kernel.Bind<IRequest>().To<SendEntity<LessonEntity>>();
        Kernel.Bind<IRequestHandler<SendEntity<LessonEntity>>>().To<InitializeDetailsPanelHandler<LessonEntity, LessonDetailsPanel>>();

        //Kernel.Bind<IRequest>().To<InitializeUI<LessonDetailsPanelParam>>();
        Kernel.Bind<IRequestHandler<InitializeUI<LessonDetailsPanelParam>>>().To<InitializeUIHandler<LessonDetailsPanelParam>>();
        Kernel.Bind<IRequestHandler<InitializeUI<LessonAddingPanelParam>>>().To<InitializeUIHandler<LessonAddingPanelParam>>();
        Kernel.Bind<IRequestHandler<InitializeUI<LessonManagmentEntityParam>>>().To<InitializeUIHandler<LessonManagmentEntityParam>>();

        Kernel.Bind<Repository<LessonEntity>>().To<LessonsRepository>();
        Kernel.Bind<Repository<LessonCategoryEntity>>().To<LessonCategoryRepositroy>();

        Kernel.Bind<UIBuilder<LessonAddingPanelParam>>().ToSelf();
        Kernel.Bind<UIBuilder<LessonDetailsPanelParam>>().ToSelf();
        Kernel.Bind<UIBuilder<LessonDetailsPanelParam>>().ToSelf();
        Kernel.Bind<UIBuilder<LessonManagmentEntityParam>>().ToSelf();

        Kernel.Bind<IViewModel<LessonAddingPanelParam>>().To<LessonAddingPanel>().InSingletonScope();
        Kernel.Bind<IViewModel<LessonDetailsPanelParam>>().To<LessonDetailsPanel>().InSingletonScope();
        Kernel.Bind<IViewModel<LessonManagmentEntityParam>, SerchEntity<LessonEntity>, LessonSerch>().To<LessonSerch>().InSingletonScope();

        Kernel.Bind<IView<LessonDetailsPanelParam>>().To<BaseUI<LessonDetailsPanelParam, LessonEntity>>().InSingletonScope();
        Kernel.Bind<IView<LessonAddingPanelParam>>().To<BaseUI<LessonAddingPanelParam, LessonEntity>>().InSingletonScope();
        Kernel.Bind<IView<LessonManagmentEntityParam>>().To<ManagmentEntityUI<LessonManagmentEntityParam, LessonEntity, LessonCard>>();

        // Kernel.Bind<ObjectCard<LessonEntity>>().To<LessonCard>();

        Kernel.Bind<CardModule<LessonEntity, LessonCard>>().ToSelf();
        Kernel.Bind<IParametersButtons<LessonManagmentEntityParam>>()
            .To<ParametersManagmentButton<LessonManagmentEntityParam, LessonEntity, AdminMainViewModel, LessonAddingPanel>>();
    }
}

public interface IParam
{
}