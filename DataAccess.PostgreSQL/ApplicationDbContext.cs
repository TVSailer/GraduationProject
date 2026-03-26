using Domain.Entitys;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace DataAccess.PostgreSQL
{
    public class ApplicationDbContext : DbContext
    {
        private readonly string _appSetting;

        public DbSet<VisitorEntity> Visitors { get; set; }
        public DbSet<TeacherEntity> Teachers { get; set; }
        public DbSet<DateAttendanceEntity> DateAttendances { get; set; }
        public DbSet<LessonEntity> Lessons { get; set; }
        public DbSet<NewsEntity> News { get; set; }
        public DbSet<EventEntity> Events { get; set; }
        public DbSet<ReviewEntity> Reviews { get; set; }
        public DbSet<LessonScheduleEntity> LessonSchedule { get; set; }
        public DbSet<AuthEntity> Auths { get; set; }

        public ApplicationDbContext(string appSetting)
        {
            _appSetting = appSetting;
            Database.EnsureCreated();
            //Database.Migrate();
        }
        
        public ApplicationDbContext()
        {
            Database.EnsureCreated();
            //Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("host=localhost;port=5432;database=db;username=postgres;password=Sailer22_8");//ConfigurationManager.AppSettings[_appSetting]);
            optionsBuilder.LogTo(message => Debug.WriteLine(message: message));
        }
    }
}
