using AbstractView.View;
using DataAccess.PostgreSQL.ModelsPrimitive;
using DataAccess.PostgreSQL.Repository;
using UserInterface.Info;
using UserInterface.UiLayoutPanel.ButtonPanel;
using UserInterface.UiLayoutPanel.CardPanel.Args;
using UserInterface.View;

namespace Admin.FieldData.Model.News.Buttons;

public class NewsAddingButton(
    ControlView controlView, 
    Repository<NewsEntity> repository) : IButtons<NewsFieldData>
{
    public InfoButton[] GetButtons(ClickedArgs<NewsFieldData> fieldData)
        => [
            new InfoButton("Сохранить").CommandClick(() => fieldData.Data.ValidObject((_, entity) =>
                {
                    repository.Add(entity);
                    controlView.Exit();
                })),
            new InfoButton("Добавить изображение").CommandClick(() => fieldData.Data.RepositoryImgEntity.OnAddingImg()),
            new InfoButton("Удалить изображение").CommandClick(() => fieldData.Data.RepositoryImgEntity.OnDeletingImg()),
            new InfoButton("Назад").CommandClick(controlView.Exit),
        ];
}