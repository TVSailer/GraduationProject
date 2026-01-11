using Admin.ViewModels.Lesson;
using CSharpFunctionalExtensions;
using System.Reflection;

namespace Admin.ViewModels.NotifuPropertyViewModel
{
    public static class ViewModelExtension
    {
        public static ViewModelInfo GetDescription<TEntity>(this IViewModel<TEntity> viewModel) where TEntity : Entity
        {
            var property = viewModel.GetType().GetProperties();


            return new ViewModelInfo(
                property
                .Select(p => p.GetCustomAttribute<FieldInfoAttribute>())
                .Where(at => at != null)
                .ToList() ?? throw new ArgumentNullException(),
                property
                .Select(p => p.GetCustomAttribute<ButtonInfoAttribute>())
                .Where(at => at != null)
                .ToList() ?? throw new ArgumentNullException()
                );
        }
    }
}
