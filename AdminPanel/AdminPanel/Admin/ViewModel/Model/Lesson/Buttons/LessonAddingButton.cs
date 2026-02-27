using Admin.View.Moduls.Lesson;
using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;
using User_Interface_Library.UiLayoutPanel.ButtonPanel;
using User_Interface_Library.View;

namespace Admin.ViewModel.Model.Lesson.Buttons;

public class LessonAddingButton(
    ControlView controlView, 
    Repository<LessonEntity> repository) : IButtons<LessonFieldData>
{
    public List<CustomButton> GetButtons(LessonFieldData e)
        => [
            new CustomButton("Создать расписание").CommandClick(() => new ScheduleView(e).ShowDialog()),
            new CustomButton("Сохранить").CommandClick(() => e.ValidObject(entity =>
            {
                repository.Add(entity.GetDataNotNull());
                controlView.Exit();
            })),
            new CustomButton("Добавить изображение").CommandClick(() => e.RepositoryImgEntity.OnAddingImg()),
            new CustomButton("Удалить изображение").CommandClick(() => e.RepositoryImgEntity.OnDeletingImg()),
            new CustomButton("Назад").CommandClick(controlView.Exit),
        ];
}

