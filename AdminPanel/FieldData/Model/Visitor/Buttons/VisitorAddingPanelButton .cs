using DataAccess.PostgreSQL.Memento;
using DataAccess.PostgreSQL.Repository;
using UserInterface.Info;
using UserInterface.Message;
using UserInterface.UiLayoutPanel.ButtonPanel;
using UserInterface.UiLayoutPanel.CardPanel.Args;
using UserInterface.View;

namespace Admin.FieldData.Model.Visitor.Buttons;

public class VisitorAddingButton(MementoLesson mementoLesson, ControlView controlView) : IButtons<VisitorFieldData>
{
    public InfoButton[] GetButtons(ClickedArgs<VisitorFieldData> e)
        => [
            new InfoButton("Назад")
                .CommandClick(controlView.Exit),
            new InfoButton("Сохранить")
                .CommandClick(() => e.Data.ValidObject((id, entity) =>
                {
                    mementoLesson.AddNewVisitor(entity, out var logger);
                    LogicaMessage.MessageInfo(logger.Log);
                    controlView.Exit();
                })),
        ];
}