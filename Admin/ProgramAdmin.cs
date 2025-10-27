using Admin.Forms;
using Admin.Forms.Lesson;
using Admin.Presents;
using DataAccess.Postgres;
using Logica;

namespace Admin
{
    public static class ProgramAdmin
    {
        public static void Run()
        {
            using (var context = new ApplicationDbContext())
            {
                new FormDataLessons(new LessonPresent(context)).ShowDialog();
            }
        }
    }
}