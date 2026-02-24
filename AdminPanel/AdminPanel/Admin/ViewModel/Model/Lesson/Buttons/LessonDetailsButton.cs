using Admin.Args;
using Admin.DI;
using Admin.View;
using Admin.ViewModels.Lesson;
using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;
using Logica.Interface;
using Logica.UI;

namespace Admin.ViewModel.Model.Lesson.Buttons;

public class LessonDetailsButton(
    ControlView controlView,
    Repository<LessonEntity> repository) : IButtons<ViewButtonClickArgs<LessonEntity, LessonDetailsFieldData>>
{
    public List<CustomButton> GetButtons(object? data, ViewButtonClickArgs<LessonEntity, LessonDetailsFieldData> e)
        => [
            new CustomButton("Назад").CommandClick(controlView.Exit),
            new CustomButton("Обновить").CommandClick(() => e.FieldData.TryWordWithEntity(entity =>
            {
                repository.Update(entity.Id, entity.GetDataNotNull());
                controlView.Exit();
            })),
            new CustomButton("Добавить изображение").CommandClick(() => e.FieldData.OnAddingImg.Execute(null)),
            new CustomButton("Удалить изображения").CommandClick(() => e.FieldData.OnDeletingImg.Execute(null)),
            new CustomButton("Обновить расписание").CommandClick(() => new ScheduleView(e.FieldData).ShowDialog()),
            new CustomButton("Удалить").CommandClick(() => repository.Delete(e.FieldData.Entity.Id)),
        ];
}