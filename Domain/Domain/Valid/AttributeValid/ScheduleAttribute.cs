using System.ComponentModel.DataAnnotations;
using Domain.Entitys.ComplexType;

namespace Domain.Valid.AttributeValid;

public class ScheduleAttribute : RequiredAttribute
{
    public override bool IsValid(object? value)
    {
        if (value is not EventSchedule schedule) return false;

        if (TimeOnly.TryParse(schedule.Start, out var start) ||
            TimeOnly.TryParse(schedule.End, out var end) ||
            DateTime.TryParse(schedule.Date, out var date))
        {
            ErrorMessage = "Неверный формат даты(dd/MM/yyyy) или времени(HH:mm)";
            return false;
        }

        if (start > end)
        {
            ErrorMessage ="Время начало не может быть позже конца";
            return false;
        }

        if (DateOnly.FromDateTime(DateTime.Now).CompareTo(date) > 0)
        {
            ErrorMessage = "Дата мероприя не может быть раньше нынешней";
            return false;
        };


        if (date.Year - DateTime.Now.Year > 5)
        {
            ErrorMessage = "Мероприя не можеть быть запланировано на 5 лет вперед";
            return false;
        }

        return true;
    }
}