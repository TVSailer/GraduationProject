namespace Domain.Service.Image.BaseServiceImage;

public interface IImageSelectionService
{
    public event Action<IEnumerable<string>>? OnChangeImg;
    internal Dictionary<string, bool> Images { get; set; }
    public void ToggleImage(string key);
    public void TryAdd(IEnumerable<string> urls);
    public void Remove(Func<KeyValuePair<string, bool>, bool> operation);
    public IEnumerable<string> Get();
}
