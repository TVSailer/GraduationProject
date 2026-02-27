using Admin.ViewModel.Interface;
using Ninject.Modules;
using System.ComponentModel;
using Admin.View.Moduls.AdminMain;
using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;
using User_Interface_Library.View;

namespace Admin.DI;

public record AdminFieldData : IFieldData
{
    public Control GetUi()
    {
        throw new NotImplementedException();
    }
}

public class AdminModule : NinjectModule
{
    public override void Load()
    {
        Kernel.Bind<UiView<AdminFieldData>>().To<AdminMainUi>();
        Kernel.Bind<Repository<CategoryEntity>>().To<CategoryRepository>();
        Kernel.Bind<Repository<TeacherEntity>>().To<TeacherRepository>();
    }
}