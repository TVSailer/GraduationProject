using DataAccess.PostgreSQL.Models;
using DataAccess.PostgreSQL.Repository;
using UserInterface.Message;
using UserInterface.UiLayoutPanel.ButtonPanel;
using UserInterface.View;

namespace Admin.FieldData.Model.Event.Buttons;

public class EventDetailsButton(
    Repository<EventEntity> repository,
    ControlView controlView) : IButtons<EventFieldData>
{
    public List<CustomButton> GetButtons(EventFieldData fieldData)
        =>
        [
            new CustomButton("Назад").CommandClick(controlView.Exit),
            new CustomButton("Обновить").CommandClick(() => fieldData.ValidObject((id, entity) =>
                {
                    repository.Update(entity.Id, entity);
                    controlView.Exit();
                })),
            new CustomButton("Добавить изображение").CommandClick(() => fieldData.RepositoryImgEntity.OnAddingImg()),
            new CustomButton("Удалить изображения").CommandClick(() => fieldData.RepositoryImgEntity.OnDeletingImg()),
            new CustomButton("Удалить").CommandClick(() =>
                {
                    if (!LogicaMessage.MessageOkCancel("Вы дейсвительно хотите удалть?")) return;
                    repository.Delete(fieldData.EntityId);
                    controlView.Exit();
                }),
        ];
}