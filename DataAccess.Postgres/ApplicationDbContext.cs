using System.Diagnostics;
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
