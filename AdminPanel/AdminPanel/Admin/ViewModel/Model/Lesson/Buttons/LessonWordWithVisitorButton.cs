using Admin.Args;
using Admin.DI;
using Admin.View;
using Admin.ViewModel.Interface;
using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;

namespace Admin.ViewModel.Model.Lesson.Buttons;

public class VisitorBelongingLessonButton(ControlView controlView, MementoLesson v) : IButtons<ViewButtonClickArgs<VisitorBelongingLesson>>, IButtons<CardClickedToolStripArgs<VisitorEntity>>
{
    public List<CustomButton> GetButtons(object? data, ViewButtonClickArgs<VisitorBelongingLesson>? e)
        =>
        [
            new CustomButton("Назад")
                .CommandClick(() => controlView.Exit()),
            new CustomButton("Добавить нового")
                .Enablede(v.IsAdd)
                .CommandClick(() => controlView.LoadView<VisitorAddingFieldData>()),
            new CustomButton("Добавить существуещегося")
                .Enablede(v.IsAdd)
                .CommandClick(() => controlView.LoadView<VisitorNotBelongingLessonCardPanelUi>()),
        ];

    public List<CustomButton> GetButtons(object? data, CardClickedToolStripArgs<VisitorEntity>? e)
        => [
            new CustomButton("Удалить")
                .CommandClick(() =>
                {
                    v.DeleteVisitor(e.Entity.Id);
                    controlView.UpdateGUI();
                }),
        ];
}