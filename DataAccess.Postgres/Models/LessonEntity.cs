using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Postgres.Models
{
    public class LessonEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Schedule { get; set; }
        public string Location { get; set; }
        public int MaxParticipants { get; set; }
        public int CurrentParticipants { get; set; }
        public double Rating { get; set; }
        public int ReviewCount { get; set; }

        [ForeignKey(nameof(TeacherEntity))]
        public int TeacherId { get; set; }
        public TeacherEntity Teacher { get; set; }
        public List<DateAttendanceEntity>? Dates { get; set; } = new();
        public List<VisitorEntity>? Visitors { get; set; } = new();
        public List<ReviewEntity>? Reviews { get; set; } = new();
        public List<ImgLessonEntity>? ImgsLesson { get; set; } = new();

        public LessonEntity() { }
        public LessonEntity(TeacherEntity teacher, int maxPa, int curPa, double ret, int revCo, string cate, string name) 
        {
            Teacher = teacher;
            MaxParticipants = maxPa;
            CurrentParticipants = curPa;
            Rating = ret;
            ReviewCount = revCo;
            Category = cate;
            Name = name;
        }

        public override string ToString()
            => Name;
    }
}
