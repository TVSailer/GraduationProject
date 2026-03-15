using Admin.DI.Module;
using Admin.ViewModel.Model.Lesson;
using DataAccess.PostgreSQL.Models;
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
    IButtons<LessonManager>,
    IButtons<CardClickedToolStripArgs<LessonEntity>>,
    IClicked<CardClickedArgs<LessonEntity>>
{
    public List<InfoButton> GetButtons(CardClickedToolStripArgs<LessonEntity>? eventToolStripArgs)
        =>
        [
            new InfoButton("Управление поситителями").CommandClick(() => ControlLesson<VisitorBelongingLesson>(eventToolStripArgs?.Data)),
            new InfoButton("Управление посещаемостью").CommandClick(() => ControlLesson<DateAttendanceManager>(eventToolStripArgs?.Data)),
            new InfoButton("Управление отзывами").CommandClick(() => ControlLesson<ReviewManager>(eventToolStripArgs?.Data)),
        ];

    public List<InfoButton> GetButtons(LessonManager? eventArgs)
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