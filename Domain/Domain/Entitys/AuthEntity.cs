using CSharpFunctionalExtensions;
using Domain.Enum;
using Domain.ValidObject;

namespace Domain.Entitys;

public class AuthEntity : Entity
{
    public string Login { get; private set; }
    public string Password { get; private set; }
    public UserRole UserRoleId { get; private set; }
    public UserRoleEntity UserRole { get; private set; }

    private AuthEntity() { }

    public AuthEntity(LoginValidObject login, PasswordValidObject password, UserRole role)
    {
        Login = login.Login;
        Password = password.Hash;
        UserRoleId = role;
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
               UserRoleId == role &&
               Login == login && 
               (password == Password || BCrypt.Net.BCrypt.Verify(password, Password));
    }
    
    protected bool Equals(AuthEntity other)
    {
        return base.Equals(other) &&
               Login == other.Login &&
               UserRole.Equals(other.UserRole) &&
               (other.Password == Password || BCrypt.Net.BCrypt.Verify(other.Password, Password));
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((AuthEntity)obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = base.GetHashCode();
            hashCode = (hashCode * 397) ^ Login.GetHashCode();
            hashCode = (hashCode * 397) ^ Password.GetHashCode();
            hashCode = (hashCode * 397) ^ UserRole.GetHashCode();
            return hashCode;
        }
    }
}