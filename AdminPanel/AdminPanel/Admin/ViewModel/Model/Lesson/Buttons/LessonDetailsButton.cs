using Admin.Args;
using Admin.DI;
using Admin.View;
using Admin.View.Moduls.Lesson;
using Admin.ViewModels.Lesson;
using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;
using User_Interface_Library.UiLayoutPanel.ButtonPanel;
using User_Interface_Library.View;

namespace Admin.ViewModel.Model.Lesson.Buttons;

public class LessonDetailsButton(
    ControlView controlView,
    Repository<LessonEntity> repository) : IButtons<LessonFieldData>
{
    public List<CustomButton> GetButtons(LessonFieldData e)
        => [
            new CustomButton("Назад").CommandClick(controlView.Exit),
            new CustomButton("Обновить").CommandClick(() => e.ValidObject(entity =>
            {
                repository.Update(entity.Id, entity.GetDataNotNull());
                controlView.Exit();
            })),
            new CustomButton("Добавить изображение").CommandClick(() => e.RepositoryImgEntity.OnAddingImg()),
            new CustomButton("Удалить изображения").CommandClick(() => e.RepositoryImgEntity.OnDeletingImg()),
            new CustomButton("Обновить расписание").CommandClick(() => new ScheduleView(e).ShowDialog()),
            new CustomButton("Удалить").CommandClick(() => repository.Delete(e.MementoEntity.Id)),
        ];
}