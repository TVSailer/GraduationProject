using Admin.Args;
using Admin.DI;
using Admin.View;
using Admin.ViewModel.Interface;
using Admin.ViewModel.Managment;
using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;

namespace Admin.ViewModel.Model.Lesson.Buttons;

public class VisitorBelongingLessonButton(ControlView controlView, VisitorsLessonRepository repositoryV) : IButtons<ViewButtonClickArgs<VisitorBelongingLesson>>, IButtons<CardClickedArgs<VisitorEntity>>
{
    List<CustomButton<ViewButtonClickArgs<VisitorBelongingLesson>>> IButtons<ViewButtonClickArgs<VisitorBelongingLesson>>.GetButtons(object? data = null)
        =>
        [
            new CustomButton<ViewButtonClickArgs<VisitorBelongingLesson>>()
                .LabelText("Назад")
                .CommandClick((_, _) => controlView.Exit()),
            new CustomButton<ViewButtonClickArgs<VisitorBelongingLesson>>()
                .LabelText("Добавить нового")
                .Enablede(repositoryV.IsAdd)
                .CommandClick((_, _) => controlView.LoadView<VisitorAddingFieldData>()),
            new CustomButton<ViewButtonClickArgs<VisitorBelongingLesson>>()
                .LabelText("Добавить существуещегося")
                .Enablede(repositoryV.IsAdd)
                .CommandClick((_, _) => controlView.LoadView<VisitorNotBelongingLessonCardPanelUi>()),
        ];

    List<CustomButton<CardClickedArgs<VisitorEntity>>> IButtons<CardClickedArgs<VisitorEntity>>.GetButtons(object? data)
        => [
            new CustomButton<CardClickedArgs<VisitorEntity>>()
                .LabelText("Удалить")
                .CommandClick((_, e) =>
                {
                    repositoryV.Delete(e.Entity.Id);
                    controlView.UpdateGUI();
                }),
        ];
}