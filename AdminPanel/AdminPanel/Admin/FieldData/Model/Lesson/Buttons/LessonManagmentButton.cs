using Admin.DI.Module;
using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;
using UserInterface.UiLayoutPanel.ButtonPanel;
using UserInterface.UiLayoutPanel.CardPanel.Args;
using UserInterface.View;

namespace Admin.ViewModel.Model.Lesson.Buttons;

public class LessonManagerButton(
    ControlView controlView, 
    MementoLesson v) :
    IButtons<LessonManager>,
    IButtons<CardClickedToolStripArgs<LessonEntity>>,
    IButton<CardClickedArgs<LessonEntity>>
{
    public List<CustomButton> GetButtons(CardClickedToolStripArgs<LessonEntity>? eventToolStripArgs)
        =>
        [
            new CustomButton("Управление поситителями").CommandClick(() => ControlLesson<DateAttendanceManager>(eventToolStripArgs?.Entity)),
            new CustomButton("Управление посещаемостью").CommandClick(() => ControlLesson<VisitorBelongingLesson>(eventToolStripArgs?.Entity)),
            new CustomButton("Управление отзывами").CommandClick(() => ControlLesson<ReviewManager>(eventToolStripArgs?.Entity)),
        ];

    public List<CustomButton> GetButtons(LessonManager? eventArgs)
        =>
        [
            new CustomButton("Назад").CommandClick(controlView.Exit),
            new CustomButton("Добавить").CommandClick(() => controlView.LoadView<LessonFieldData>()),
        ];

    public CustomButton GetButton(CardClickedArgs<LessonEntity> eventArgs)
        => new CustomButton().CommandClick(() => controlView.LoadView<LessonFieldData, LessonEntity>(eventArgs.Entity));

    private void ControlLesson<T>(LessonEntity? arg2FieldData)
    {
        v.Lesson = arg2FieldData;
        controlView.LoadView<T>();
    }
}