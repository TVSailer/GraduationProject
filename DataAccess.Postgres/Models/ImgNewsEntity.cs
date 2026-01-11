using CSharpFunctionalExtensions;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Postgres.Models;

public class ImgNewsEntity : ImgEntity
{
    [ForeignKey(nameof(NewsEntity))]
    public long NewsId { get; private set; }
    public NewsEntity News { get; private set; }

    public ImgNewsEntity() { }
    public ImgNewsEntity(string url)
    {
        Url = url;
    }
}

