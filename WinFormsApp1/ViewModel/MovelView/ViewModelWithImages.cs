using Admin.ViewModels.Lesson;
using CSharpFunctionalExtensions;
using Logica;
using Logica.Img;
using System.Windows.Input;
using WinFormsApp1.View;
using DataAccess.Postgres.Repository;
using DataAccess.Postgres.Models;
using System.Linq.Expressions;
using System.Reflection;
using System.Collections;

namespace Admin.ViewModels.NotifuPropertyViewModel
{
    public abstract class ViewModelWithImages<TEntity> : ViewModel<TEntity>
        where TEntity : Entity, new()
    {
        public Dictionary<string, bool> SelectedImg { get; protected set; } = new();

        protected ViewModelWithImages()
        {
        }

        protected ViewModelWithImages(Repository<TEntity> repository) : base(repository)
        {
            Type genericArgumentForListImgs = null;

            var TypelistImgs = typeof(TEntity)
                .GetProperties()
                .FirstOrDefault(p => p.PropertyType.GenericTypeArguments
                .FirstOrDefault(a => a.BaseType.Name == nameof(ImgEntity))
                .With(type => genericArgumentForListImgs = type)!= null);

            if (TypelistImgs is null) throw new Exception();
            if (genericArgumentForListImgs is null) throw new Exception();

            var constructorList = TypelistImgs.PropertyType.GetConstructor([]) ?? throw new ArgumentNullException();
            var listImg = constructorList.Invoke([]);

            OnSetEntiy += (entity) =>
            {
                var imgEntity = (IEnumerable?)TypelistImgs.GetValue(entity);

                imgEntity.ForEach(img => SelectedImg.Add((string)img
                    .GetType()
                    .GetProperty("Url")
                    .GetValue(img), false));
            };

            OnGetEntity += (entity) =>
            {
                //constructorList.GetType().GetMethod("Clear").Invoke(constructorList, []);

                SelectedImg.ForEach(i =>
                {
                    var method = TypelistImgs.PropertyType.GetMethod("Add");
                    method.Invoke(listImg, [genericArgumentForListImgs.GetConstructor([typeof(string)]).Invoke([i.Key])]);
                });

                TypelistImgs.SetValue(entity, listImg);
            };
        }

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

        [ButtonInfo("Удалить изображение")] 
        public ICommand OnDeletingImg => new MainCommand(
            _ =>
            {
                if (!SelectedImg.ContainsValue(true)) return;
                SelectedImg.ForEach(img => img.If(img.Value, i => SelectedImg.Remove(img.Key)));
                OnPropertyChanged(nameof(OnDeletingImg));
            });
    }
}
