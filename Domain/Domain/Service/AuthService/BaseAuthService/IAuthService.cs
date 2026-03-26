namespace Domain.Service.AuthService.BaseAuthService;

public interface IAuthService
{
    public string GenerateAuthLogin(string text);
    public string GenerateAuthPassword(string[] hash, out string password);
}