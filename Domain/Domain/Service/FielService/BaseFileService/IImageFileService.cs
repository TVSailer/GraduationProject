namespace Domain.Service.FielService.BaseFileService;

public interface IImageFileService
{
    public void DeleteImageFromDisk(string? path);
    public string GetFullPath(string? fileName);
    public IEnumerable<string> SaveImagesToDisk(IEnumerable<string>? paths);
    public string SaveImageToDick(string? fileName);
    public string[]? ShowOpenFileDialog(bool multiselect = true);
    public bool IsFileInAppData(string? path);
}