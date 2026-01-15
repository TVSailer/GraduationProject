using CSharpFunctionalExtensions;
//namespace Admin.ViewModels.NotifuPropertyViewModel
//{
//    public class RepositoryEntity<TEntity, TViewModel>
//        where TEntity : Entity
//        where TViewModel : IViewModele<TEntity>
//    {
//        private DataViewModel<TEntity> dataViewModel = new();

//        protected TEntity Entity
//        {
//            get
//            {
//                if (field is null) throw new ArgumentNullException();

//                dataViewModel.SetValue(field);

//                return field;
//            }
//            set
//            {
//                dataViewModel.GetValue(field);
//                field = value;
//            }
//        }

//        public RepositoryEntity(TViewModel viewModel)
//        {
//            dataViewModel = new DataViewModel<TEntity>();
//            dataViewModel.Instance = viewModel;

//            viewModel.GetType().GetProperties()
//                .ForEach(p => p.GetCustomAttributes().ForEach(a =>
//                {
//                    if (a is LinkingEntityAttribute atr)
//                    {
//                        if (typeof(TEntity).GetProperty(atr.NamePropertyEntity).PropertyType == p.PropertyType)
//                            dataViewModel.FildsData.Add(p, atr);
//                        else throw new ArgumentException();
//                    }
//                }));
//        }

//        public void SetEntity(TEntity value)
//        {
//            Entity = value;
//        }

//        public void SetValue(object? value, PropertyInfo property)
//        {
//            Entity.SetValue(value, property.Name);
//        }

//        public object? GetValue(PropertyInfo property)
//        {
//            return Entity.GetValue(property.Name);
//        }

//        public PropertyInfo? GetPropertyGenericArgements<T>()
//        {
//            return typeof(TEntity)
//                .GetProperties()
//                .FirstOrDefault(p => p.PropertyType.GenericTypeArguments
//                .FirstOrDefault(a => a.Equals(typeof(T))) != null);
//        }
//    }
//}

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
