using Admin.Args;
using Admin.DI;
using Admin.View;
using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;
using Logica.Interface;
using Logica.UI;

namespace Admin.ViewModel.Model.Visitor.Buttons;

public class VisitorBelongingLessonButton(ControlView controlView, MementoLesson v) : IButtons<ViewButtonClickArgs<VisitorBelongingLesson>>, IButtons<CardClickedToolStripArgs<VisitorEntity>>
{
    public List<CustomButton> GetButtons(object? data, ViewButtonClickArgs<VisitorBelongingLesson>? e)
        =>
        [
            new CustomButton("Назад").CommandClick(controlView.Exit),
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
                    if (e == null) return;
                    v.DeleteVisitor(e.Entity.Id);
                    controlView.UpdateGUI();
                }),
        ];
}