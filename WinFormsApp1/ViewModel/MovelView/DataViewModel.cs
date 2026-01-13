using Admin.ViewModels.Lesson;
using CSharpFunctionalExtensions;
using System.Data;
using System.Reflection;

namespace Admin.ViewModels.NotifuPropertyViewModel
{
    internal class DataViewModel<TEntity>
        where TEntity : Entity
    {
        public IViewModele<TEntity> Instance { get; set; }
        public Dictionary<PropertyInfo, LinkingEntityAttribute> FildsData { get; set; } = new();

        public void SetValue(TEntity entity)
        {
            FildsData.ForEach(f =>
            {
                var value = f.Key.GetValue(Instance);
                entity.SetValue(value, f.Value.NamePropertyEntity);
                Instance.Entity = entity;
            });
        }

        public void GetValue(TEntity entity)
        {
            FildsData.ForEach(f =>
            {
                var value = entity.GetValue(f.Value.NamePropertyEntity);
                f.Key.SetValue(Instance, value);
                Instance.Entity = entity;
            });
        }
    }
}
