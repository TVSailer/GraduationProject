using DataAccess.PostgreSQL.Models;
using DataAccess.PostgreSQL.Repository;
using UserInterface.Info;
using UserInterface.UiLayoutPanel.ButtonPanel;
using UserInterface.View;

namespace Admin.FieldData.Model.News.Buttons;

public class NewsAddingButton(
    ControlView controlView, 
    Repository<NewsEntity> repository) : IButtons<NewsFieldData>
{
    public List<InfoButton> GetButtons(NewsFieldData fieldData)
        => [
            new InfoButton("Сохранить").CommandClick(() => fieldData.ValidObject((_, entity) =>
                {
                    repository.Add(entity);
                    controlView.Exit();
                })),
            new InfoButton("Добавить изображение").CommandClick(() => fieldData.RepositoryImgEntity.OnAddingImg()),
            new InfoButton("Удалить изображение").CommandClick(() => fieldData.RepositoryImgEntity.OnDeletingImg()),
            new InfoButton("Назад").CommandClick(controlView.Exit),
        ];
}