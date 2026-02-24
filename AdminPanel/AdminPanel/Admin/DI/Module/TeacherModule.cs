using Admin.View;
using Admin.View.Moduls.Teacher;
using Admin.View.ViewForm;
using Admin.ViewModel.Interface;
using Admin.ViewModel.Managment;
using Admin.ViewModel.Model.Teacher;
using Admin.ViewModel.Model.Teacher.Buttons;
using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;
using Ninject.Modules;

namespace Admin.DI;

public record TeacherManagment : IFieldData;
public class TeacherAddingFieldData : TeacherFieldData;
public class TeacherDetailsFieldData : TeacherFieldData;

public class TeacherModule : NinjectModule
{
    public override void Load()
    {
        Kernel.Bind<Repository<TeacherEntity>>().To<TeacherRepository>().InSingletonScope();

        Kernel.Bind<IParametersSearch<TeacherEntity, TeacherFieldSearch>>().To<TeacherSearch>();

        Kernel.Bind<IView<TeacherAddingFieldData>>().To<BaseUI<TeacherAddingFieldData, TeacherEntity, TeacherAddingButton>>();
        Kernel.Bind<IView<TeacherDetailsFieldData, TeacherEntity>>().To<TeacherDetailsUi>();
        Kernel.Bind<IView<TeacherManagment>>().To<ManagmentEntityUi<
            TeacherManagment,
            TeacherEntity,
            TeacherFieldSearch,
            TeacherCard,
            TeacherManagmentButton>>();
    }
}