using Admin.Args;
using Admin.DI;
using Admin.View;
using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;
using Logica;
using Logica.Interface;
using Logica.UI;

namespace Admin.ViewModel.Model.Teacher.Buttons;

public class TeacherDetailsButton(
    Repository<TeacherEntity> repository,
    ControlView controlView) : 
    IButtons<ViewButtonClickArgs<TeacherEntity, TeacherDetailsFieldData>>
{
    public List<CustomButton> GetButtons(object? data, ViewButtonClickArgs<TeacherEntity, TeacherDetailsFieldData>? e)
        => [
            new CustomButton("Назад").CommandClick(controlView.Exit),
            new CustomButton("Обновить").CommandClick(() => e?.FieldData.TryWordWithEntity(entity =>
            {
                repository.Update(entity.Id, entity.GetDataNotNull());
                controlView.Exit();
            })),
            new CustomButton("Удалить").CommandClick(() => DeleteEntity(e?.FieldData))
        ];

    private void DeleteEntity(TeacherDetailsFieldData? data)
    {
#pragma warning disable CA1510
        if (data is null) throw new ArgumentNullException();
#pragma warning restore CA1510
        if (data.Entity.GetData()?.Lessons is not {Count: 0})
        {
            LogicaMessage.MessageError("Для удаления преподователь не должен вести ни каких урков!");
            return;
        }

        repository.Delete(data.Entity.Id);
        controlView.Exit();
    }
}