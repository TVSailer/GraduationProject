using System.ComponentModel.DataAnnotations.Schema;
using CSharpFunctionalExtensions;

namespace DataAccess.Postgres.Models
{
    public class LessonEntity : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        [ForeignKey(name: nameof(LessonCategoryEntity))]
        public long CategoryId { get; set; }
        public LessonCategoryEntity Category { get; set; }

        public string Location { get; set; }
        public int MaxParticipants { get; set; }

        [ForeignKey(name: nameof(TeacherEntity))]
        public long TeacherId { get; set; }
        public TeacherEntity Teacher { get; set; }

        public List<DateAttendanceEntity> AttendanceDates { get; set; } = [];
        public List<LessonScheduleEntity> Schedule { get; set; } = [];
        public List<VisitorEntity> Visitors { get; set; } = [];
        public List<ReviewEntity> Reviews { get; set; } = [];
        public List<ImgLessonEntity> Imgs { get; set; } = [];
        public override string ToString() => Name;
        public bool TryRangeScheduleNow() 
            => (AttendanceDates.Count == 0 && Schedule.Any(predicate: s => s.TryRangeScheduleNow())) || 
               (AttendanceDates.All(predicate: d => DateTime.Parse(s: d.Date) != DateTime.Today) && Schedule.Any(predicate: s => s.TryRangeScheduleNow()));
    }
}

