namespace Domain.Service.ImageService.BaseServiceImage;

public interface IImageSelectionService
{
    public void ToggleImage(string key);
    public void TryAdd(IEnumerable<string> urls);
    public void Remove(Func<KeyValuePair<string, bool>, bool> operation);
    public void Binding(object obj, string nameMember);
}
