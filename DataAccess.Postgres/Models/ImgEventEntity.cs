namespace DataAccess.Postgres.Models;

public class ImgEventEntity : ImgEntity
{
    public EventEntity Event { get; set; }

    public ImgEventEntity() { }
}
