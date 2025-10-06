using DataAccess.Postgres.Models;

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
            ProgramVisitor.Run();
        }
    }
}