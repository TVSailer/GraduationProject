using Domain.Entitys;
using Domain.Enum;

namespace Domain.Service.AuthService.BaseAuhtService;

public interface IAuthService
{
    public AuthEntity GetAuth(UserRole role, string login, string password);
    public AuthEntity CreateAuth(string text, UserRole role);
    public AuthEntity UpdateAuth(AuthEntity auth);
    public void MessageAuth();
    public bool IsSaveAuth(UserRole role);
    public bool IsSaveAuth(UserRole role, out AuthEntity? entity);
    public bool IsRoleAuth(UserRole role);
    public void Delete(AuthEntity authEntity);
}