using CSharpFunctionalExtensions;

namespace DataAccess.Postgres.Models;

public class ImgNewEntity : ImgEntity
{
    public NewsEntity Event { get; set; }
    public ImgNewEntity() { }

}
