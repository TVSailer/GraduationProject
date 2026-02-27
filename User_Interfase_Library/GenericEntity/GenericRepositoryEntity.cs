using System.Reflection;
using User_Interface_Library.Attribute;
using User_Interface_Library.Interface;

namespace User_Interface_Library.GenericEntity;

public class GenericRepositoryEntity<TEntity>
    where TEntity : new()
{
    private readonly IDataUi<TEntity> _fieldModel;
    private readonly PropertyMapping[] _mappings;

    public long Id { get; private set; }

    public TEntity? Entity { get; private set; } = new();

    public GenericRepositoryEntity(IDataUi<TEntity> fieldModel)
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
            .Select(x => new PropertyMapping
            {
                FieldDataProperty = x.Property,
                EntityPropertyName = x.Attribute?.NamePropertyEntity,
                EntityProperty = entityType.GetProperty(x.Attribute?.NamePropertyEntity ?? throw new Exception())
            })
            .Where(m => m.EntityProperty != null)
            .ToArray();
    }

    public void SetData(TEntity entity)
    {
#pragma warning disable CA1510
#pragma warning disable CA2208
        if (entity == null) throw new ArgumentNullException();
#pragma warning restore CA2208
#pragma warning restore CA1510

        Id = (long)(entity.GetType().GetProperty("Id")?.GetValue(entity) ?? throw new Exception());
        Entity = entity;

        foreach (var mapping in _mappings)
        {
            var value = mapping.EntityProperty?.GetValue(entity);
            mapping.FieldDataProperty?.SetValue(_fieldModel, value);
        }
    }

    public TEntity? GetData()
    {
        foreach (var mapping in _mappings)
        {
            var value = mapping.FieldDataProperty?.GetValue(_fieldModel);
            if (value is 0 or null) throw new ArgumentNullException();
            mapping.EntityProperty?.SetValue(Entity, value);
        }

        return Entity;
    }
    
    public TEntity GetDataNotNull()
    {
        foreach (var mapping in _mappings)
        {
            var value = mapping.FieldDataProperty?.GetValue(_fieldModel);
            if (value is 0 or null) throw new ArgumentNullException();
            mapping.EntityProperty?.SetValue(Entity, value);
        }

        return Entity != null ? Entity : throw new NullReferenceException();
    } 
}