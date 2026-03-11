using CSharpFunctionalExtensions;

namespace DataAccess.PostgreSQL.Models.Imgs;

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
