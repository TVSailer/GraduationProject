using Admin.Forms;
using Admin.Forms.Lesson;
using Admin.Presents;
using DataAccess.Postgres;
using Logica;

namespace Admin
{
    public static class ProgramAdmin
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
        }

        public static void Run()
        {
            using (var context = new ApplicationDbContext())
            {
                new FormDataLessons(new LessonPresent(context)).ShowDialog();
            }
        }
    }
}