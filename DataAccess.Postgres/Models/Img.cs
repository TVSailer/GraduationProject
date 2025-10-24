using CSharpFunctionalExtensions;

namespace DataAccess.Postgres.Models;

public abstract class Img : Entity
{
    public int Id { get; set; }
    public string Url { get; set; }
}
