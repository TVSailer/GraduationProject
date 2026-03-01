using Admin.FieldData.Model.Teacher;
using Admin.FieldData.Model.Teacher.Buttons;
using Admin.View;
using Admin.View.Moduls.Teacher;
using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;
using Ninject.Modules;
using UserInterface.View;

namespace Admin.DI.Module;

public record TeacherManager;

public class TeacherModule : NinjectModule
{
    public override void Load()
    {
        Kernel.Bind<Repository<TeacherEntity>>().To<TeacherRepository>().InSingletonScope();

        Kernel.Bind<UiView<TeacherFieldData>>().To<TeacherPanelUi<TeacherAddingButton>>();
        Kernel.Bind<UiView<TeacherFieldData, TeacherEntity>>().To<TeacherAdditionalPanelUi>();
        Kernel.Bind<UiView<TeacherManager>>().To<ManagerEntityUi<
            TeacherManager,
            TeacherEntity,
            TeacherFieldSearch,
            TeacherCard,
            TeacherManagerButton>>();
    }
}