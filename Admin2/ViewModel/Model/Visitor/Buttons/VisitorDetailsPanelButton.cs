using Admin.Args;
using Admin.DI;
using Admin.View;
using Admin.ViewModel.Interface;
using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;
using Logica;

namespace Admin.ViewModel.Model.Visitor.Buttons;

public class VisitorDetailsButton(Repository<VisitorEntity> repository, ControlView control) : IButtons<ViewButtonClickArgs<VisitorEntity, VisitorDetailsFieldData>>
{
    public List<CustomButton<ViewButtonClickArgs<VisitorEntity, VisitorDetailsFieldData>>> GetButtons(object? data = null)
        => [
            new CustomButton<ViewButtonClickArgs<VisitorEntity, VisitorDetailsFieldData>>()
                .LabelText("Назад")
                .CommandClick((_, _) => control.Exit()),
            new CustomButton<ViewButtonClickArgs<VisitorEntity, VisitorDetailsFieldData>>()
                .LabelText("Обновить")
                .CommandClick((_, e) => UpdateEntity(e.FieldData)),
            new CustomButton<ViewButtonClickArgs<VisitorEntity, VisitorDetailsFieldData>>()
                .LabelText("Удалить")
                .CommandClick((_, e) => DeleteEntity(e.FieldData))
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

