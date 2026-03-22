using Admin.DI.Module;
using Admin.ViewModel.Model.Lesson;
using DataAccess.PostgreSQL.Memento;
using DataAccess.PostgreSQL.ModelsPrimitive;
using DataAccess.PostgreSQL.Repository;
using UserInterface.Info;
using UserInterface.Message;
using UserInterface.UiLayoutPanel.ButtonPanel;
using UserInterface.UiLayoutPanel.CardPanel.Args;
using UserInterface.View;

namespace Admin.FieldData.Model.Lesson.Buttons;

public class LessonManagerClicked(
    ControlView controlView, 
    MementoLesson mementoLesson) :
    IToolStrip<LessonEntity>,
    IButtons<LessonManager>,
    IClicked<LessonEntity>
{
    public InfoToolStrip[] GetToolStrip(CardClickedToolStripArgs<LessonEntity>? eventToolStripArgs)
        =>
        [
            new InfoToolStrip("Управление поситителями").CommandClick(() => ControlLesson<VisitorBelongingLesson>(eventToolStripArgs?.Data)),
            new InfoToolStrip("Управление посещаемостью").CommandClick(() => ControlLesson<DateAttendanceManager>(eventToolStripArgs?.Data)),
            new InfoToolStrip("Управление отзывами").CommandClick(() => ControlLesson<ReviewManager>(eventToolStripArgs?.Data)),
        ];

    public InfoButton[] GetButtons(ClickedArgs<LessonManager> eventArgs)
        =>
        [
            new InfoButton("Назад").CommandClick(controlView.Exit),
            new InfoButton("Добавить").CommandClick(() =>
            {
                if (mementoLesson.TryAddLesson(out var logger))
                {
                    controlView.LoadView<LessonFieldData>();
                    return;
                }
                LogicaMessage.MessageError(logger.Log);
            }),
        ];

    public InfoButton GetButton(CardClickedArgs<LessonEntity> eventArgs)
        => new InfoButton().CommandClick(() => controlView.LoadView<LessonFieldData, LessonEntity>(eventArgs.Entity));

    private void ControlLesson<T>(LessonEntity? arg2FieldData)
    {
        mementoLesson.Lesson = arg2FieldData;
        controlView.LoadView<T>();
    }
}