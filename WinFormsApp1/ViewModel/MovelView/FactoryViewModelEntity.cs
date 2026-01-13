using Admin.ViewModel.MovelView;
using Admin.ViewModels.Lesson;
using CSharpFunctionalExtensions;
using DataAccess.Postgres.Migrations;
using DataAccess.Postgres.Models;
using System.Data;
using System.Reflection;

namespace Admin.ViewModels.NotifuPropertyViewModel
{

    public class FactoryViewModelEntity<TEntity>
        where TEntity : Entity
    {
        private List<DataViewModel<TEntity>> dataViewModel = new();

        protected TEntity Entity
        {
            get
            {
                if (field is null) throw new ArgumentNullException();

                dataViewModel.ForEach(d => d.SetValue(field));

                return field;
            }
            set
            {
                dataViewModel.ForEach(d => d.GetValue(field));
                field = value;
            }
        }

        public FactoryViewModelEntity(params IViewModele<TEntity>[] viewModel)
        {
            viewModel
                .ToList()
                .ForEach(v =>
                {
                    var data = new DataViewModel<TEntity>();
                    data.Instance = v;

                    v.GetType().GetProperties()
                        .ForEach(p => p.GetCustomAttributes().ForEach(a =>
                        {
                            if (a is LinkingEntityAttribute atr)
                            {
                                if (typeof(TEntity).GetProperty(atr.NamePropertyEntity).PropertyType == p.PropertyType)
                                    data.FildsData.Add(p, atr);
                                else throw new ArgumentException();
                            }
                        }));

                    dataViewModel.Add(data);
                });
        }

        public void SetEntity(TEntity value)
        {
            Entity = value;
        }

        public void SetValue(object? value, PropertyInfo property)
        {
            Entity.SetValue(value, property.Name);
        }

        public object? GetValue(PropertyInfo property)
        {
            return Entity.GetValue(property.Name);
        }

        public PropertyInfo? GetPropertyGenericArgements<T>()
        {
            return typeof(TEntity)
                .GetProperties()
                .FirstOrDefault(p => p.PropertyType.GenericTypeArguments
                .FirstOrDefault(a => a.Equals(typeof(T))) != null);
        }
    }
}

public static class EntityExtension
{
    public static void SetValue<T>(this T entiy, object? value, string prop)
        where T : Entity
    {
        typeof(T)
        .GetProperty(prop)
        .SetValue(entiy, value);
    }

    public static object? GetValue<T>(this T entity, string prop)
    {
        return typeof(T)
        .GetProperty(prop)
        .GetValue(entity);
    }
}