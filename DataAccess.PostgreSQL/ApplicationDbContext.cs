using System.Diagnostics;
using DataAccess.Postgres.Models;
using DataAccess.Postgres.Models.Imgs;
using DataAccess.PostgreSQL;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Postgres
{
    public class ApplicationDbContext : DbContext
    {
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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(LocalResource.ConectionString);
            optionsBuilder.LogTo(message => Debug.WriteLine(message: message));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
