using Domain.ValidObject;

namespace Domain.Service.FielService.BaseFileService;

public interface IImageFileService : IDisposable
{
    public Task DeleteImageFromDisk(PathImageValidObject? path, CancellationToken cancellationToken);
    public Task<PathImageValidObject> GetFullPath(string? fileNameYandexDisk, CancellationToken cancellationToken);
    public IEnumerable<Task<PathImageValidObject>> SaveImagesToDisk(IEnumerable<PathImageValidObject>? paths, CancellationToken cancellationToken);
    public Task<PathImageValidObject> SaveImageToDick(PathImageValidObject fileName, CancellationToken cancellationToken);
    public string[]? ShowOpenFileDialog(bool multiselect = true);
    public Task ClearTempFiles();
}