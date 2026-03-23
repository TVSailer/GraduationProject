using DataAccess.PostgreSQL.ModelsPrimitive;
using DataAccess.PostgreSQL.Repository;
using UserInterface.Info;
using UserInterface.Message;
using UserInterface.UiLayoutPanel.ButtonPanel;
using UserInterface.UiLayoutPanel.CardPanel.Args;
using UserInterface.View;

namespace Admin.FieldData.Model.Visitor.Buttons;

public class VisitorDetailsButton(
    Repository<VisitorEntity> repository,
    ControlView controlView) : IButtons<VisitorFieldData>
{
    public InfoButton[] GetButtons(ClickedArgs<VisitorFieldData> fieldData)
        => [
            new InfoButton("Назад").CommandClick(controlView.Exit),
            new InfoButton("Обновить").CommandClick(() => fieldData.Data.ValidObject((id, entity) =>
            {
                repository.Update(entity.Id, entity);
                controlView.Exit();
            })),
            new InfoButton("Удалить").CommandClick(() =>
            {
                if(! LogicaMessage.MessageOkCancel("Вы дейсвительно хотите удалть?")) return;
                repository.Delete(fieldData.Data.EntityId);
                controlView.Exit();
            })
        ];
}

