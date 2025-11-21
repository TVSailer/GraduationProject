using CSharpFunctionalExtensions;

namespace DataAccess.Postgres.Models;

public abstract class ImgEntity : Entity
{
    public int Id { get; set; }
    public string Url { get; set; }
}
