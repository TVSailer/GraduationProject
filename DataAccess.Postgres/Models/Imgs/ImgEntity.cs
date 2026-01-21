using CSharpFunctionalExtensions;

namespace DataAccess.Postgres.Models;

public class ImgEntity : Entity { 
    public string Url { get; protected set; }

    public ImgEntity() { }

    public ImgEntity(string url)
    {
        Url = url;
    }
}
