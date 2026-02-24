using Admin.Args;
using Admin.DI;
using Admin.View;
using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;
using Logica.Interface;
using Logica.UI;

namespace Admin.ViewModel.Model.News.Buttons;

public class NewsDetailsButton(
    ControlView controlView,
    Repository<NewsEntity> repository) : IButtons<ViewButtonClickArgs<NewsEntity, NewsDetailsFieldData>>
{
    public List<CustomButton> GetButtons(object? data, ViewButtonClickArgs<NewsEntity, NewsDetailsFieldData> e)
        =>
        [
            new CustomButton("Назад").CommandClick(controlView.Exit),
            new CustomButton("Обновить").CommandClick(() => e.FieldData.TryWordWithEntity(entity =>
                    {
                        repository.Update(entity.Id, entity.GetDataNotNull());
                        controlView.Exit();
                    })),
            new CustomButton("Добавить изображение").CommandClick(() => e.FieldData.OnAddingImg.Execute(null)),
            new CustomButton("Удалить изображения").CommandClick(() => e.FieldData.OnDeletingImg.Execute(null)),
            new CustomButton("Удалить").CommandClick(() =>
                {
                    repository.Delete(e.FieldData.Entity.Id);
                    controlView.Exit();
                }),
        ];
}