using Admin.DI;
using Admin.ViewModel.AdminMain;
using Admin.ViewModel.Enter;
using Domain.Entitys;
using Domain.Repository;
using Domain.Service.FielService.BaseFileService;
using UserInterface.Service.View.Base;

namespace Admin;

internal static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    private static void Main()
    {
        ApplicationConfiguration.Initialize();

        var di = new MainDI();

        var controlView = di.GetService<IControlView>();

        var authFileService = di.GetService<IAuthFileService>();

        if (authFileService.Exists())
        {
            var auth = authFileService.ReadAuth();
            var authData = di
                .GetService<IRepository<AuthEntity>>()
                .Get()
                .ToArray()
                .SingleOrDefault(v => v.Equals(auth.login, auth.password));

            if (authData is not null)
                controlView.LoadView<AdminPanelViewModel>();
            else controlView.ShowDialog<EnterPanelViewModel>();
        }
        else controlView.ShowDialog<EnterPanelViewModel>();

        //di.GetService<TestData>();
    }
}