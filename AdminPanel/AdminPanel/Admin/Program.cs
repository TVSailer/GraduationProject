using Admin.DI;
using DataAccess.Postgres;
using DataAccess.Postgres.Seeding;
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

        var db = di.GetService<ApplicationDbContext>();

        DatabaseSeeder.SeedAsync(db);

        Application.Run(controlView.Form);
    }
}

