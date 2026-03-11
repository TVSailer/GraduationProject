using System.Reflection;
using UserInterface.Attribute;
using UserInterface.Interface;

namespace UserInterface.GenericEntity;

public class MementoEntity<TEntity>
    where TEntity : new()
{
    private readonly IDataUi<TEntity> _fieldModel;
    private readonly PropertyMapping[] _mappings;

    public long Id { get; private set; }
    public TEntity? Entity { get; private set; }

    public MementoEntity(IDataUi<TEntity> fieldModel)
    {
        _fieldModel = fieldModel;
        _mappings = GetOrCreateMappings();
    }


    // ReSharper disable once TooManyDeclarations
    private PropertyMapping[] GetOrCreateMappings()
    {
        var viewModelType = _fieldModel.GetType();
        var entityType = typeof(TEntity);

        return viewModelType.GetProperties(BindingFlags.Public | BindingFlags.Instance)
            .Select(p => new
            {
                Property = p,
                Attribute = p.GetCustomAttribute<LinkingEntityAttribute>()
            })
            .Where(x => x.Attribute != null)
            .Select(x => new PropertyMapping(
                x.Property, 
                x.Attribute?.NamePropertyEntity, 
                entityType.GetProperty(x.Attribute?.NamePropertyEntity ?? throw new Exception())))
            .Where(m => m.EntityProperty != null)
            .ToArray();
    }

    public void SetEntity(long id, TEntity? entity)
    {
        if (entity == null) throw new ArgumentNullException();

        Id = id;
        Entity = entity;

        foreach (var mapping in _mappings)
        {
            var value = mapping.EntityProperty?.GetValue(entity);
            mapping.FieldDataProperty?.SetValue(_fieldModel, value);
        }
    }
    
    public TEntity GetEntityNotNull()
    {
        Entity ??= new TEntity();
        foreach (var mapping in _mappings)
        {
            var value = mapping.FieldDataProperty?.GetValue(_fieldModel);
            if (value is 0 or null) throw new ArgumentNullException();
            mapping.EntityProperty?.SetValue(Entity, value);
        }

        return Entity;
    } 
}