using CSharpFunctionalExtensions;
using Domain.Entitys.ComplexType;
using Domain.Entitys.ImagesEntity;
using Domain.ValidObject;

namespace Domain.Entitys;

public class EventEntity : Entity
{
    public string Title { get; private set; }
    public string UrlTitleImag { get; private set; }
    public string Description { get; private set; }
    public string Location { get; private set; }
    public string RegistrationLink { get; private set; }
    public string Organizer { get;  private set; }
    public EventEntitySchedule Schedule { get; private set; }
    public CategoryEntity Category { get; private set; }
    public ICollection<ImageEventEntity> Images { get; private set; } = [];

    private EventEntity() {}

    public EventEntity(
        TitleValidObject title, 
        ImageValidObject urlTitleImag, 
        DescriptionValidObject description, 
        LocationValidObject location, 
        HttpLinkValidObject registrationLink, 
        OrganizerValidObject organizer, 
        EventEntitySchedule schedule, 
        CategoryEntity category, 
        IEnumerable<string> images)
    {
        Title = title.Text;
        UrlTitleImag = urlTitleImag.Text;
        Description = description.Text;
        Location = location.Text;
        RegistrationLink = registrationLink.Text;
        Organizer = organizer.Text;
        Schedule = schedule;
        Category = category;
        UpdateImages(images);
    }

    public EventEntity UpdateTitle(TitleValidObject title)
    {
        Title = title.Text;
        return this;
    }
    
    public EventEntity UpdateSchedule(EventEntitySchedule schedule)
    {
        Schedule = schedule;
        return this;
    }
    
    public EventEntity UpdateCategory(CategoryEntity category)
    {
        Category = category;
        return this;
    }
    
    public EventEntity UpdateTitleImage(ImageValidObject image)
    {
        UrlTitleImag = image.Text;
        return this;
    }
    
    public EventEntity UpdateDescription(DescriptionValidObject description)
    {
        Description = description.Text;
        return this;
    }
    
    public EventEntity UpdateLocation(LocationValidObject location)
    {
        Description = location.Text;
        return this;
    }
    
    public EventEntity UpdateHttpLink(HttpLinkValidObject http)
    {
        RegistrationLink = http.Text;
        return this;
    }
    
    public EventEntity UpdateOrganizer(OrganizerValidObject organizer)
    {
        Organizer = organizer.Text;
        return this;
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

    public void UpdateImages(IEnumerable<string> images)
        => Images = images.Select(i => new ImageEventEntity { Url = i }).ToList();

    public IEnumerable<string> GetImages()
        => Images.Select(i => i.Url);
}


