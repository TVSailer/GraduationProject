using Admin.Forms.Lesson;
using Admin.Presents;
using DataAccess.Postgres;

namespace Admin
{
    public static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            using (var context = new ApplicationDbContext())
            {
                Application.Run(new FormDataLessons(new LessonPresent(context)));
            }
        }
    }
}