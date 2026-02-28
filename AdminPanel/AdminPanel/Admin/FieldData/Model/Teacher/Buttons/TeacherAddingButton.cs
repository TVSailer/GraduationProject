using Admin.Args;
using Admin.DI;
using Admin.View;
using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;
using Logica.Interface;
using Logica.UI;

namespace Admin.ViewModel.Model.Teacher.Buttons;

public class TeacherAddingButton(
    ControlView controlView, 
    Repository<TeacherEntity> repository) : 
    IButtons<ViewButtonClickArgs<TeacherEntity, TeacherAddingFieldData>>
{
    public List<CustomButton> GetButtons(
        object? data, ViewButtonClickArgs<TeacherEntity, TeacherAddingFieldData>? e)
        => [
            new CustomButton("Назад").CommandClick(controlView.Exit),
            new CustomButton("Сохранить").CommandClick(() => e?.FieldData.TryWordWithEntity(entity =>
            {
                repository.Add(entity.GetDataNotNull());
                controlView.Exit();
            })),
        ];
}