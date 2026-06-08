using CSharpFunctionalExtensions;
using Domain.Entitys.Compare;
using Domain.Entitys.ImagesEntity;
using Domain.Exception;
using Domain.ValidObject;

namespace Domain.Entitys
{
    public class LessonEntity : Entity
    {
        public string Title { get; private set; }
        public string Description { get; private set; }
        public string Location { get; private set; }
        public int MaxParticipants { get; private set; }
        public CategoryEntity Category { get; private set; }
        public TeacherEntity Teacher { get; private set; }
        public List<LessonScheduleEntity> Schedule { get; private set; } = [];
        public List<ReviewEntity> Reviews { get; private set; } = [];
        public List<VisitorEntity> Visitors { get; private set; } = [];
        public List<DateAttendanceEntity> AttendanceDates { get; private set; } = [];
        public List<ImageLessonEntity> Images { get; private set; } = [];

        private LessonEntity() { }

        public LessonEntity(
            TitleValidObject title, 
            DescriptionValidObject description, 
            LocationValidObject location, 
            MaximazeParticipantValidObject maxParticipants, 
            CategoryEntity category, 
            TeacherEntity teacher, 
            List<LessonScheduleEntity> schedule,
            IEnumerable<string> images)
        {
            Schedule = schedule;
            Title = title.Text;
            Description = description.Text;
            Location = location.Text;
            MaxParticipants = maxParticipants.Value;
            Category = category;
            Teacher = teacher;

            UpdateImages(images);
        }

        public LessonEntity UpdateTeacher(TeacherEntity teacher)
        {
            Teacher = teacher;
            return this;
        }

        public LessonEntity UpdateSchedule(List<LessonScheduleEntity> schedule)
        {
            Schedule = schedule;
            return this;
        }

        public LessonEntity UpdateTitle(TitleValidObject title)
        {
            Title = title.Text;
            return this;
        }
        
        public LessonEntity UpdateDescription(DescriptionValidObject description)
        {
            Description = description.Text;
            return this;
        }
        
        public LessonEntity UpdateLocation(LocationValidObject location)
        {
            Location = location.Text;
            return this;
        }
        
        public LessonEntity UpdateMaximazeParticipant(MaximazeParticipantValidObject maxPart)
        {
            MaxParticipants = maxPart.Value;
            return this;
        }
        
        public LessonEntity UpdateCategory(CategoryEntity category)
        {
            Category = category;
            return this;
        }


        public override string ToString() => Title;

        public bool IsAddVisitor() 
            => Visitors.Count < MaxParticipants;

        public bool IsAddDateAttendance()
            => Schedule.Any(s => s.TryRangeScheduleNow()) &&
               AttendanceDates.All(d => d.ToDateTime() != DateTime.Today);

        public bool IsUpdateDateAttendance() =>
            Schedule.Any(s => s.TryRangeScheduleNow()) &&
            AttendanceDates.Any(d => d.Date == DateTime.Now.ToString("dd.MM.yyyy"));

        public bool IsAddReview(VisitorEntity visitor)
            => !visitor.Reviews
                .Select(r => r.Id)
                .Any(id => Reviews
                    .Select(r => r.Id)
                    .Contains(id));

        public LessonEntity AddReview(ReviewEntity review)
        {
            if (!IsAddReview(review.Visitor)) throw new EntityException("Пользователь уже имеет комментарий к уроку");
            Reviews.Add(review);

            return this;
        }

        public LessonEntity AddVisitor(VisitorEntity visitor)
        {
            if (!IsAddVisitor()) throw new EntityException("Превышение максимального кол-ва поситителей");

            Visitors.Add(visitor);
            Visitors.Sort(new VisitorEntityNameSurnameRelationalComparer());

            return this;
        }

        public LessonEntity AddDateAttendance(DateAttendanceEntity dateAttendance)
        {
            if (IsAddDateAttendance()) throw new EntityException("По расписанию сегодня нет урока");
            if (AttendanceDates.Select(d => d.Date).Contains(dateAttendance.Date)) throw new EntityException("Такая дата уже имется");

            AttendanceDates.Add(dateAttendance);
            AttendanceDates.Sort(new DateAttendanceEntityRelationalComparer());

            return this;
        }

        public LessonEntity RemoveVisitor(VisitorEntity visitor)
        {
            if (!Visitors.Select(v => v.Id).Contains(visitor.Id)) throw new EntityException("Такого поситителя нету");
            Visitors.Remove(visitor);
            return this;
        }

        public void UpdateImages(IEnumerable<string> images) 
            => Images = images.Select(i => new ImageLessonEntity(new ImageValidObject(i))).ToList();
        
        public IEnumerable<string> GetImages() 
            => Images.Select(i => i.Url);

        public double GetRating()
        {
            double rat = Reviews.Aggregate<ReviewEntity, double>(0, (current, review) => current + (int)review.RatingId);
            return rat == 0 ? 0 : rat / Reviews.Count;
        }

        public bool Include(string? title, string? category, string? teacherName, string? teacherSurname)
            => (string.IsNullOrEmpty(category) || category.Equals(Category.Category)) &&
                Title.StartsWith(title ?? "") &&
                Teacher.Name.StartsWith(teacherName ?? "") &&
                Teacher.Surname.StartsWith(teacherSurname ?? "");
    }
}

