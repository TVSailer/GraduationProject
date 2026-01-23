using DataAccess.Postgres;

namespace Visitor
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using (var db = new ApplicationDbContext())
            {
                ApplicationConfiguration.Initialize();
                Application.Run(new VisitorView(db));
            }
        }
    }
}