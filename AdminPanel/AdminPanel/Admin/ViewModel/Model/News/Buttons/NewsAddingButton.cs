using Admin.Args;
using Admin.DI;
using Admin.View;
using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;
using Logica;
using Logica.Interface;
using Logica.UI;

namespace Admin.ViewModel.Model.News.Buttons;

public class NewsAddingButton(Repository<NewsEntity> repository, ControlView controlView) : 
    IButtons<ViewButtonClickArgs<NewsEntity, NewsAddingFieldData>>
{
    public List<CustomButton> GetButtons(object? data, ViewButtonClickArgs<NewsEntity, NewsAddingFieldData>? e)
        => [
            new CustomButton("Сохранить")
                .CommandClick(() => AddEntity(e.FieldData)),
            new CustomButton("Добавить изображение")
                .CommandClick(() => e.FieldData.OnAddingImg.Execute(null)),
            new CustomButton("Удалить изображение")
                .CommandClick(() => e.FieldData.OnDeletingImg.Execute(null)),
            new CustomButton("Назад")
                .CommandClick(() => controlView.Exit()),
        ];

    private void AddEntity(NewsAddingFieldData fieldData)
    {
        if (Validatoreg.TryValidObject(fieldData, out var results))
        {
            repository.Add(fieldData.Entity.GetData());
            controlView.Exit();
        }
        ;

        if (fieldData is PropertyChange pc)
            results.ForEach(r => r.MemberNames.ForEach(n => { pc.OnMassegeErrorProvider(r.ErrorMessage, n); }));
    }
}