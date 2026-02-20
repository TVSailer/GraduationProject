using Admin.Args;
using Admin.DI;
using Admin.View;
using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;
using Logica;
using Logica.Interface;
using Logica.UI;

namespace Admin.ViewModel.Model.Visitor.Buttons;

public class VisitorDetailsButton(Repository<VisitorEntity> repository, ControlView control) : IButtons<ViewButtonClickArgs<VisitorEntity, VisitorDetailsFieldData>>
{
    public List<CustomButton> GetButtons(object? data, ViewButtonClickArgs<VisitorEntity, VisitorDetailsFieldData>? e)
        => [
            new CustomButton("Назад")
                .CommandClick(() => control.Exit()),
            new CustomButton("Обновить")
                .CommandClick(() => UpdateEntity(e.FieldData)),
            new CustomButton("Удалить")
                .CommandClick(() => DeleteEntity(e.FieldData))
        ];

    private void DeleteEntity(VisitorDetailsFieldData data)
    {
        repository.Delete(data.Entity.Id);
        control.Exit();
    }

    private void UpdateEntity(VisitorDetailsFieldData data)
    {
        if (Validatoreg.TryValidObject(data, out var results))
        {
            repository.Update(data.Entity.Id, data.Entity.GetData());
            control.Exit();
        }

        if (data is PropertyChange pc)
            results.ForEach(r => r.MemberNames.ForEach(n => { pc.OnMassegeErrorProvider(r.ErrorMessage, n); }));
    }
}

