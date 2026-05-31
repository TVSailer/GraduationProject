namespace General.Service.File;

public class PathImageValidObject(string localPath, string? cloudPath = null)
{
    public string LocalPath { get; } = localPath;
    public string? CloudPath { get; } = cloudPath;
}