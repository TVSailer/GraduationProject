using DataAccess.Postgres;
using Entere.Forms;
using Entere.Presents;

namespace Entere
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            using (var context = new ApplicationDbContext())
            {
                Application.Run(new FormEnter(new EnterPresent(context)));
            }
            
        }
    }
}