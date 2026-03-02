using DataAccess.Postgres.Repository;
using UserInterface.UiLayoutPanel.ButtonPanel;
using UserInterface.View;
using Validaiger.Message;

namespace Admin.FieldData.Model.Visitor.Buttons;

public class VisitorAddingButton(MementoLesson mementoLesson, ControlView controlView) : IButtons<VisitorFieldData>
{
    public List<CustomButton> GetButtons(VisitorFieldData e)
        => [
            new CustomButton("Назад")
                .CommandClick(controlView.Exit),
            new CustomButton("Сохранить")
                .CommandClick(() => e.ValidObject((id, entity) =>
                {
                    mementoLesson.AddNewVisitor(entity, out var logger);
                    LogicaMessage.MessageInfo(logger.Log);
                    controlView.Exit();
                })),
        ];
}