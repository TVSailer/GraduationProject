using CSharpFunctionalExtensions;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace DataAccess.Postgres.Extensions
{
    public static class EntityExtension
    {
        public static T Entity<T>(this T entity) where T : Entity
        {
            entity
                .GetType()
                .GetProperties()
                .Select(p => new { p, atr = p.GetCustomAttribute<ForeignKeyAttribute>()})
                .Where(p => p.atr != null)
                .ToList()
                .ForEach(pAtr =>
                {
                    entity
                        .GetType()
                        .GetProperties()
                        .Where(p => p.PropertyType.Name.Equals(pAtr.atr.Name))
                        .ToList()
                        .ForEach(p =>
                        {
                            var idProp = p.PropertyType.GetProperty("Id");
                            var id = idProp.GetValue(p.GetValue(entity));
                            pAtr.p.SetValue(entity, id);
                            p.SetValue(entity, null);
                        });
                });

            return entity;
        }
    }
}
