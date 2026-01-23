using System.Collections.Concurrent;
using System.ComponentModel;
using System.Reflection;
using Admin.ViewModels.Lesson;
using Admin.ViewModels.NotifuPropertyViewModel;
using CSharpFunctionalExtensions;
using Ninject;

namespace Admin.ViewModel.WordWithEntity;

public class GenericRepositoryEntity<TEntity>
    where TEntity : Entity, new()
{
    //private static readonly ConcurrentDictionary<Type, PropertyMapping[]> mappingsCache = new();

    private IViewModele<TEntity> viewModel;
    private PropertyMapping[] mappings;

    public TEntity Entity { get; private set; } = new();

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

    private void InitializeViewModel()
    {
        foreach (var mapping in mappings)
            if (viewModel is PropertyChange propertyChange)
                propertyChange.PropertyChanged += (sender, args) =>
                {
                    var firstOrDefault = mappings.FirstOrDefault(m => m.ViewModelProperty.Name == args.PropertyName);
                    if (firstOrDefault != null)
                        UpdateEntityFromViewModel(firstOrDefault);
                };
    }

    public void SetEntity(TEntity entity)
    {
        Entity = entity ?? throw new ArgumentNullException();
        UpdateViewModelFromEntity();
    }

    private void UpdateEntityFromViewModel(PropertyMapping mapping)
    {
        var value = mapping.ViewModelProperty.GetValue(viewModel);

        if (value is 0)
            return;
        if (value is null) return;

        mapping.EntityProperty?.SetValue(Entity, value);
    }

    private void UpdateViewModelFromEntity()
    {
        var d = viewModel.GetHashCode();
        foreach (var mapping in mappings)
        {
            var value = mapping.EntityProperty?.GetValue(Entity);
            mapping.ViewModelProperty.SetValue(viewModel, value);
        }
    }

    public void Initialize(IViewModele<TEntity> viewModel)
    {
        this.viewModel = viewModel;
        mappings = GetOrCreateMappings();
        InitializeViewModel();
    }
}