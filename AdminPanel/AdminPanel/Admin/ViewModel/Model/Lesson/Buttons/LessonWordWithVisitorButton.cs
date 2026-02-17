using Admin.Args;
using Admin.DI;
using Admin.View;
using Admin.ViewModel.Interface;
using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;

namespace Admin.ViewModel.Model.Lesson.Buttons;

public class VisitorBelongingLessonButton(ControlView controlView, VisitorsLessonRepository repositoryV) : IButtons<ViewButtonClickArgs<VisitorBelongingLesson>>, IButtons<CardClickedArgs<VisitorEntity>>
{
    public List<CustomButton> GetButtons(object? data, ViewButtonClickArgs<VisitorBelongingLesson>? e)
        =>
        [
            new CustomButton("Назад")
                .CommandClick(() => controlView.Exit()),
            new CustomButton("Добавить нового")
                .Enablede(repositoryV.IsAdd)
                .CommandClick(() => controlView.LoadView<VisitorAddingFieldData>()),
            new CustomButton("Добавить существуещегося")
                .Enablede(repositoryV.IsAdd)
                .CommandClick(() => controlView.LoadView<VisitorNotBelongingLessonCardPanelUi>()),
        ];

    public List<CustomButton> GetButtons(object? data, CardClickedArgs<VisitorEntity>? e)
        => [
            new CustomButton("Удалить")
                .CommandClick(() =>
                {
                    repositoryV.Delete(e.Entity.Id);
                    controlView.UpdateGUI();
                }),
        ];
}