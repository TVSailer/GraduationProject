using DataAccess.Postgres.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace DataAccess.Postgres
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<VisitorEntity> Visitors { get; set; }
        public DbSet<TeacherEntity> Teachers { get; set; }
        public DbSet<DateAttendanceEntity> DateAttendances { get; set; }
        public DbSet<LessonEntity> Lessons { get; set; }
        public DbSet<NewsEntity> News { get; set; }
        public DbSet<EventEntity> Event { get; set; }
        public DbSet<ReviewEntity> Review { get; set; }
        public DbSet<ImgLessonEntity> ImgLesson { get; set; }
        public DbSet<ImgEventEntity> ImgEvent { get; set; }
        public DbSet<ImgNewsEntity> ImgNews { get; set; }
        public DbSet<LessonScheduleEntity> LessonSchedule { get; set; }
        public DbSet<NewsCategoryEntity> NewsCategory { get; set; }
        public DbSet<LessonCategoryEntity> LessonCategory { get; set; }
        public DbSet<EventCategoryEntity> EventCategory { get; set; }

        public ApplicationDbContext() : base()
        {
            //Database.EnsureCreated();
            //Database.Migrate();
        }

        protected async override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //var host = "rc1a-0n5rrnadr54pkbh1.mdb.yandexcloud.net";
            //var port = "6432";
            //var db = "Cursovik";
            //var username = "user1";
            //var password = "Sailer22_8";
            //var connString = $"host={host};port={port};database={db};username={username};password={password};";
            optionsBuilder.ConfigureWarnings(w => w.Ignore(RelationalEventId.PendingModelChangesWarning));
            optionsBuilder.UseNpgsql(@"host=localhost;port=5432;database=db;username=postgres;password=Sailer22_8");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
        }
    }
}
