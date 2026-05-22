using Admin.DI;
using Admin.ViewModel.AdminMain;
using Admin.ViewModel.Enter;
using Domain.Enum;
using Domain.Service.AuthService.BaseAuhtService;
using Domain.Service.ControlViewService.BaseControlView;

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
        //TestData(di);
        LoadAdminPanel(di);
    }

    private static void TestData(MainDI di)
        => di.GetService<TestData>();

    private static void LoadAdminPanel(MainDI di)
    {
        var controlView = di.GetService<IControlViewService>();
        var authService = di.GetService<IAuthService>();

        if (authService.IsRoleAuth(UserRole.Admin))
        {
            if(authService.IsSaveAuth(UserRole.Admin))
                controlView.LoadView<AdminPanelViewModel>();
            else controlView.ShowDialog<EnterPanelViewModel>();
        }
        else
        {
            authService.CreateAuth("Admin", UserRole.Admin);
            authService.MessageAuth();
            controlView.ShowDialog<EnterPanelViewModel>();
        }
    }
}