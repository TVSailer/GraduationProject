using Admin.Commands_Handlers.Managment;
using Admin.Memento;
using Admin.View;
using Admin.View.Moduls.UIModel;
using Admin.View.ViewForm;
using Admin.ViewModel;
using Admin.ViewModel.Interface;
using Admin.ViewModel.Managment;
using Admin.ViewModel.Managmetn;
using Admin.ViewModel.Model.Visitor;
using Admin.ViewModel.Model.Visitor.Buttons;
using Admin.ViewModels.Lesson;
using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;
using MediatR;
using Ninject.Modules;
using System.ComponentModel;

public record LessonMangment;
public record LessonWordWithVisitor;

public class LessonAddingPanelUI(TeacherRepository teacherRepository, LessonCategoryRepositroy eventCategoryRepositroy)
    : LessonFieldData(teacherRepository, eventCategoryRepositroy);

public class LessonDetailsPanelUI(TeacherRepository teacherRepository, LessonCategoryRepositroy eventCategoryRepositroy)
    : LessonFieldData(teacherRepository, eventCategoryRepositroy);


public class LessonModule : NinjectModule
{
    public override void Load()
    {
        
        Kernel.Bind<MementoData<VisitorEntity>>().ToSelf().InSingletonScope();

        Kernel.Bind<IRequestHandler<InitializeDetailsPanelRequest<LessonEntity>>>().To<InitializeDetailsPanelHandler<LessonEntity, LessonDetailsPanelUI>>();
        //Kernel.Bind<IRequestHandler<RecoveryPanelRequest<LessonDetailsPanelUI>>>().To<RecoveryPanelHandler<LessonEntity, LessonDetailsPanelUI>>();

        Kernel.Bind<Repository<LessonEntity>>().To<LessonsRepository>();
        Kernel.Bind<Repository<LessonCategoryEntity>>().To<LessonCategoryRepositroy>();

        Kernel.Bind<LessonAddingPanelUI>().ToSelf();
        Kernel.Bind<LessonDetailsPanelUI>().ToSelf();
        Kernel.Bind<LessonMangment>().ToSelf();

        Kernel.Bind<IParametersSearch<LessonEntity, LessonFieldSearch>>().To<LessonSearch>();
        Kernel.Bind<LessonFieldSearch>().ToSelf();
        Kernel.Bind<SearchEntity<LessonEntity, LessonFieldSearch>>().ToSelf();

        Kernel.Bind<IView<LessonAddingPanelUI>, IView<LessonAddingPanelUI, LessonEntity>>().To<BaseUI<LessonAddingPanelUI, LessonEntity>>();
        Kernel.Bind<IView<LessonDetailsPanelUI>, IView<LessonDetailsPanelUI, LessonEntity>>().To<BaseUI<LessonDetailsPanelUI, LessonEntity>>();
        Kernel.Bind<IView<LessonMangment>>().To<ManagmentEntityUi<LessonMangment, LessonEntity, LessonFieldSearch>>();
        Kernel.Bind<IView<LessonWordWithVisitor>>().To<ManagmentEntityUi<LessonWordWithVisitor, VisitorEntity, VisitorFieldSearch>>();

        Kernel.Bind<ObjectCard<LessonEntity>>().To<LessonCard>();
        Kernel.Bind<CardModule<LessonEntity, LessonFieldSearch>>().ToSelf();

        Kernel.Bind<IParametersButtons<LessonMangment>>().To<ManagmentButton<LessonMangment, LessonEntity, LessonAddingPanelUI>>();
        Kernel.Bind<IParametersButtons<LessonAddingPanelUI>>().To<LessonAddingPanelButton>();
        Kernel.Bind<IParametersButtons<LessonDetailsPanelUI>>().To<LessonDetailsPanelButton>();
        Kernel.Bind<IParametersButtons<LessonWordWithVisitor>>().To<LessonWordWithVisitorButton>();
    }
}
