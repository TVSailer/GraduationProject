using Admin.Args;
using Admin.DI;
using Admin.View;
using Admin.ViewModel.Interface;
using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;

namespace Admin.ViewModel.Model.Lesson.Buttons;

public class LessonManagmentButton(ControlView controlView, MementoLesson v) : 
    IButtons<ViewButtonClickArgs<LessonManagment>>,
    IButtons<CardClickedToolStripArgs<LessonEntity>>, 
    IButton<CardClickedArgs<LessonEntity>>
{
    public List<CustomButton> GetButtons(object? data, CardClickedToolStripArgs<LessonEntity> eventToolStripArgs)
        => [
            new CustomButton("Управление поситителями")
                .CommandClick(() => ControlVisitors<VisitorBelongingLesson>(eventToolStripArgs.Entity)),
            new CustomButton("Управление посещаемостью")
                .CommandClick(() => controlView.Exit()),
            new CustomButton("Управление отзывами")
                .CommandClick(() => ControlVisitors<ReviewManagment>(eventToolStripArgs.Entity)),
        ];

    public List<CustomButton> GetButtons(object? data, ViewButtonClickArgs<LessonManagment> eventArgs)
        => [
            new CustomButton("Назад")
                .CommandClick(() => controlView.Exit()),
            new CustomButton("Добавить")
                .CommandClick(() => controlView.LoadView<LessonAddingFieldData>()),
        ];

    public CustomButton? GetButton(object? send, CardClickedArgs<LessonEntity> eventArgs)
        => new CustomButton()
            .CommandClick(() => controlView.LoadView<LessonDetailsFieldData, LessonEntity>(eventArgs.Entity));

    private void ControlVisitors<T>(LessonEntity arg2FieldData) where T : IFieldData
    {
        v.Lesson = arg2FieldData;
        controlView.LoadView<T>();
    }
}

