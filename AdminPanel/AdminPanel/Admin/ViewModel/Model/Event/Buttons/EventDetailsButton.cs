using Admin.Args;
using Admin.DI;
using Admin.View;
using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;
using Logica;
using Logica.Interface;
using Logica.UI;

namespace Admin.ViewModel.Model.Event.Buttons;

public class EventDetailsButton(
    ControlView controlView,
    Repository<EventEntity> repositoryL) : IButtons<ViewButtonClickArgs<EventEntity, EventDetailsFieldData>>
{
    public List<CustomButton> GetButtons(object? data, ViewButtonClickArgs<EventEntity, EventDetailsFieldData> e)
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

    private void DeleteEntity(EventDetailsFieldData arg2FieldData)
    {
        repositoryL.Delete(arg2FieldData.Entity.Id);
        controlView.Exit();
    }

    private void UpdateEntity(EventDetailsFieldData fieldData)
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