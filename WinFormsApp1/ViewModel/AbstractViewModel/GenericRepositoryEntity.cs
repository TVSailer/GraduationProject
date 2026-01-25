using System.Collections.Concurrent;
using System.ComponentModel;
using System.Reflection;
using Admin.ViewModels.Lesson;
using CSharpFunctionalExtensions;
using Ninject;

public class GenericRepositoryEntity<TEntity>
    where TEntity : Entity, new()
{
    private IViewModele<TEntity> viewModel;
    private PropertyMapping[] mappings;

    public long Id { get; private set; }
    public TEntity Entity => GetEntity(); 

    private PropertyMapping[] GetOrCreateMappings() 
    {
        var viewModelType = viewModel.GetType();
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

    // private void InitializeViewModel()
    // {
    //     foreach (var mapping in mappings)
    //         if (viewModel is PropertyChange propertyChange)
    //             propertyChange.PropertyChanged += (sender, args) =>
    //             {
    //                 var firstOrDefault = mappings.FirstOrDefault(m => m.ViewModelProperty.Name == args.PropertyName);
    //                 if (firstOrDefault != null)
    //                     UpdateEntityFromViewModel(firstOrDefault);
    //             };
    // }

    public void SetEntity(TEntity entity)
    {
        if (entity == null) throw new ArgumentNullException();

        Id = (long)entity.GetType().GetProperty("Id").GetValue(entity);

        foreach (var mapping in mappings)
        {
            var value = mapping.EntityProperty?.GetValue(entity);
            mapping.ViewModelProperty.SetValue(viewModel, value);
        }
    }

    public TEntity GetEntity()
    {
        var entity = new TEntity();
        foreach (var mapping in mappings)
        {
            var value = mapping.ViewModelProperty.GetValue(viewModel);
            if (value is 0 or null) throw new ArgumentNullException();
            mapping.EntityProperty?.SetValue(entity, value);
        }

        return entity;
    } 

    // private void UpdateEntityFromViewModel(PropertyMapping mapping)
    // {
    //     var value = mapping.ViewModelProperty.GetValue(viewModel);
    //
    //     if (value is 0)
    //         return;
    //     if (value is null) return;
    //
    //     mapping.EntityProperty?.SetValue(Entity, value);
    // }
    //
    // private void UpdateViewModelFromEntity()
    // {
    //     foreach (var mapping in mappings)
    //     {
    //         var value = mapping.EntityProperty?.GetValue(Entity);
    //         mapping.ViewModelProperty.SetValue(viewModel, value);
    //     }
    // }

    public void Initialize(IViewModele<TEntity> viewModel)
    {
        this.viewModel = viewModel;
        mappings = GetOrCreateMappings();
        //InitializeViewModel();
    }
}