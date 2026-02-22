
using Admin.DI;
using Admin.View;

internal static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();

        var di = new AdminDi();
        var controlView = di.GetService<ControlView>();
        controlView.LoadView<AdminFieldData>();

        Application.Run(controlView.Form);
    }
}

