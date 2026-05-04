using Domain.Entitys;
using Domain.Enum;
using Domain.Repository;
using Domain.Service.AuthService.BaseAuhtService;
using Domain.Service.FielService.BaseFileService;
using Domain.Service.MessageService.BaseMessageService;
using Domain.ValidObject;

namespace Domain.Service.AuthService;

public class AuthService(
    IRepository<AuthEntity> repositoryA, 
    IMessageService messageService, 
    IAuthFileService authFileService) : IAuthService
{
    private LoginValidObject _login;
    private PasswordValidObject _password;

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

        entity = repositoryA
            .Get()
            .AsEnumerable()
            .Single(v => v.Equals(auth.login, auth.password, role));

        return true;
    }

    public bool IsRoleAuth(UserRole role) 
        => repositoryA
            .Get()
            .AsEnumerable()
            .Select(a => a.UserRoleId).Contains(role);

    public void MessageAuth() => 
        messageService.Message(
        $"Логин: {_login.Login}" +
        $"\n" +
        $"Пароль: {_password.Password}", TypeMessage.Info);
}