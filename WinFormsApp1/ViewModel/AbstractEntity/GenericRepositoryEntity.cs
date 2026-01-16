using Admin.ViewModel.MovelView;
using Admin.ViewModels.Lesson;
using CSharpFunctionalExtensions;
using DataAccess.Postgres.Migrations;
using DataAccess.Postgres.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Concurrent;
using System.ComponentModel;
using System.Data;
using System.Reflection;

public class GenericRepositoryEntity<TEntity, TViewModel>
    where TEntity : Entity, new()
    where TViewModel : IViewModele<TEntity>
{
    private static readonly ConcurrentDictionary<Type, PropertyMapping[]> _mappingsCache = new();

    private readonly TViewModel _viewModel;
    private readonly PropertyMapping[] _mappings;

    public TEntity Entity { get; private set; } = new();

    public GenericRepositoryEntity(TViewModel viewModel)
    {
        _viewModel = viewModel;
        _mappings = GetOrCreateMappings();
        InitializeViewModel();
    }

    private PropertyMapping[] GetOrCreateMappings()
    {
        return _mappingsCache.GetOrAdd(typeof(TViewModel), type =>
        {
            var viewModelType = typeof(TViewModel);
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
                    EntityPropertyName = x.Attribute.NamePropertyEntity,
                    EntityProperty = entityType.GetProperty(x.Attribute.NamePropertyEntity)
                })
                .Where(m => m.EntityProperty != null)
                .ToArray();
        });
    }

    private void InitializeViewModel()
    {
        if (_viewModel is INotifyPropertyChanged notify)
            foreach (var mapping in _mappings)
                notify.PropertyChanged += (sender, args) =>
                {
                    var mapping = _mappings.FirstOrDefault(m => m.ViewModelProperty.Name == args.PropertyName);
                    if (mapping != null)
                        UpdateEntityFromViewModel(mapping);
                };
    }

    public void SetEntity(TEntity entity)
    {
        Entity = entity ?? throw new ArgumentNullException();
        UpdateViewModelFromEntity();
    }

    private void UpdateEntityFromViewModel(PropertyMapping mapping)
    {
        var value = mapping.ViewModelProperty.GetValue(_viewModel);

        if (value is int intenger)
            if (intenger == 0) return;
        if (value is null) return;

        mapping.EntityProperty.SetValue(Entity, value);
    }

    private void UpdateViewModelFromEntity()
    {
        foreach (var mapping in _mappings)
        {
            var value = mapping.EntityProperty.GetValue(Entity);
            mapping.ViewModelProperty.SetValue(_viewModel, value);
        }
        _viewModel.Entity = Entity;
    }
}
