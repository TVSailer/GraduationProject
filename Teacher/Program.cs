using DataAccess.Postgres;
using DataAccess.Postgres.Repository;
using Teacher.Forms.Dates;
using Teacher.Presents;

namespace Teacher
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            using (var context = new ApplicationDbContext())
            {
                //new FormTreckingAttendance(new DatePresent(context)).ShowDialog();
            }
        }
    }
}
