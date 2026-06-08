using Domain.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace DataAccess.PostgreSQL
{
    public class ApplicationDbContext : DbContext
    {
        private readonly DatabaseSetting _appSetting;

        public DbSet<VisitorEntity> Visitors { get; set; }
        public DbSet<TeacherEntity> Teachers { get; set; }
        public DbSet<DateAttendanceEntity> DateAttendances { get; set; }
        public DbSet<LessonEntity> Lessons { get; set; }
        public DbSet<NewsEntity> News { get; set; }
        public DbSet<EventEntity> Events { get; set; }
        public DbSet<ReviewEntity> Reviews { get; set; }
        public DbSet<LessonScheduleEntity> LessonSchedule { get; set; }
        public DbSet<AuthEntity> Auths { get; set; }

        public ApplicationDbContext(DatabaseSetting appSetting)
        {
            _appSetting = appSetting;
            //Database.EnsureCreated();
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_appSetting.connString);
            optionsBuilder.LogTo(message => Debug.WriteLine(message: message), LogLevel.Information);
        }
    }
}
