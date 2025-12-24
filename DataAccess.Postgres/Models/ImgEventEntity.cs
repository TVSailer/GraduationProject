using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Postgres.Models;

public class ImgEventEntity : ImgEntity
{
    [ForeignKey(nameof(EventEntity))]
    public int EventId { get; private set; }
    public EventEntity Event { get; private set; }

    public ImgEventEntity() { }

    public ImgEventEntity(string urlImg)
    {
        Url = urlImg;
    }
}
