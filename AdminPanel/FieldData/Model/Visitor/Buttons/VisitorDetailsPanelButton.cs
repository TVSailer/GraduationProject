using DataAccess.PostgreSQL.Models;
using DataAccess.PostgreSQL.Repository;
using UserInterface.Message;
using UserInterface.UiLayoutPanel.ButtonPanel;
using UserInterface.View;

namespace Admin.FieldData.Model.Visitor.Buttons;

public class VisitorDetailsButton(
    Repository<VisitorEntity> repository,
    ControlView controlView) : IButtons<VisitorFieldData>
{
    public List<CustomButton> GetButtons(VisitorFieldData fieldData)
        => [
            new CustomButton("Назад").CommandClick(controlView.Exit),
            new CustomButton("Обновить").CommandClick(() => fieldData.ValidObject((id, entity) =>
            {
                repository.Update(entity.Id, entity);
                controlView.Exit();
            })),
            new CustomButton("Удалить").CommandClick(() =>
            {
                if(! LogicaMessage.MessageOkCancel("Вы дейсвительно хотите удалть?")) return;
                repository.Delete(fieldData.EntityId);
                controlView.Exit();
            })
        ];
}

