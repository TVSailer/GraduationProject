using Admin.ViewModels.Lesson;
using CSharpFunctionalExtensions;
using Logica;
using Logica.Img;
using System.Windows.Input;
using WinFormsApp1.View;
using DataAccess.Postgres.Repository;

namespace Admin.ViewModels.NotifuPropertyViewModel
{
    public abstract class ViewModelWithImages<TEntity> : ViewModel<TEntity>
        where TEntity : Entity
    {
        protected ViewModelWithImages()
        {
        }

        protected ViewModelWithImages(Repository<TEntity> repository) : base(repository)
        {
        }

        public Dictionary<string, bool> SelectedImg { get; private set; } = new();

        [ButtonInfo("Добавить изображения")]
        public ICommand OnAddingImg => new MainCommand(
            _ =>
            {
                ImageDialog.WorkWithImages((fileName) =>
                {
                    if (!SelectedImg.ContainsKey(fileName))
                        SelectedImg.Add(fileName, false);
                }, true);

                OnPropertyChanged(nameof(OnAddingImg));
            }
            );

        [ButtonInfo("Удалить изображение")] public ICommand OnDeletingImg => new MainCommand(
            _ =>
            {
                if (!SelectedImg.ContainsValue(true)) return;
                SelectedImg.ForEach(img => img.If(img.Value, i => SelectedImg.Remove(img.Key)));
                OnPropertyChanged(nameof(OnDeletingImg));
            });
    }
}
