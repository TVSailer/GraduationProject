using CSharpFunctionalExtensions;
using Domain.Entitys.ComplexType;
using Domain.Entitys.ImagesEntity;
using Domain.Valid.AttributeValid;

namespace Domain.Entitys;

public class EventEntity : Entity
{
    public string Title { get; set; }
    public string UrlTitleImag { get; set; }
    public string Description { get; set; }
    public string Location { get; set; }
    public string RegistrationLink { get; set; }
    public string Organizer { get;  set; }
    public EventEntitySchedule Schedule { get; set; }
    public CategoryEntity Category { get; set; }
    public ICollection<ImageEventEntity> Images { get; set; } = [];

    public EventEntity() {}

    public EventEntity(string title, string urlTitleImag, string description, string location, string registrationLink, string organizer, EventEntitySchedule schedule, CategoryEntity category, ICollection<ImageEventEntity> images)
    {
        Title = title;
        UrlTitleImag = urlTitleImag;
        Description = description;
        Location = location;
        RegistrationLink = registrationLink;
        Organizer = organizer;
        Schedule = schedule;
        Category = category;
        Images = images;
    }

    public bool Include(string? category, string? title, string? stDate, string? endDate)
    {
       return (string.IsNullOrEmpty(category) || category.Equals(Category.Category)) &&
            Title.StartsWith(title ?? "") &&
            DateTime.Parse(Schedule.Date) >= (DateTime.TryParse(stDate, out var dateS) ? dateS : DateTime.MinValue) &&
            DateTime.Parse(Schedule.Date) <= (DateTime.TryParse(endDate, out var dateE) ? dateE : DateTime.MaxValue);
    }

    public override string ToString()
        => $"{Title} {Schedule}";
}


