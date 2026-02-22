using Admin.Args;
using Admin.DI;
using Admin.View;
using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;
using Logica;
using Logica.Interface;
using Logica.UI;

namespace Admin.ViewModel.Model.Teacher.Buttons;

public class TeacherDetailsButton(Repository<TeacherEntity> repository, ControlView control) : 
    IButtons<ViewButtonClickArgs<TeacherEntity, TeacherDetailsFieldData>>
{
    public List<CustomButton> GetButtons(object? data, ViewButtonClickArgs<TeacherEntity, TeacherDetailsFieldData>? e)
        => [
            new CustomButton("Назад")
                .CommandClick(() => control.Exit()),
            new CustomButton("Обновить")
                .CommandClick(() => UpdateEntity(e.FieldData)),
            new CustomButton("Удалить")
                .CommandClick(() => DeleteEntity(e.FieldData))
        ];

    private void DeleteEntity(TeacherDetailsFieldData data)
    {
        if (data.Entity.GetData().Lessons is not {Count: 0})
        {
            LogicaMessage.MessageError("Для удаления преподователь не должен вести ни каких урков!");
            return;
        }

        repository.Delete(data.Entity.Id);
        control.Exit();
    }

    private void UpdateEntity(TeacherDetailsFieldData data)
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