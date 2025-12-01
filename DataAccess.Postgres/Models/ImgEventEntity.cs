using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Postgres.Models;

public class ImgEventEntity : ImgEntity
{
    [ForeignKey(nameof(EventEntity))]
    public int EventId { get; set; }
    public EventEntity Event { get; set; }

    public ImgEventEntity() { }
    
    public ImgEventEntity(string url) 
    {
        Url = url;
    }
}
