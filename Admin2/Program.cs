
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
        Application.Run(
            (Form)AdminDi
            .GetService<ControlView>()
            .LoadView<AdminPanelUi>());
    }
}

