using CSharpFunctionalExtensions;
using Domain.Enum;
using Domain.Extension;

namespace Domain.Entitys;

public class UserRoleEntity : Entity
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    private UserRoleEntity() {}

    public UserRoleEntity(UserRole role)
    {
        Id = (int)role;
        Name = role.ToString();
        Description = role.ToDescriptionString();
    }

    protected bool Equals(UserRoleEntity other)
    {
        return base.Equals(other) && Name == other.Name;
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((UserRoleEntity)obj);
    }
}