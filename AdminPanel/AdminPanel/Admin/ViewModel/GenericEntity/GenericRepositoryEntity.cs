using Admin.ViewModel.Interface;
using Admin.ViewModels.Lesson;
using CSharpFunctionalExtensions;
using System.Reflection;

namespace Admin.ViewModel.GenericEntity;

public class GenericRepositoryEntity<TEntity>
    where TEntity : Entity, new()
{
    private IFieldData<TEntity>? _fieldModel;
    private PropertyMapping[]? _mappings;

    public long Id { get; private set; }
    private TEntity? _entity = new();

    // ReSharper disable once TooManyDeclarations
    private PropertyMapping[] GetOrCreateMappings()
    {
        if (_fieldModel is null) throw new Exception("используйте Initialize");

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

    public void SetEntity(TEntity entity)
    {
#pragma warning disable CA1510
#pragma warning disable CA2208
        if (entity == null) throw new ArgumentNullException();
#pragma warning restore CA2208
#pragma warning restore CA1510

        Id = (long)(entity.GetType().GetProperty("Id")?.GetValue(entity) ?? throw new Exception());
        _entity = entity;

        foreach (var mapping in _mappings ?? throw new Exception("используйте Initialize"))
        {
            var value = mapping.EntityProperty?.GetValue(entity);
            mapping.FieldDataProperty?.SetValue(_fieldModel, value);
        }
    }

    public TEntity? GetData()
    {
        foreach (var mapping in _mappings ?? throw new Exception("используйте Initialize"))
        {
            var value = mapping.FieldDataProperty?.GetValue(_fieldModel);
            if (value is 0 or null) throw new ArgumentNullException();
            mapping.EntityProperty?.SetValue(_entity, value);
        }

        return _entity;
    }
    
    public TEntity GetDataNotNull()
    {
        foreach (var mapping in _mappings ?? throw new Exception("используйте Initialize"))
        {
            var value = mapping.FieldDataProperty?.GetValue(_fieldModel);
            if (value is 0 or null) throw new ArgumentNullException();
            mapping.EntityProperty?.SetValue(_entity, value);
        }

        return _entity != null ? _entity : throw new NullReferenceException();
    } 

    // ReSharper disable once ParameterHidesMember
    public void Initialize(IFieldData<TEntity> fieldModel)
    {
        _fieldModel = fieldModel;
        _mappings = GetOrCreateMappings();
    }
}