using CSharpFunctionalExtensions;

namespace DataAccess.Postgres.Models;

public class ImgEntity : Entity { 
    public string Url { get; set; }

    public ImgEntity() { }

    public ImgEntity(string url)
    {
        Url = url;
    }

    public override string ToString()
    {
        return Url;
    }
}
