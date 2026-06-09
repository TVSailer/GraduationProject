namespace Domain.ValidObject;

public class PathImageValidObject
{
    public readonly string? LocalPath;
    public readonly string? CloudPath;

    public PathImageValidObject(string localPath, string? cloudPath = null)
    {
        LocalPath = localPath;
        CloudPath = cloudPath;
    }
    
    public PathImageValidObject(string? cloudPath)
    {
        CloudPath = cloudPath;
    }
}