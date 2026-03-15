using DataAccess.PostgreSQL.Models;
using DataAccess.PostgreSQL.Models.Imgs;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using System.Diagnostics;

namespace DataAccess.PostgreSQL
{
    public class ApplicationDbContext : DbContext
    {
        private const string ExeConfigFilename = "DataAccess.PostgreSQL.dll.config";
        private readonly Configuration _config;

        public DbSet<VisitorEntity> Visitors { get; set; }
        public DbSet<TeacherEntity> Teachers { get; set; }
        public DbSet<DateAttendanceEntity> DateAttendances { get; set; }
        public DbSet<LessonEntity> Lessons { get; set; }
        public DbSet<NewsEntity> News { get; set; }
        public DbSet<EventEntity> Events { get; set; }
        public DbSet<ReviewEntity> Reviews { get; set; }
        public DbSet<LessonScheduleEntity> LessonSchedule { get; set; }
        public DbSet<CategoryEntity> Category { get; set; }
        public DbSet<ImgLessonEntity> ImagesLesson { get; set; }
        public DbSet<ImgNewsEntity> ImagesNews { get; set; }
        public DbSet<ImgEventEntity> ImagesEvent { get; set; }
        public DbSet<AuthEntity> Auths { get; set; }

        public ApplicationDbContext()
        {
            //var exe = new ExeConfigurationFileMap { ExeConfigFilename = ExeConfigFilename };
            //_config = ConfigurationManager.OpenMappedExeConfiguration(exe, ConfigurationUserLevel.None);

            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("host=localhost;port=5432;database=db;username=postgres;password=Sailer22_8");//_config.AppSettings.Settings["DBConnectionString"].Value);
            optionsBuilder.LogTo(message => Debug.WriteLine(message: message));
        }
    }
}
