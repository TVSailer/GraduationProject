using System.ComponentModel.DataAnnotations.Schema;
using CSharpFunctionalExtensions;
using Domain.Enum;
using Domain.Extension;
using Domain.ValidObject;

namespace Domain.Entitys;

public class AuthEntity : Entity
{
    public string Login { get; private set; }
    public string Password { get; private set; }

    [ForeignKey(nameof(UserRoleEntity))]
    public long UserRoleId { get; private set; }
    public UserRoleEntity UserRole { get; private set; }

    private AuthEntity() { }

    public AuthEntity(LoginValidObject login, PasswordValidObject password, UserRole role)
    {
        Login = login.Login;
        Password = password.Hash;
        UserRoleId = (int)role;
    }
    
    public AuthEntity UpdateLogin(LoginValidObject login)
    {
        Login = login.Login;
        return this;
    }
    
    public AuthEntity UpdatePassword(PasswordValidObject password)
    {
        if (BCrypt.Net.BCrypt.Verify(password.Password, Password)) return this;
        Password = password.Hash;
        return this;
    }

    public bool Equals(string? login, string? password, UserRole role)
    {
        return login is not null && 
               password is not null && 
               UserRole.Name == role.ToString() &&
               Login == login && 
               (password == Password || BCrypt.Net.BCrypt.Verify(password, Password));
    }
    
    public bool Equals(string? login, string? password, UserRoleEntity role)
    {
        return login is not null && 
               password is not null && 
               UserRole.Name == role.Name &&
               Login == login && 
               (password == Password || BCrypt.Net.BCrypt.Verify(password, Password));
    }
    
    public bool Equals(string? login, string? password, string role)
    {
        return login is not null && 
               password is not null && 
               UserRole.Name == role &&
               Login == login && 
               (password == Password || BCrypt.Net.BCrypt.Verify(password, Password));
    }
}