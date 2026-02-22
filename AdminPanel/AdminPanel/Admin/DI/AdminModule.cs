using Admin.View.ViewForm;
using Admin.ViewModel.Interface;
using Ninject.Modules;
using System.ComponentModel;
using Admin.View.Moduls.AdminMain;

namespace Admin.DI;

public record AdminFieldData : IFieldData;

public class AdminModule : NinjectModule
{
    public override void Load()
    {
        Kernel.Bind<IView<AdminFieldData>>().To<AdminMainUi>();
        Kernel.Bind<AdminFieldData>().ToSelf();
        Kernel.Bind<AdminMainViewButton>().ToSelf();
    }
}