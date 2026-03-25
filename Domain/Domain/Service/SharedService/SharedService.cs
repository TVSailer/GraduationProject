using Domain.Service.SharedService.BaseSharedService;

namespace Domain.Service.SharedService;

public class SharedService : ISharedService
{
    private object? _data;

    public void SetData(object obj) => _data = obj;
    public object GetData()
    {
        if (_data is null) throw new ArgumentNullException();
        var data = _data;
        _data = null;
        return data;
    }
}