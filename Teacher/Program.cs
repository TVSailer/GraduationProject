using DataAccess.Postgres;

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
