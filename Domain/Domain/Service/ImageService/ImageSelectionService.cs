using Domain.Service.ImageService.BaseServiceImage;

namespace Domain.Service.ImageService;

public class ImageSelectionService : IImageSelectionService
{
    public event Action<IEnumerable<string>>? OnChangeImg;
    public Dictionary<string, bool> Images { get; set; } = [];

    public virtual void ToggleImage(string key)
    {
        Images[key] = !Images[key];
    }

    public virtual void TryAdd(IEnumerable<string>? urls)
    {
        if (urls is null) return;

        foreach (var url in urls)
            Images.TryAdd(url, false);
        OnChangeImg?.Invoke(Images.Select(i => i.Key));
    }

    public virtual void Remove(Func<KeyValuePair<string, bool>, bool> canRemove)
    {
        if (!Images.Any(kvp => kvp.Value)) return;

        foreach (var kvp in Images)
            if (canRemove.Invoke(kvp))
                Images.Remove(kvp.Key);

        OnChangeImg?.Invoke(Images.Select(i => i.Key));
    }

    public virtual void Binding(object obj, string nameMember)
    {
        var prop = obj.GetType().GetProperty(nameMember);
        var data = (IEnumerable<string>)prop.GetValue(obj);
        TryAdd(data);
        OnChangeImg += images => prop.SetValue(obj, images);
    }
}