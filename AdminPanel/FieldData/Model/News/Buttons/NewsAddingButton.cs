using DataAccess.PostgreSQL.Models;
using DataAccess.PostgreSQL.Repository;
using UserInterface.UiLayoutPanel.ButtonPanel;
using UserInterface.View;

namespace Admin.FieldData.Model.News.Buttons;

public class NewsAddingButton(
    ControlView controlView, 
    Repository<NewsEntity> repository) : IButtons<NewsFieldData>
{
    public List<CustomButton> GetButtons(NewsFieldData fieldData)
        => [
            new CustomButton("Сохранить").CommandClick(() => fieldData.ValidObject((_, entity) =>
                {
                    repository.Add(entity);
                    controlView.Exit();
                })),
            new CustomButton("Добавить изображение").CommandClick(() => fieldData.RepositoryImgEntity.OnAddingImg()),
            new CustomButton("Удалить изображение").CommandClick(() => fieldData.RepositoryImgEntity.OnDeletingImg()),
            new CustomButton("Назад").CommandClick(controlView.Exit),
        ];
}