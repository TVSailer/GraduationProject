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
    public abstract class ViewModelWithImages<TEntity, TImgEntity> : ViewModele<TEntity>
        where TImgEntity : ImgEntity
        where TEntity : Entity, new()
    {
        public Dictionary<string, bool> SelectedImg { get; protected set; } = new();
        private readonly PropertyInfo? typeListImgs;
        private object? listImg;

        public override TEntity Entity { 
            get
            {
                typeListImgs.PropertyType.GetMethod("Clear").Invoke(listImg, []);

                SelectedImg.ForEach(i =>
                {
                    var method = typeListImgs.PropertyType.GetMethod("Add");
                    method.Invoke(listImg, [typeof(TImgEntity).GetConstructor([typeof(string)]).Invoke([i.Key])]);
                });

                field.SetValue(listImg, typeListImgs.Name);

                return field;
            }
            set
            {
                var imgEntity = (IEnumerable?)field.GetValue(typeListImgs.Name);

                imgEntity.ForEach(img => SelectedImg.Add((string)img
                    .GetType()
                    .GetProperty("Url")
                    .GetValue(img), false));
            }
        }

        protected ViewModelWithImages()
        {
            typeListImgs = typeof(TEntity)
                .GetProperties()
                .FirstOrDefault(p => p.PropertyType.GenericTypeArguments
                .FirstOrDefault(a => a == (typeof(TImgEntity))) != null);

            if (typeListImgs is null) throw new Exception();

            var constructorList = typeListImgs.PropertyType.GetConstructor([]) ?? throw new ArgumentNullException();
            listImg = constructorList.Invoke([]);

            //ViewModelEntity<TEntity>.OnSetEntiy += GetValueEntity;
            //ViewModelEntity<TEntity>.OnGetEntity += SetValueEntity;
        }

        //private void SetValueEntity(TEntity entity)
        //{
        //    typeListImgs.PropertyType.GetMethod("Clear").Invoke(listImg, []);

        //    SelectedImg.ForEach(i =>
        //    {
        //        var method = typeListImgs.PropertyType.GetMethod("Add");
        //        method.Invoke(listImg, [typeof(TImgEntity).GetConstructor([typeof(string)]).Invoke([i.Key])]);
        //    });

        //    entity.SetValue(listImg, typeListImgs.Name);
        //}

        //private void GetValueEntity(TEntity entity)
        //{
        //    var imgEntity = (IEnumerable?)entity.GetValue(typeListImgs.Name);

        //    imgEntity.ForEach(img => SelectedImg.Add((string)img
        //        .GetType()
        //        .GetProperty("Url")
        //        .GetValue(img), false));
        //}

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

                OnPropertyChanged(nameof(OnAddingImg));
            });

        [ButtonInfoUI("Удалить изображение")]
        public ICommand OnDeletingImg => new MainCommand(
            _ =>
            {
                if (!SelectedImg.ContainsValue(true)) return;
                SelectedImg.ForEach(img => img.If(img.Value, i => SelectedImg.Remove(img.Key)));
                OnPropertyChanged(nameof(OnDeletingImg));
            });


        //public void Dispose()
        //{
        //    ViewModelEntity<TEntity>.OnSetEntiy -= GetValueEntity;
        //    ViewModelEntity<TEntity>.OnGetEntity -= SetValueEntity;
        //}
    }
}
