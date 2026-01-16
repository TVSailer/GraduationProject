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
        private readonly PropertyInfo typeListImgs;

        [LinkingEntity("Imgs")]
        public object? listImgs { 
            get; 
            set
            {
                if (field is null)
                    InitializeImages(value);
                field = value;
                OnPropertyChanged();
            }
        }

        private void InitializeImages(object? value)
        {
            if (value is IEnumerable list)
            {
                list.ForEach(img =>
                {
                    var imageType = img.GetType();
                    var imageProp = imageType.GetProperty("Url");

                    if (imageProp is null) throw new ArgumentException();
                    var image = imageProp.GetValue(img);

                    if (image is string url)
                        SelectedImg.TryAdd(url, false);
                });
            }
        }

        protected ViewModelWithImages()
        {
            var typeListImgs = typeof(TEntity)
                .GetProperties()
                .FirstOrDefault(p => p.PropertyType.GenericTypeArguments
                .FirstOrDefault(a => a.BaseType == typeof(ImgEntity)) != null);

            if (typeListImgs is null) throw new ArgumentNullException();

            this.typeListImgs = typeListImgs;

            genericAttributeListImgs = typeListImgs
                .PropertyType
                .GenericTypeArguments
                .First();

            constructorListImgs = typeListImgs.PropertyType.GetConstructor([]) ?? throw new ArgumentNullException();
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
                            SelectedImg.TryAdd(fileName, false);
                    }
                }

                OnSet(true);
                OnPropertyChanged(nameof(OnAddingImg));
            });

        [ButtonInfoUI("Удалить изображение")]
        public ICommand OnDeletingImg => new MainCommand(
            _ =>
            {
                if (!SelectedImg.ContainsValue(true)) return;
                SelectedImg.ForEach(img => img.If(img.Value, i => SelectedImg.Remove(img.Key)));

                OnSet(false);
                OnPropertyChanged(nameof(OnDeletingImg));
            });

        private void OnSet(bool isSaveListImgs)
        {
            var newListImgs = constructorListImgs.Invoke([]);

            if (isSaveListImgs)
                if (listImgs != null)
                    newListImgs = listImgs;

            SelectedImg.ForEach(i =>
            {
                var method = typeListImgs.PropertyType.GetMethod("Add");
                var contsructorImage = genericAttributeListImgs.GetConstructor([typeof(string)]);

                if (method is null) throw new ArgumentNullException();
                if (contsructorImage is null) throw new ArgumentNullException();

                method.Invoke(newListImgs, [contsructorImage.Invoke([i.Key])]);
            });

            listImgs = newListImgs;
        }

    }
}
