using Admin.DI.Module;
using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;
using UserInterface.UiLayoutPanel.ButtonPanel;
using UserInterface.UiLayoutPanel.CardPanel.Args;
using UserInterface.View;

namespace Admin.ViewModel.Model.Lesson.Buttons;

public class LessonManagerButton(
    ControlView controlView, 
    LessonFieldData fieldData,
    VisitorBelongingLesson visitorBelongingLesson,
    DateAttendanceManager dateAttendanceManager,
    ReviewManager reviewManager,
    MementoLesson v) :
    IButtons<LessonManager>,
    IButtons<CardClickedToolStripArgs<LessonEntity>>,
    IButton<CardClickedArgs<LessonEntity>>
{
    public List<CustomButton> GetButtons(CardClickedToolStripArgs<LessonEntity>? eventToolStripArgs)
        =>
        [
            new CustomButton("Управление поситителями").CommandClick(() => ControlLesson(visitorBelongingLesson, eventToolStripArgs?.Entity)),
            new CustomButton("Управление посещаемостью").CommandClick(() => ControlLesson(dateAttendanceManager, eventToolStripArgs?.Entity)),
            new CustomButton("Управление отзывами").CommandClick(() => ControlLesson(reviewManager, eventToolStripArgs?.Entity)),
        ];

    public List<CustomButton> GetButtons(LessonManager? eventArgs)
        =>
        [
            new CustomButton("Назад").CommandClick(controlView.Exit),
            new CustomButton("Добавить").CommandClick(() => controlView.LoadView<LessonFieldData>(fieldData)),
        ];

    public CustomButton GetButton(CardClickedArgs<LessonEntity> eventArgs)
        => new CustomButton().CommandClick(() =>
        {
            fieldData.Entity = eventArgs.Entity;
            controlView.LoadView<LessonFieldData, LessonEntity>(fieldData);
        });

    private void ControlLesson<T>(T fieldData, LessonEntity? arg2FieldData)
    {
        v.Lesson = arg2FieldData;
        controlView.LoadView(fieldData);
    }
}