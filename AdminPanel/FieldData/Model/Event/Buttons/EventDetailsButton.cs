using DataAccess.PostgreSQL.Models;
using DataAccess.PostgreSQL.Repository;
using UserInterface.Info;
using UserInterface.Message;
using UserInterface.UiLayoutPanel.ButtonPanel;
using UserInterface.View;

namespace Admin.FieldData.Model.Event.Buttons;

public class EventDetailsButton(
    Repository<EventEntity> repository,
    ControlView controlView) : IButtons<EventFieldData>
{
    public List<InfoButton> GetButtons(EventFieldData fieldData)
        =>
        [
            new InfoButton("Назад").CommandClick(controlView.Exit),
            new InfoButton("Обновить").CommandClick(() => fieldData.ValidObject((id, entity) =>
                {
                    repository.Update(entity.Id, entity);
                    controlView.Exit();
                })),
            new InfoButton("Добавить изображение").CommandClick(() => fieldData.RepositoryImgEntity.OnAddingImg()),
            new InfoButton("Удалить изображения").CommandClick(() => fieldData.RepositoryImgEntity.OnDeletingImg()),
            new InfoButton("Удалить").CommandClick(() =>
                {
                    if (!LogicaMessage.MessageOkCancel("Вы дейсвительно хотите удалть?")) return;
                    repository.Delete(fieldData.EntityId);
                    controlView.Exit();
                }),
        ];
}