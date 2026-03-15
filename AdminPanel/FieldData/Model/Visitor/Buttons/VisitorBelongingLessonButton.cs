using Admin.DI.Module;
using DataAccess.PostgreSQL.Models;
using DataAccess.PostgreSQL.Repository;
using UserInterface.Info;
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
    IToolStrip<VisitorEntity>
{
    public InfoButton[] GetButtons(ClickedArgs<VisitorBelongingLesson> e)
        =>
        [
            new InfoButton("Назад").CommandClick(controlView.Exit),
            new InfoButton("Добавить нового")
                .Enable(v.IsAddVisitor)
                .CommandClick(() => controlView.LoadView(fieldData)),
            new InfoButton("Добавить существуещегося")
                .Enable(v.IsAddVisitor)
                .CommandClick(() => controlView.LoadView(visitorNotBelongingLesson)),
        ];

    public InfoToolStrip[] GetToolStrip(CardClickedToolStripArgs<VisitorEntity> e)
        => [
            new InfoToolStrip("Удалить")
                .CommandClick(() =>
                {
                    v.DeleteVisitor(e.Data.Id);
                    controlView.UpdateGUI();
                }),
        ];
}