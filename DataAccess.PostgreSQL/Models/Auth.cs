using CSharpFunctionalExtensions;

namespace DataAccess.PostgreSQL.Models;

public class AuthEntity : Entity
{
    public string Login { get; set; }
    public string Password { get; set; }

    protected bool Equals(AuthEntity other)
    {
        return base.Equals(other) && Login == other.Login && Password == other.Password;
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
            hashCode = hashCode * 397 ^ Login.GetHashCode();
            hashCode = hashCode * 397 ^ Password.GetHashCode();
            return hashCode;
        }
    }

    public static bool operator ==(AuthEntity? left, AuthEntity? right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(AuthEntity? left, AuthEntity? right)
    {
        return !Equals(left, right);
    }
}