using DataAccess.PostgreSQL.Models;
using DataAccess.PostgreSQL.Repository;
using UserInterface.Info;
using UserInterface.Message;
using UserInterface.UiLayoutPanel.ButtonPanel;
using UserInterface.UiLayoutPanel.CardPanel.Args;
using UserInterface.View;

namespace Admin.FieldData.Model.Event.Buttons;

public class EventDetailsButton(
    Repository<EventEntity> repository,
    ControlView controlView) : IButtons<EventFieldData>
{
    public InfoButton[] GetButtons(ClickedArgs<EventFieldData> fieldData)
        =>
        [
            new InfoButton("Назад").CommandClick(controlView.Exit),
            new InfoButton("Обновить").CommandClick(() => fieldData.Data.ValidObject((id, entity) =>
                {
                    repository.Update(entity.Id, entity);
                    controlView.Exit();
                })),
            new InfoButton("Добавить изображение").CommandClick(() => fieldData.Data.RepositoryImgEntity.OnAddingImg()),
            new InfoButton("Удалить изображения").CommandClick(() => fieldData.Data.RepositoryImgEntity.OnDeletingImg()),
            new InfoButton("Удалить").CommandClick(() =>
                {
                    if (!LogicaMessage.MessageOkCancel("Вы дейсвительно хотите удалть?")) return;
                    repository.Delete(fieldData.Data.EntityId);
                    controlView.Exit();
                }),
        ];
}