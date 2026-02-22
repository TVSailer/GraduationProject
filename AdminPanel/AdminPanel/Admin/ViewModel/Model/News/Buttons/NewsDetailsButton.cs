using Admin.Args;
using Admin.DI;
using Admin.View;
using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;
using Logica;
using Logica.Interface;
using Logica.UI;

namespace Admin.ViewModel.Model.News.Buttons;

public class NewsDetailsButton(
    ControlView controlView,
    Repository<NewsEntity> repositoryL) : IButtons<ViewButtonClickArgs<NewsEntity, NewsDetailsFieldData>>
{
    public List<CustomButton> GetButtons(object? data, ViewButtonClickArgs<NewsEntity, NewsDetailsFieldData> e)
        =>
        [
            new CustomButton("Назад")
                .CommandClick(() => controlView.Exit()),
            new CustomButton("Обновить")
                .CommandClick(() => UpdateEntity(e.FieldData)),
            new CustomButton("Добавить изображение")
                .CommandClick(() => e.FieldData.OnAddingImg.Execute(null)),
            new CustomButton("Удалить изображения")
                .CommandClick(() => e.FieldData.OnDeletingImg.Execute(null)),
            new CustomButton("Удалить")
                .CommandClick(() => DeleteEntity(e.FieldData)),
        ];

    private void DeleteEntity(NewsDetailsFieldData arg2FieldData)
    {
        repositoryL.Delete(arg2FieldData.Entity.Id);
        controlView.Exit();
    }

    private void UpdateEntity(NewsDetailsFieldData fieldData)
    {
        if (Validatoreg.TryValidObject(fieldData, out var results))
        {
            repositoryL.Update(fieldData.Entity.Id, fieldData.Entity.GetData());
            controlView.Exit();
        }

        if (fieldData is PropertyChange pc)
            results.ForEach(r => r.MemberNames.ForEach(n => { pc.OnMassegeErrorProvider(r.ErrorMessage, n); }));
    }
}