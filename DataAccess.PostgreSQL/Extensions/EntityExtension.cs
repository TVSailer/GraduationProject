using CSharpFunctionalExtensions;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;

namespace DataAccess.PostgreSQL.Extensions
{
    public static class EntityExtension
    {
        public static T Entity<T>(this T entity)
        {
            entity
                .GetType()
                .GetProperties()
                .Select(selector: p => new { p, atr = p.GetCustomAttribute<ForeignKeyAttribute>()})
                .Where(predicate: p => p.atr != null)
                .ToList()
                .ForEach(action: pAtr =>
                {
                    entity
                        .GetType()
                        .GetProperties()
                        .Where(predicate: p => p.PropertyType.Name.Equals(value: pAtr.atr.Name))
                        .ToList()
                        .ForEach(action: p =>
                        {
                            if (p.GetValue(obj: entity) == null) return;
                            var idProp = p.PropertyType.GetProperty(name: "Id");
                            var id = idProp.GetValue(obj: p.GetValue(obj: entity));
                            pAtr.p.SetValue(obj: entity, value: id);
                            p.SetValue(obj: entity, value: null);
                        });
                });

            return entity;
        }
    }
}
