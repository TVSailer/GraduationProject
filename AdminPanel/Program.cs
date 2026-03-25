using Admin.DI;
using Admin.ViewModel.Model.AdminMain;
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

        controlView.LoadView<AdminPanelViewModel>();

        //var db = di.GetService<ApplicationDbContext>();
        //db.AddRange(
        //    new CategoryEntity() {Category = "IT"},
        //    new CategoryEntity() {Category = "ัยฮ"}
        //    );
        //db.SaveChanges();

        Application.Run(controlView.Form);
    }
}