using Admin.View.Moduls.Lesson;
using Admin.ViewModel.Model.Lesson;
using DataAccess.PostgreSQL.ModelsPrimitive;
using DataAccess.PostgreSQL.Repository;
using UserInterface.Info;
using UserInterface.Message;
using UserInterface.UiLayoutPanel.ButtonPanel;
using UserInterface.UiLayoutPanel.CardPanel.Args;
using UserInterface.View;

namespace Admin.FieldData.Model.Lesson.Buttons;

public class LessonDetailsButton(
    ControlView controlView,
    Repository<LessonEntity> repository) : IButtons<LessonFieldData>
{

    public InfoButton[] GetButtons(ClickedArgs<LessonFieldData> e)
        => [
            new InfoButton("Назад").CommandClick(controlView.Exit),
            new InfoButton("Обновить").CommandClick(() =>
            {
                e.Data.ValidObject(repository.Update);
                controlView.Exit();
            }),
            new InfoButton("Добавить изображение").CommandClick(() => e.Data.RepositoryImgEntity.OnAddingImg()),
            new InfoButton("Удалить изображения").CommandClick(() => e.Data.RepositoryImgEntity.OnDeletingImg()),
            new InfoButton("Обновить расписание").CommandClick(() => new LessonScheduleView(e.Data).ShowDialog()),
            new InfoButton("Удалить").CommandClick(() =>
            {
                if (!LogicaMessage.MessageOkCancel("Вы дейсвительно хотите удалть?")) return;
                repository.Delete(e.Data.Entity.Id);
                controlView.Exit();
            }),
        ];
}