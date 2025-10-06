using DataAccess.Postgres.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Npgsql;

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

        public ApplicationDbContext() : base()
        {
            Database.EnsureCreated();
            Database.Migrate();
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
