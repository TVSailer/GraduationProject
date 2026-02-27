
using Admin.DI;
using Admin.View;
using DataAccess.Postgres;
using DataAccess.Postgres.Models;
using User_Interface_Library.View;

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

        //var f = new FIO("alsdkfj dfjk dks");
        //var d = di.GetService<ApplicationDbContext>();
        //d.AddRange(new TeacherEntity{FIO = f, AuthId = 1, DateBirth = "30.11.2005", NumberPhone = "86767676767"});
        //d.SaveChanges();

        Application.Run(controlView.Form);
    }
}

