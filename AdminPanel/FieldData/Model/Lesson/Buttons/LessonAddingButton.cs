using Admin.View.Moduls.Lesson;
using DataAccess.PostgreSQL.Models;
using DataAccess.PostgreSQL.Repository;
using UserInterface.Info;
using UserInterface.UiLayoutPanel.ButtonPanel;
using UserInterface.View;

namespace Admin.ViewModel.Model.Lesson.Buttons;

public class LessonAddingButton(
    ControlView controlView, 
    Repository<LessonEntity> repository) : IButtons<LessonFieldData>
{
    public List<InfoButton> GetButtons(LessonFieldData e)
        => [
            new InfoButton("Назад").CommandClick(controlView.Exit),
            new InfoButton("Создать расписание").CommandClick(() => new LessonScheduleView(e).ShowDialog()),
            new InfoButton("Сохранить").CommandClick(() =>
            {
                e.ValidObject((_, entity) =>
                {
                    repository.Add(entity);
                    controlView.Exit();
                });
            }),
            new InfoButton("Добавить изображение").CommandClick(() => e.RepositoryImgEntity.OnAddingImg()),
            new InfoButton("Удалить изображение").CommandClick(() => e.RepositoryImgEntity.OnDeletingImg()),
        ];
}

