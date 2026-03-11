using CSharpFunctionalExtensions;
using DataAccess.PostgreSQL.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.PostgreSQL.Models
{
    public class DateAttendanceEntity : Entity
    {
        public string Date { get; set; } = DateTime.Now.ToString(format: "dd/MM/yyyy");

        [ForeignKey(name: nameof(LessonEntity))]
        public long LessonId { get; set; }
        public LessonEntity Lesson { get; set; }
        public List<VisitorEntity> Visitors { get; set; } = [];

        public string ToString(string date = "")
        {
            if (date.Equals("dd/MM"))
                return DateTime.Parse(Date).ToString("dd/MM");
            if (string.IsNullOrEmpty(date))
                return Date;

            throw new Exception($"неверный формат даты: {date}");
        }

        public DateTime ToDateTime() => DateTime.Parse(Date);

        protected bool Equals(DateAttendanceEntity other)
        {
            return base.Equals(other) && Date == other.Date;
        }

        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((DateAttendanceEntity)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (base.GetHashCode() * 397) ^ Date.GetHashCode();
            }
        }

        public static bool operator ==(DateAttendanceEntity? left, DateAttendanceEntity? right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(DateAttendanceEntity? left, DateAttendanceEntity? right)
        {
            return !Equals(left, right);
        }
    }
}

public sealed class DateAttendanceEntityRelationalComparer : IComparer<DateAttendanceEntity>
{
    public int Compare(DateAttendanceEntity? x, DateAttendanceEntity? y)
    {
        if (ReferenceEquals(x, y)) return 0;
        if (y is null) return 1;
        if (x is null) return -1;

        var dateX = x.ToDateTime();
        var dateY = y.ToDateTime();

        if (dateX == dateY) return 0;
        if (dateX > dateY) return 1;
        if (dateX < dateY) return -1;

        return 0;
    }
}
