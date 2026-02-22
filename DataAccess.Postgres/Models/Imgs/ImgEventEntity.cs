using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Postgres.Models;

public class ImgEventEntity : ImgEntity
{
    [ForeignKey(name: nameof(EventEntity))]
    public long EventId { get; private set; }
    public EventEntity Event { get; private set; }

    public ImgEventEntity() { }

    public ImgEventEntity(string url) : base(url: url)
    {
    }
}
