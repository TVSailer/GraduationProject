using CSharpFunctionalExtensions;
using Domain.Entitys.ImagesEntity;

namespace Domain.Entitys
{
    public class LessonEntity : Entity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public int MaxParticipants { get; set; }
        public CategoryEntity Category { get; set; }
        public TeacherEntity Teacher { get; set; }
        public ICollection<DateAttendanceEntity> AttendanceDates { get; set; } = [];
        public ICollection<LessonScheduleEntity> Schedule { get; set; } = [];
        public ICollection<VisitorEntity> Visitors { get; set; } = [];
        public ICollection<ReviewEntity> Reviews { get; set; } = [];
        public ICollection<ImageLessonEntity> Images { get; set; } = [];

        private LessonEntity() { }

        public LessonEntity(
            string title, 
            string description, 
            string location, 
            int maxParticipants, 
            CategoryEntity category, 
            TeacherEntity teacher, 
            ICollection<LessonScheduleEntity> schedule,
            ICollection<ImageLessonEntity> images)
        {
            Schedule = schedule;
            Images = images;
            Title = title;
            Description = description;
            Location = location;
            MaxParticipants = maxParticipants;
            Category = category;
            Teacher = teacher;
        }

        public override string ToString() => Title;

        public bool TryRangeScheduleNow()
            => Schedule.Any(s => s.TryRangeScheduleNow()) &&
               AttendanceDates.All(d => DateTime.Parse(s: d.Date) != DateTime.Today) && Schedule.Any(s => s.TryRangeScheduleNow());

        public double Rating()
        {
            double rat = Reviews.Aggregate<ReviewEntity, double>(0, (current, review) => current + (int)review.Rating);
            return rat == 0 ? 0 : rat / Reviews.Count;
        }

        public string CurrentParticipants() => $"{Visitors.Count}/{MaxParticipants}";

        public IEnumerable<string[]> GetVisitorWithAttendance()
        {
            foreach (var visitor in Visitors)
            {
                var data = new List<string> { visitor.ToString() };
                data.AddRange(AttendanceDates.Select(date => date.Visitors.Select(v => v.Id).Contains(visitor.Id) ? "нб" : ""));
                yield return data.ToArray();
            }
        }

        public bool IsReviewVisitor(VisitorEntity visitor)
        {
            return visitor.Reviews
                .Select(r => r.Id)
                .Any(id => Reviews
                    .Select(r => r.Id)
                    .Contains(id));
        }

        public bool Include(string? title, string? category, string? teacherName, string? teacherSurname)
        => (string.IsNullOrEmpty(category) || category.Equals(Category.Category)) &&
            Title.StartsWith(title ?? "") &&
            Teacher.Name.StartsWith(teacherName ?? "") &&
            Teacher.Surname.StartsWith(teacherSurname ?? "");
    }
}

