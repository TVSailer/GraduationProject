using CSharpFunctionalExtensions;
using Domain.Entitys.Compare;
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
        public List<LessonScheduleEntity> Schedule { get; set; } = [];
        public List<ReviewEntity> Reviews { get; set; } = [];
        public List<VisitorEntity> Visitors { get; set; } = [];
        public List<DateAttendanceEntity> AttendanceDates { get; set; } = [];
        public List<ImageLessonEntity> Images { get; set; } = [];

        private LessonEntity() { }

        public LessonEntity(
            string title, 
            string description, 
            string location, 
            int maxParticipants, 
            CategoryEntity category, 
            TeacherEntity teacher, 
            List<LessonScheduleEntity> schedule,
            IEnumerable<string> images)
        {
            Schedule = schedule;
            Title = title;
            Description = description;
            Location = location;
            MaxParticipants = maxParticipants;
            Category = category;
            Teacher = teacher;

            SetImages(images);
        }

        public override string ToString() => Title;

        public bool IsAddVisitor() 
            => Visitors.Count < MaxParticipants;

        public bool IsAddDateAttendance()
            => Schedule.Any(s => s.TryRangeScheduleNow()) &&
               AttendanceDates.All(d => d.ToDateTime() != DateTime.Today);

        public bool IsAddReview(VisitorEntity visitor)
            => !visitor.Reviews
                .Select(r => r.Id)
                .Any(id => Reviews
                    .Select(r => r.Id)
                    .Contains(id));

        public Result<LessonEntity> AddReview(ReviewEntity review)
        {
            if (!IsAddReview(review.Visitor)) Result.Failure<LessonEntity>("Пользователь уже имеет комментарий к уроку");
            Reviews.Add(review);

            return Result.Success(this);
        }

        public Result<LessonEntity> AddVisitor(VisitorEntity visitor)
        {
            if (!IsAddVisitor()) return Result.Failure<LessonEntity>("Превышение максимального кол-ва поситителей");

            Visitors.Add(visitor);
            Visitors.Sort(new VisitorEntityNameSurnameRelationalComparer());

            return Result.Success(this);
        }

        public Result<LessonEntity> AddDateAttendance(DateAttendanceEntity dateAttendance)
        {
            if (IsAddDateAttendance()) return Result.Failure<LessonEntity>("По расписанию сегодня нет урока");
            if (AttendanceDates.Select(d => d.Date).Contains(dateAttendance.Date)) return Result.Failure<LessonEntity>("Такая дата уже имется");

            AttendanceDates.Add(dateAttendance);
            AttendanceDates.Sort(new DateAttendanceEntityRelationalComparer());

            return Result.Success(this);
        }

        public Result<LessonEntity> RemoveVisitor(VisitorEntity visitor)
        {
            if (!Visitors.Select(v => v.Id).Contains(visitor.Id)) return Result.Failure<LessonEntity>("Такого поситителя нету");
            Visitors.Remove(visitor);
            return Result.Success(this);
        }

        public void SetImages(IEnumerable<string> images) 
            => Images = images.Select(i => new ImageLessonEntity { Url = i }).ToList();
        
        public IEnumerable<string> GetImages() 
            => Images.Select(i => i.Url);

        public double GetRating()
        {
            double rat = Reviews.Aggregate<ReviewEntity, double>(0, (current, review) => current + (int)review.Rating);
            return rat == 0 ? 0 : rat / Reviews.Count;
        }

        public IEnumerable<string> GetDateAttendance(string format = "") => AttendanceDates.Select(d => d.ToString(format));

        public IEnumerable<string[]> GetVisitorWithAttendance()
        {
            foreach (var visitor in Visitors)
            {
                var data = new List<string> { visitor.ToString() };
                data.AddRange(AttendanceDates.Select(date => date.Visitors.Select(v => v.Id).Contains(visitor.Id) ? "нб" : ""));
                yield return data.ToArray();
            }
        }

        public bool Include(string? title, string? category, string? teacherName, string? teacherSurname)
            => (string.IsNullOrEmpty(category) || category.Equals(Category.Category)) &&
                Title.StartsWith(title ?? "") &&
                Teacher.Name.StartsWith(teacherName ?? "") &&
                Teacher.Surname.StartsWith(teacherSurname ?? "");


        #region Equals

        protected bool Equals(LessonEntity other)
        {
            return base.Equals(other) && Title == other.Title;
        }

        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((LessonEntity)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (base.GetHashCode() * 397) ^ Title.GetHashCode();
            }
        }

        public static bool operator ==(LessonEntity? left, LessonEntity? right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(LessonEntity? left, LessonEntity? right)
        {
            return !Equals(left, right);
        }

        #endregion
    }
}

