using Admin.DI.Module;
using DataAccess.PostgreSQL.Models;
using DataAccess.PostgreSQL.Repository;
using UserInterface.Message;
using UserInterface.UiLayoutPanel.ButtonPanel;
using UserInterface.UiLayoutPanel.CardPanel.Args;
using UserInterface.View;

namespace Admin.ViewModel.Model.Lesson.Buttons;

public class LessonManagerButton(
    ControlView controlView, 
    MementoLesson mementoLesson) :
    IButtons<LessonManager>,
    IButtons<CardClickedToolStripArgs<LessonEntity>>,
    IButton<CardClickedArgs<LessonEntity>>
{
    public List<CustomButton> GetButtons(CardClickedToolStripArgs<LessonEntity>? eventToolStripArgs)
        =>
        [
            new CustomButton("Управление поситителями").CommandClick(() => ControlLesson<VisitorBelongingLesson>(eventToolStripArgs?.Entity)),
            new CustomButton("Управление посещаемостью").CommandClick(() => ControlLesson<DateAttendanceManager>(eventToolStripArgs?.Entity)),
            new CustomButton("Управление отзывами").CommandClick(() => ControlLesson<ReviewManager>(eventToolStripArgs?.Entity)),
        ];

    public List<CustomButton> GetButtons(LessonManager? eventArgs)
        =>
        [
            new CustomButton("Назад").CommandClick(controlView.Exit),
            new CustomButton("Добавить").CommandClick(() =>
            {
                if (mementoLesson.TryAddLesson(out var logger))
                {
                    controlView.LoadView<LessonFieldData>();
                    return;
                }
                LogicaMessage.MessageError(logger.Log);
            }),
        ];

    public CustomButton GetButton(CardClickedArgs<LessonEntity> eventArgs)
        => new CustomButton().CommandClick(() => controlView.LoadView<LessonFieldData, LessonEntity>(eventArgs.Entity));

    private void ControlLesson<T>(LessonEntity? arg2FieldData)
    {
        mementoLesson.Lesson = arg2FieldData;
        controlView.LoadView<T>();
    }
}