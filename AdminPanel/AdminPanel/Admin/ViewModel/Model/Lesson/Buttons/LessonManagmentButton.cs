using Admin.Args;
using Admin.DI;
using Admin.DI.Module;
using Admin.View;
using Admin.ViewModel.Interface;
using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;
using User_Interface_Library.UiLayoutPanel.ButtonPanel;
using User_Interface_Library.UiLayoutPanel.CardPanel.Args;
using User_Interface_Library.View;

namespace Admin.ViewModel.Model.Lesson.Buttons;

public class LessonManagmentButton(ControlView controlView, MementoLesson v) : 
    IButtons<LessonManagment>,
    IButtons<CardClickedToolStripArgs<LessonEntity>>, 
    IButton<CardClickedArgs<LessonEntity>>
{
    public List<CustomButton> GetButtons(CardClickedToolStripArgs<LessonEntity>? eventToolStripArgs)
        => [
            //new CustomButton("Управление поситителями").CommandClick(() => ControlLesson<VisitorBelongingLesson>(eventToolStripArgs?.Entity)),
            //new CustomButton("Управление посещаемостью").CommandClick(() => ControlLesson<DateAttendanceManagment>(eventToolStripArgs?.Entity)),
            //new CustomButton("Управление отзывами").CommandClick(() => ControlLesson<ReviewManagment>(eventToolStripArgs?.Entity)),
        ];

    public List<CustomButton> GetButtons(LessonManagment? eventArgs)
        => [
            new CustomButton("Назад").CommandClick(controlView.Exit),
            new CustomButton("Добавить").CommandClick(() => controlView.LoadView<LessonFieldData>()),
        ];

    public CustomButton GetButton(CardClickedArgs<LessonEntity> eventArgs)
        => new CustomButton().CommandClick(() => controlView
            .LoadView<LessonFieldData, LessonEntity>().FieldData.MementoEntity
            .SetData(eventArgs.obj));

    private void ControlLesson<T>(LessonEntity? arg2FieldData) where T : IFieldData
    {
        v.Lesson = arg2FieldData;
        controlView.LoadView<T>();
    }
}