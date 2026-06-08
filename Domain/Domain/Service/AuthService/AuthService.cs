using Domain.Entitys;
using Domain.Enum;
using Domain.Repository;
using Domain.Service.AuthService.BaseAuhtService;
using Domain.Service.FielService.BaseFileService;
using Domain.Service.MessageService.BaseMessageService;
using Domain.ValidObject;
using System.Diagnostics;
using System.Threading;

namespace Domain.Service.AuthService;

public class AuthService(
    IRepository<AuthEntity> repositoryA, 
    IMessageService messageService, 
    IAuthFileService authFileService) : IAuthService
{
    private LoginValidObject _login;
    private PasswordValidObject _password;

    public AuthEntity GetAuth(UserRole role, string login, string password)
        => repositoryA
            .Get()
            .ToArray()
            .Single(a => a.Equals(login, password, role));

    public AuthEntity CreateAuth(string text, UserRole role)
    {
        _login = new LoginValidObject(text);
        _password = new PasswordValidObject(
            repositoryA
                .Get()
                .Select(a => a.Password)
                .ToArray());

        return repositoryA.Add(new AuthEntity(_login, _password, role));
    }

    public AuthEntity UpdateAuth(AuthEntity auth)
    {
        _login = new LoginValidObject(auth);
        _password = new PasswordValidObject(
            repositoryA
                .Get()
                .Select(a => a.Password)
                .ToArray());

        auth.UpdatePassword(_password);
        repositoryA.Update(auth);
        return auth;
    }

    public bool IsSaveAuth(UserRole role)
    {
        if (!authFileService.Exists()) return false;

        var auth = authFileService.ReadAuth();

        return repositoryA
            .Get()
            .AsEnumerable()
            .Any(v => v.Equals(auth.login, auth.password, role));
    }

    public bool IsSaveAuth(UserRole role, out AuthEntity? entity)
    {
        entity = null;
        if (!authFileService.Exists()) return false;

        var auth = authFileService.ReadAuth();

        entity = repositoryA.Get().AsEnumerable().SingleOrDefault(a => a.Equals(auth.login, auth.password, role));

        return entity is not null;
    }

    public bool IsRoleAuth(UserRole role)
    {
        var maxRetries = 5;
        for (int i = 0; i < maxRetries; i++)
        {
            try
            {
                return repositoryA
                    .Get()
                    .AsEnumerable()
                    .Select(a => a.UserRoleId).Contains(role);
            }
            catch (System.Exception ex) when (i < maxRetries - 1)
            {
                Debug.WriteLine($"✗ Попытка найти роль {i + 1}/{maxRetries}: {ex.Message}");
            }
        }

        return false;
    }

    public void MessageAuth() => 
        messageService.Message(
        $"Логин: {_login.Login}" +
        $"\n" +
        $"Пароль: {_password.Password}", TypeMessage.Info);

    public void Delete(AuthEntity authEntity)
    {
        repositoryA.Delete(authEntity.Id);
    }
}