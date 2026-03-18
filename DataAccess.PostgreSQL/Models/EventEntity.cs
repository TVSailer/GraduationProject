using CSharpFunctionalExtensions;
using DataAccess.PostgreSQL.ComplexType;
using DataAccess.PostgreSQL.Models.Imgs;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.PostgreSQL.Models;

public class EventEntity : Entity
{
    public string Title { get; set; }
    public string UrlTitleImag { get; set; }
    public string Description { get; set; }
    public EventScheduleEntity Schedule { get; set; }
    public string Location { get; set; }


    [ForeignKey(nameof(CategoryEntity))]
    public long CategoryId { get; set; }
    public CategoryEntity Category { get; set; }

    public string RegistrationLink { get; set; }
    public string Organizer { get;  set; }
    public List<ImgEventEntity> Imgs { get; set; } = [];

    public override string ToString()
        => $"Мероприятие: {Title} {Schedule}";


}
