using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.PostgreSQL.Models.Imgs;

public class ImgEventEntity : ImgEntity
{
    [ForeignKey(name: nameof(EventEntity))]
    public long EventId { get; set; }
    public EventEntity Event { get; set; }

    public ImgEventEntity() { }

    public ImgEventEntity(string url) : base(url: url)
    {
    }
}
