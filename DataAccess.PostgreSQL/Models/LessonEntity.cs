using CSharpFunctionalExtensions;
using DataAccess.PostgreSQL.Models.Imgs;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.PostgreSQL.Models
{
    public class LessonEntity : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public int MaxParticipants { get; set; }

        [ForeignKey(nameof(CategoryEntity))]
        public long CategoryId { get; set; }
        public CategoryEntity Category { get; set; }

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
            => Schedule.Any(s => s.TryRangeScheduleNow()) &&
               AttendanceDates.All(d => DateTime.Parse(s: d.Date) != DateTime.Today) && Schedule.Any(s => s.TryRangeScheduleNow());

        public double Rating()
        {
            double rat = 0;
            Reviews.ForEach(r => rat += r.Rating);
            return rat == 0 ? 0 : rat / Reviews.Count;
        }

        public string CurrentParticipants() => $"{Visitors.Count}/{MaxParticipants}";
    }
}

