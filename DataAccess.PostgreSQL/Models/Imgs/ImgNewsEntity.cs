using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.PostgreSQL.Models.Imgs;

public class ImgNewsEntity : ImgEntity
{
    [ForeignKey(name: nameof(NewsEntity))]
    public long NewsId { get; set; }
    public NewsEntity News { get; set; }

    public ImgNewsEntity() { }
    public ImgNewsEntity(string url) : base(url: url)
    {
    }
}

