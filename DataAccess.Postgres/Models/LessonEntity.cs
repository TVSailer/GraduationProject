using CSharpFunctionalExtensions;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Postgres.Models
{
    public class LessonEntity : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Schedule { get; set; }
        public string Location { get; set; }
        public int MaxParticipants { get; set; }

        [ForeignKey(nameof(TeacherEntity))]
        public long TeacherId { get; set; }
        public TeacherEntity Teacher { get; set; }
        public List<DateAttendanceEntity>? Dates { get; set; } = new();
        public List<VisitorEntity>? Visitors { get; set; } = new();
        public List<ReviewEntity>? Reviews { get; set; } = new();
        public List<ImgLessonEntity>? ImgsLesson { get; set; } = new();

        public LessonEntity() { }
        public LessonEntity(TeacherEntity teacher, int maxParticipants, string category, string name, string description, string schedule, string location, List<ImgLessonEntity>? imgsLesson) 
        {
            Teacher = teacher;
            Category = category;
            Name = name;
            Description = description;
            MaxParticipants = maxParticipants;
            Schedule = schedule;
            Location = location;
            ImgsLesson = imgsLesson;
        }

        public override string ToString()
            => Name;
    }
}
