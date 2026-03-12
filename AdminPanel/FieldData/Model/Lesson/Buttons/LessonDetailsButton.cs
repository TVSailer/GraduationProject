using Admin.View.Moduls.Lesson;
using Admin.ViewModel.Model.Lesson;
using DataAccess.PostgreSQL.Models;
using DataAccess.PostgreSQL.Repository;
using UserInterface.Info;
using UserInterface.Message;
using UserInterface.UiLayoutPanel.ButtonPanel;
using UserInterface.View;

namespace Admin.FieldData.Model.Lesson.Buttons;

public class LessonDetailsButton(
    ControlView controlView,
    Repository<LessonEntity> repository) : IButtons<LessonFieldData>
{
    public List<InfoButton> GetButtons(LessonFieldData e)
        => [
            new InfoButton("Назад").CommandClick(controlView.Exit),
            new InfoButton("Обновить").CommandClick(() =>
            {
                e.ValidObject(repository.Update);
                controlView.Exit();
            }),
            new InfoButton("Добавить изображение").CommandClick(() => e.RepositoryImgEntity.OnAddingImg()),
            new InfoButton("Удалить изображения").CommandClick(() => e.RepositoryImgEntity.OnDeletingImg()),
            new InfoButton("Обновить расписание").CommandClick(() => new LessonScheduleView(e).ShowDialog()),
            new InfoButton("Удалить").CommandClick(() =>
            {
                if (!LogicaMessage.MessageOkCancel("Вы дейсвительно хотите удалть?")) return;
                repository.Delete(e.Entity.Id);
                controlView.Exit();
            }),
        ];
}