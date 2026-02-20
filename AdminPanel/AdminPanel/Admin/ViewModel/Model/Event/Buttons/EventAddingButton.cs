using Admin.Args;
using Admin.DI;
using Admin.View;
using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;
using Logica;
using Logica.Interface;
using Logica.UI;

namespace Admin.ViewModel.Model.Event.Buttons;

public class EventAddingButton(Repository<EventEntity> repository, ControlView controlView) : 
    IButtons<ViewButtonClickArgs<EventEntity, EventAddingFieldData>>
{
    public List<CustomButton> GetButtons(object? data, ViewButtonClickArgs<EventEntity, EventAddingFieldData>? e)
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

    private void AddEntity(EventAddingFieldData fieldData)
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