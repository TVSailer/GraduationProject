using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;
using UserInterface.Message;
using UserInterface.UiLayoutPanel.ButtonPanel;
using UserInterface.View;

namespace Admin.FieldData.Model.News.Buttons;

public class NewsDetailsButton(
    ControlView controlView,
    Repository<NewsEntity> repository) : IButtons<NewsFieldData>
{
    public List<CustomButton> GetButtons(NewsFieldData fieldData)
        =>
        [
            new CustomButton("Назад").CommandClick(controlView.Exit),
            new CustomButton("Обновить").CommandClick(() => fieldData.ValidObject((_, entity)=>
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