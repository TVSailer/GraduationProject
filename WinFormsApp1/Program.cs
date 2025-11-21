using AdminApp.Forms;
using DataAccess.Postgres;

namespace WinFormsApp1
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            using (var db = new ApplicationDbContext())
            {
                ApplicationConfiguration.Initialize();
                Application.Run(new AdminMainView(db));
            }
        }
    }
}