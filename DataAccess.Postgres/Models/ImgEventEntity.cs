using CSharpFunctionalExtensions;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Postgres.Models;

public class ImgEventEntity : Entity
{
    [ForeignKey(nameof(EventEntity))]
    public long EventId { get; private set; }
    public EventEntity Event { get; private set; }
    public string Url { get; protected set; }


    public ImgEventEntity() { }

    public ImgEventEntity(string url)
    {
        Url = url;
    }
}
