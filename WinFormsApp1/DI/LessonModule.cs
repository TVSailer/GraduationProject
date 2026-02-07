using Admin.Commands_Handlers.Managment;
using Admin.View;
using Admin.View.Moduls.UIModel;
using Admin.View.ViewForm;
using Admin.ViewModel.Interface;
using Admin.ViewModel;
using Admin.ViewModel.Managment;
using Admin.ViewModel.Managmetn;
using Admin.ViewModel.Model.Visitor;
using Admin.ViewModels.Lesson;
using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;
using MediatR;
using Ninject.Modules;

public record LessonMangment{}
public record LessonWordWithVisitor{}

public class LessonAddingPanelUI(TeacherRepository teacherRepository, LessonCategoryRepositroy eventCategoryRepositroy)
    : LessonFieldData(teacherRepository, eventCategoryRepositroy);

public class LessonDetailsPanelUI(TeacherRepository teacherRepository, LessonCategoryRepositroy eventCategoryRepositroy)
    : LessonFieldData(teacherRepository, eventCategoryRepositroy);


public class LessonModule : NinjectModule
{
    public override void Load()
    {
        Kernel.Bind<IRequestHandler<SendEntityRequest<LessonEntity>>>()
            .To<InitializeDetailsPanelHandler<LessonEntity, LessonDetailsPanelUI>>();

        Kernel.Bind<Repository<LessonEntity>>().To<LessonsRepository>();
        Kernel.Bind<Repository<LessonCategoryEntity>>().To<LessonCategoryRepositroy>();

        Kernel.Bind<LessonAddingPanelUI>().ToSelf();
        Kernel.Bind<LessonDetailsPanelUI>().ToSelf();
        Kernel.Bind<LessonMangment>().ToSelf();

        Kernel.Bind<SearchEntity<LessonEntity, LessonFieldSearch>, LessonSearch>().To<LessonSearch>();

        Kernel.Bind<IView<LessonAddingPanelUI, LessonEntity>>().To<BaseUI<LessonAddingPanelUI, LessonEntity>>();
        Kernel.Bind<IView<LessonDetailsPanelUI, LessonEntity>>().To<BaseUI<LessonDetailsPanelUI, LessonEntity>>();
        Kernel.Bind<IView<LessonMangment>>().To<ManagmentEntityUI<LessonMangment, LessonEntity, LessonFieldSearch>>();
        Kernel.Bind<IView<LessonWordWithVisitor>>().To<ManagmentEntityUI<LessonWordWithVisitor, VisitorEntity, VisitorFieldSearch>>();

        Kernel.Bind<ObjectCard<LessonEntity>>().To<LessonCard>();
        Kernel.Bind<CardModule<LessonEntity, LessonFieldSearch>>().ToSelf();

        Kernel.Bind<IParametersButtons<LessonMangment>>().To<ParametersManagmentButton<LessonMangment, LessonEntity, AdminMainViewModel, LessonAddingPanelUI>>();
        Kernel.Bind<IParametersButtons<LessonAddingPanelUI>>().To<LessonAddingPanelButton>();
        Kernel.Bind<IParametersButtons<LessonDetailsPanelUI>>().To<LessonDetailsPanelButton>();
        Kernel.Bind<IParametersButtons<LessonWordWithVisitor>>().To<LessonWordWithVisitorButton>();
    }
}
