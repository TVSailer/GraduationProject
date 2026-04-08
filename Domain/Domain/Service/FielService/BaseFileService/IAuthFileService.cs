using Domain.Entitys;

namespace Domain.Service.FielService.BaseFileService;

public interface IAuthFileService
{
    public void WriteAuth(AuthEntity auth);
    public (string login, string password) ReadAuth();
    public bool Exists();
}