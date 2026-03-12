using DataAccess.PostgreSQL.Models;
using DataAccess.PostgreSQL.Repository;
using UserInterface.Info;
using UserInterface.Message;
using UserInterface.UiLayoutPanel.ButtonPanel;
using UserInterface.View;

namespace Admin.FieldData.Model.Visitor.Buttons;

public class VisitorDetailsButton(
    Repository<VisitorEntity> repository,
    ControlView controlView) : IButtons<VisitorFieldData>
{
    public List<InfoButton> GetButtons(VisitorFieldData fieldData)
        => [
            new InfoButton("Назад").CommandClick(controlView.Exit),
            new InfoButton("Обновить").CommandClick(() => fieldData.ValidObject((id, entity) =>
            {
                repository.Update(entity.Id, entity);
                controlView.Exit();
            })),
            new InfoButton("Удалить").CommandClick(() =>
            {
                if(! LogicaMessage.MessageOkCancel("Вы дейсвительно хотите удалть?")) return;
                repository.Delete(fieldData.EntityId);
                controlView.Exit();
            })
        ];
}

