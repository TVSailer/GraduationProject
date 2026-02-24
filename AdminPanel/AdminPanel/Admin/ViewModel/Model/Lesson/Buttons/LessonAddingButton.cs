using Admin.Args;
using Admin.DI;
using Admin.View;
using Admin.ViewModels.Lesson;
using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;
using Logica.Interface;
using Logica.UI;

namespace Admin.ViewModel.Model.Lesson.Buttons;

public class LessonAddingButton(
    ControlView controlView, 
    Repository<LessonEntity> repository) : IButtons<ViewButtonClickArgs<LessonEntity, LessonAddingFieldData>>
{
    public List<CustomButton> GetButtons(object? data, ViewButtonClickArgs<LessonEntity, LessonAddingFieldData>? e)
        => [
            new CustomButton("Создать расписание").CommandClick(() => new ScheduleView(e?.FieldData).ShowDialog()),
            new CustomButton("Сохранить").CommandClick(() => e?.FieldData.TryWordWithEntity(entity =>
            {
                repository.Add(entity.GetDataNotNull());
                controlView.Exit();
            })),
            new CustomButton("Добавить изображение").CommandClick(() => e ?.FieldData.OnAddingImg.Execute(null)),
            new CustomButton("Удалить изображение").CommandClick(() => e ?.FieldData.OnDeletingImg.Execute(null)),
            new CustomButton("Назад").CommandClick(controlView.Exit),
        ];
}

