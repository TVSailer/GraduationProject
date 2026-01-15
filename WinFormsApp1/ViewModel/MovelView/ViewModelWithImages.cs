using Admin.ViewModel.MovelView;
using Admin.ViewModels.Lesson;
using CSharpFunctionalExtensions;
using DataAccess.Postgres.Migrations;
using DataAccess.Postgres.Models;
using Logica;
using System.Collections;
using System.Reflection;
using System.Windows.Input;

namespace Admin.ViewModels.NotifuPropertyViewModel
{
    public class ViewModelWithImages<TEntity> : ViewModele<TEntity>
        where TEntity : Entity, new()
    {
        public Dictionary<string, bool> SelectedImg { get; protected set; } = new();

        private readonly ConstructorInfo constructorListImgs;
        private readonly Type genericAttributeListImgs;
        private readonly PropertyInfo? typeListImgs;

        [LinkingEntity("Imgs")]
        [FieldInfoUI("Название:*", "Введите название")]
        public object? listImgs { get; 
            set => field = Set(value); }

        protected ViewModelWithImages()
        {
            typeListImgs = typeof(TEntity)
                .GetProperties()
                .FirstOrDefault(p => p.PropertyType.GenericTypeArguments
                .FirstOrDefault(a => a.BaseType == typeof(ImgEntity)) != null);

            if (typeListImgs is null) throw new Exception();

            genericAttributeListImgs = typeListImgs
                .PropertyType
                .GenericTypeArguments
                .First();

            constructorListImgs = typeListImgs.PropertyType.GetConstructor([]) ?? throw new ArgumentNullException();

            if (Entity is null) return;

            var imgEntity = (IEnumerable?)typeListImgs.GetValue(Entity);

            imgEntity.ForEach(img => SelectedImg.Add((string)img
                .GetType()
                .GetProperty("Url")
                .GetValue(img), false));
        }

        [ButtonInfoUI("Добавить изображения")]
        public ICommand OnAddingImg => new MainCommand(
            _ =>
            {
                using (var openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = "PictureBox Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
                    openFileDialog.Title = "Выберите изображения мероприятия";
                    openFileDialog.Multiselect = true;

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        foreach (var fileName in openFileDialog.FileNames)
                            if (!SelectedImg.ContainsKey(fileName))
                                SelectedImg.Add(fileName, false);
                    }
                }

                OnSet();
                OnPropertyChanged(nameof(OnAddingImg));
            });

        [ButtonInfoUI("Удалить изображение")]
        public ICommand OnDeletingImg => new MainCommand(
            _ =>
            {
                if (!SelectedImg.ContainsValue(true)) return;
                SelectedImg.ForEach(img => img.If(img.Value, i => SelectedImg.Remove(img.Key)));

                OnSet();
                OnPropertyChanged(nameof(OnDeletingImg));
            });

        private void OnSet()
        {
            var newListImgs = constructorListImgs.Invoke([]);

            typeListImgs.PropertyType.GetMethod("Clear").Invoke(newListImgs, []);

            SelectedImg.ForEach(i =>
            {
                var method = typeListImgs.PropertyType.GetMethod("Add");
                method.Invoke(newListImgs, [genericAttributeListImgs.GetConstructor([typeof(string)]).Invoke([i.Key])]);
            });

            listImgs = newListImgs;
        }
    }
}
