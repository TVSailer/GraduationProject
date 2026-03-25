namespace Domain.Service.SharedService.BaseSharedService;

public interface ISharedService
{
    public void SetData(object obj);
    public object GetData();
}