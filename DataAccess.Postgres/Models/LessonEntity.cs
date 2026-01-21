using CSharpFunctionalExtensions;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Postgres.Models
{
    public class LessonEntity : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        [ForeignKey(nameof(LessonCategoryEntity))]
        public long CategoryId { get; set; }
        public LessonCategoryEntity Category { get; set; }

        public string Location { get; set; }
        public int MaxParticipants { get; set; }

        [ForeignKey(nameof(TeacherEntity))]
        public long TeacherId { get; set; }
        public TeacherEntity Teacher { get; set; }

        public List<DateAttendanceEntity>? AttendanceDates { get; set; } = new();
        public List<ScheduleEntity>? Schedule { get; set; } = new();
        public List<VisitorEntity>? Visitors { get; set; } = new();
        public List<ReviewEntity>? Reviews { get; set; } = new();
        public List<ImgLessonEntity>? Imgs { get; set; } = new();

        public LessonEntity() { }

        public LessonEntity(
            TeacherEntity teacher, 
            int maxParticipants,
            LessonCategoryEntity category, 
            string name, 
            string description, 
            List<ScheduleEntity> schedule, 
            string location, 
            List<ImgLessonEntity>? imgsLesson) 
        {
            Teacher = teacher;
            Category = category;
            Name = name;
            Description = description;
            MaxParticipants = maxParticipants;
            Schedule = schedule;
            Location = location;
            Imgs = imgsLesson;
        }

        public override string ToString()
            => Name;
    }
}

