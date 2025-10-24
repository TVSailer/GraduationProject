using CSharpFunctionalExtensions;

namespace DataAccess.Postgres.Models;

public class ImgNew : Entity
{
    public NewsEntity Event { get; set; }
    public ImgNew() { }

}
