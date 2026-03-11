using Admin.View.Moduls.Lesson;
using DataAccess.PostgreSQL.Models;
using DataAccess.PostgreSQL.Repository;
using UserInterface.UiLayoutPanel.ButtonPanel;
using UserInterface.View;

namespace Admin.ViewModel.Model.Lesson.Buttons;

public class LessonAddingButton(
    ControlView controlView, 
    Repository<LessonEntity> repository) : IButtons<LessonFieldData>
{
    public List<CustomButton> GetButtons(LessonFieldData e)
        => [
            new CustomButton("Назад").CommandClick(controlView.Exit),
            new CustomButton("Создать расписание").CommandClick(() => new LessonScheduleView(e).ShowDialog()),
            new CustomButton("Сохранить").CommandClick(() =>
            {
                e.ValidObject((_, entity) =>
                {
                    repository.Add(entity);
                    controlView.Exit();
                });
            }),
            new CustomButton("Добавить изображение").CommandClick(() => e.RepositoryImgEntity.OnAddingImg()),
            new CustomButton("Удалить изображение").CommandClick(() => e.RepositoryImgEntity.OnDeletingImg()),
        ];
}

