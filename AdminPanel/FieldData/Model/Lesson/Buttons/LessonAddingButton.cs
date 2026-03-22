using Admin.View.Moduls.Lesson;
using Admin.ViewModel.Model.Lesson;
using DataAccess.PostgreSQL.ModelsPrimitive;
using DataAccess.PostgreSQL.Repository;
using UserInterface.Info;
using UserInterface.UiLayoutPanel.ButtonPanel;
using UserInterface.UiLayoutPanel.CardPanel.Args;
using UserInterface.View;

namespace Admin.FieldData.Model.Lesson.Buttons;

public class LessonAddingButton(
    ControlView controlView, 
    Repository<LessonEntity> repository) : IButtons<LessonFieldData>
{
    public InfoButton[] GetButtons(ClickedArgs<LessonFieldData> e)
        => [
            new InfoButton("Назад").CommandClick(controlView.Exit),
            new InfoButton("Создать расписание").CommandClick(() => new LessonScheduleView(e.Data).ShowDialog()),
            new InfoButton("Сохранить").CommandClick(() =>
            {
                e.Data.ValidObject((_, entity) =>
                {
                    repository.Add(entity);
                    controlView.Exit();
                });
            }),
            new InfoButton("Добавить изображение").CommandClick(() => e.Data.RepositoryImgEntity.OnAddingImg()),
            new InfoButton("Удалить изображение").CommandClick(() => e.Data.RepositoryImgEntity.OnDeletingImg()),
        ];
}

