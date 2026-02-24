using Admin.Args;
using Admin.DI;
using Admin.View;
using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;
using Logica.Interface;
using Logica.UI;

namespace Admin.ViewModel.Model.News.Buttons;

public class NewsAddingButton(
    ControlView controlView, 
    Repository<NewsEntity> repository) : 
    IButtons<ViewButtonClickArgs<NewsEntity, NewsAddingFieldData>>
{
    public List<CustomButton> GetButtons(object? data, ViewButtonClickArgs<NewsEntity, NewsAddingFieldData>? e)
        => [
            new CustomButton("Сохранить").CommandClick(() => e?.FieldData.TryWordWithEntity(entity =>
                {
                    repository.Add(entity.GetDataNotNull());
                    controlView.Exit();
                })),
            new CustomButton("Добавить изображение").CommandClick(() => e?.FieldData.OnAddingImg.Execute(null)),
            new CustomButton("Удалить изображение").CommandClick(() => e?.FieldData.OnDeletingImg.Execute(null)),
            new CustomButton("Назад").CommandClick(controlView.Exit),
        ];
}