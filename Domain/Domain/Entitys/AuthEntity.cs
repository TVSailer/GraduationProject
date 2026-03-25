using CSharpFunctionalExtensions;

namespace Domain.Entitys;

public class AuthEntity : Entity
{
    public string Login { get; set; }
    public string Password { get; set; }

    protected bool Equals(AuthEntity other)
    {
        return base.Equals(other) && Login == other.Login && BCrypt.Net.BCrypt.Verify(Password, other.Password);
    }
    
    public bool Equals(string? login, string? password)
    {
        return login is not null && 
               password is not null && 
               Login == login && 
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