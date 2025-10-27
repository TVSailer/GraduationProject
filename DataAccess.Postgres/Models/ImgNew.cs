using CSharpFunctionalExtensions;

namespace DataAccess.Postgres.Models;

public class ImgNew : Img
{
    public NewsEntity Event { get; set; }
    public ImgNew() { }

}
