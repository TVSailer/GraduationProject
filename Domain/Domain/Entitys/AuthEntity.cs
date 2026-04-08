using CSharpFunctionalExtensions;
using Domain.ValidObject;

namespace Domain.Entitys;

public class AuthEntity : Entity
{
    public string Login { get; set; }
    public string Password { get; set; }

    private AuthEntity() { }

    //Todo: delete
    public AuthEntity(string login, string password)
    {
        Login = login;
        Password = password;
    }
    
    public AuthEntity(LoginValidObject login, PasswordValidObject password)
    {
        Login = login.Login;
        Password = password.Hash;
    }
    
    public AuthEntity UpdateLogin(LoginValidObject login)
    {
        Login = login.Login;
        return this;
    }
    
    public AuthEntity UpdatePassword(PasswordValidObject password)
    {
        if (BCrypt.Net.BCrypt.Verify(Password, password.Password)) return this;
        Password = password.Password;
        return this;
    }

    protected bool Equals(AuthEntity other)
    {
        return base.Equals(other) && Login == other.Login && BCrypt.Net.BCrypt.Verify(Password, other.Password);
    }
    
    public bool Equals(string? login, string? password)
    {
        return login is not null && 
               password is not null && 
               Login == login && 
               password == Password || 
               BCrypt.Net.BCrypt.Verify(password, Password);
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((AuthEntity)obj);
    }
}