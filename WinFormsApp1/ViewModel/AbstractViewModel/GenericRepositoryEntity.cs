using System.Reflection;
using Admin.ViewModel.Interface;
using Admin.ViewModels.Lesson;
using CSharpFunctionalExtensions;

public class GenericRepositoryEntity<TEntity>
    where TEntity : Entity, new()
{
    private IFieldData<TEntity> fieldModel;
    private PropertyMapping[] mappings;

    public long Id { get; private set; }
    private TEntity Entity = new();

    private PropertyMapping[] GetOrCreateMappings() 
    {
        var viewModelType = fieldModel.GetType();
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
                    ViewModelProperty = x.Property,
                    EntityPropertyName = x.Attribute?.NamePropertyEntity,
                    EntityProperty = entityType.GetProperty(x.Attribute.NamePropertyEntity)
                })
                .Where(m => m.EntityProperty != null)
                .ToArray();
    }

    public void SetEntity(TEntity entity)
    {
        if (entity == null) throw new ArgumentNullException();

        Id = (long)entity.GetType().GetProperty("Id").GetValue(entity);
        Entity = entity;

        foreach (var mapping in mappings)
        {
            var value = mapping.EntityProperty?.GetValue(entity);
            mapping.ViewModelProperty.SetValue(fieldModel, value);
        }
    }

    public TEntity GetData()
    {
        foreach (var mapping in mappings)
        {
            var value = mapping.ViewModelProperty.GetValue(fieldModel);
            if (value is 0 or null) throw new ArgumentNullException();
            mapping.EntityProperty?.SetValue(Entity, value);
        }

        return Entity;
    } 

    public void Initialize(IFieldData<TEntity> fieldModel)
    {
        this.fieldModel = fieldModel;
        mappings = GetOrCreateMappings();
    }
}