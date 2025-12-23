using System.ComponentModel.DataAnnotations;
using static DataAccess.Postgres.Models.DateAttendanceEntity;

namespace DataAccess
{
    public class DateAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value is DateForValid date)
            {
                if (IsValidDate(date))
                    return true;
            }

            return false;
        }

        private bool IsValidDate(DateForValid? date)
        {
            if (DateTime.TryParseExact(date.Date, "dd.MM.yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime dat))
            {
                //if (birthDate > DateTime.Today)
                //    return false;

                //if (birthDate.Year < DateTime.Today.Year - 150)
                //    return false;

                if (date.DbContext.Lessons.FirstOrDefault(l => l.Id == date.LessonId)
                    .Dates.FirstOrDefault(d => d.Date == date.Date) != null) 
                    return false;

                return true;
            }
            return false;
        }
    }
}
