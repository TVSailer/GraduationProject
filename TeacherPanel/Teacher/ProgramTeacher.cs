using DataAccess.Postgres;
using DataAccess.Postgres.Models;
using Teacher.Forms.Dates;
using Teacher.Presents;

namespace Teacher
{
    public static class ProgramTeacher
    {
        public static void Run(TeacherEntity teacher)
        {
            using (var context = new ApplicationDbContext())
            {
                new FormTreckingAttendance(new DatePresent(context, teacher)).ShowDialog();
            }
        }
    }
}
