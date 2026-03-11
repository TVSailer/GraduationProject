using Admin.View.Moduls.Lesson;
using Admin.ViewModel.Model.Lesson;
using DataAccess.PostgreSQL.Models;
using DataAccess.PostgreSQL.Repository;
using UserInterface.Message;
using UserInterface.UiLayoutPanel.ButtonPanel;
using UserInterface.View;

namespace Admin.FieldData.Model.Lesson.Buttons;

public class LessonDetailsButton(
    ControlView controlView,
    Repository<LessonEntity> repository) : IButtons<LessonFieldData>
{
    public List<CustomButton> GetButtons(LessonFieldData e)
        => [
            new CustomButton("Назад").CommandClick(controlView.Exit),
            new CustomButton("Обновить").CommandClick(() =>
            {
                e.ValidObject(repository.Update);
                controlView.Exit();
            }),
            new CustomButton("Добавить изображение").CommandClick(() => e.RepositoryImgEntity.OnAddingImg()),
            new CustomButton("Удалить изображения").CommandClick(() => e.RepositoryImgEntity.OnDeletingImg()),
            new CustomButton("Обновить расписание").CommandClick(() => new LessonScheduleView(e).ShowDialog()),
            new CustomButton("Удалить").CommandClick(() =>
            {
                if (!LogicaMessage.MessageOkCancel("Вы дейсвительно хотите удалть?")) return;
                repository.Delete(e.Entity.Id);
                controlView.Exit();
            }),
        ];
}