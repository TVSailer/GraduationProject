using Admin.DI.Module;
using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;
using UserInterface.UiLayoutPanel.ButtonPanel;
using UserInterface.UiLayoutPanel.CardPanel.Args;
using UserInterface.View;

namespace Admin.FieldData.Model.Visitor.Buttons;

public class VisitorBelongingLessonButton(
    ControlView controlView, 
    VisitorFieldData fieldData,
    VisitorNotBelongingLesson visitorNotBelongingLesson,
    MementoLesson v) : 
    IButtons<VisitorBelongingLesson>, 
    IButtons<CardClickedToolStripArgs<VisitorEntity>>
{
    public List<CustomButton> GetButtons(VisitorBelongingLesson e)
        =>
        [
            new CustomButton("Назад").CommandClick(controlView.Exit),
            new CustomButton("Добавить нового")
                .Enable(v.IsAdd)
                .CommandClick(() => controlView.LoadView(fieldData)),
            new CustomButton("Добавить существуещегося")
                .Enable(v.IsAdd)
                .CommandClick(() => controlView.LoadView(visitorNotBelongingLesson)),
        ];

    public List<CustomButton> GetButtons(CardClickedToolStripArgs<VisitorEntity> e)
        => [
            new CustomButton("Удалить")
                .CommandClick(() =>
                {
                    v.DeleteVisitor(e.Entity.Id);
                    controlView.UpdateGUI();
                }),
        ];
}