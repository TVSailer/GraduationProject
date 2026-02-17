using Admin.Args;
using Admin.View;
using Admin.ViewModel.Interface;
using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;

namespace Admin.ViewModel.Model.Lesson.Buttons;

public class LessonManagmentButton(ControlView controlView, VisitorsLessonRepository repositoryV) : 
    IButtons<ViewButtonClickArgs<LessonMangment>>,
    IButtons<CardClickedArgs<LessonEntity>>
{
    public List<CustomButton> GetButtons(object? data, CardClickedArgs<LessonEntity> eventArgs)
        => [
            new CustomButton("Управление поситителями")
                .CommandClick(() => ControlVisitors(eventArgs.Entity)),
            new CustomButton("Управление посещаемостью")
                .CommandClick(() => controlView.Exit()),
            new CustomButton("Управление отзывами")
                .CommandClick(() => controlView.Exit()),
        ];

    public List<CustomButton> GetButtons(object? data, ViewButtonClickArgs<LessonMangment> eventArgs)
        => [
            new CustomButton("Назад")
                .CommandClick(() => controlView.Exit()),
            new CustomButton("Добавить")
                .CommandClick(() => controlView.LoadView<LessonAddingFieldData>()),
        ];

    private void ControlVisitors(LessonEntity arg2FieldData)
    {
        repositoryV.Lesson = arg2FieldData;
        controlView.LoadView<VisitorBelongingLesson>();
    }
}

