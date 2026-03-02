
using Admin.DI;
using UserInterface.View;

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
        controlView.LoadView(new AdminFieldData());

        //var d = di.GetService<ApplicationDbContext>();
        //d.Lessons.First().Reviews.Add(new ReviewEntity(4, "kasdhglkasdhgklasdklghkliadsf", d.Visitors.First()));
        //d.SaveChanges();

        Application.Run(controlView.Form);
    }
}

