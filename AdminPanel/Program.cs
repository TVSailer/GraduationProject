using Abstract.View;
using Admin.DI;
using Admin.View.Moduls.AdminMain;

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

        var di = new AdminDi();

        var controlView = di.GetService<ControlView>();
        controlView.LoadView<AdminMainUi>();

        Application.Run(controlView.Form);
    }
}