using DataAccess.PostgreSQL.Models;
using DataAccess.PostgreSQL.Repository;
using UserInterface.Info;
using UserInterface.UiLayoutPanel.ButtonPanel;
using UserInterface.UiLayoutPanel.CardPanel.Args;
using UserInterface.View;

namespace Admin.FieldData.Model.Event.Buttons;

public class EventAddingButton(ControlView controlView, Repository<EventEntity> repository) : 
    IButtons<EventFieldData>
{
    public InfoButton[] GetButtons(ClickedArgs<EventFieldData> e)
        => [
           new InfoButton("Сохранить").CommandClick(() => e.Data.ValidObject((_, entity) =>
                {
                    repository.Add(entity);
                    controlView.Exit();
                })),
            new InfoButton("Добавить изображение").CommandClick(() => e.Data.RepositoryImgEntity.OnAddingImg()),
            new InfoButton("Удалить изображение").CommandClick(() => e.Data.RepositoryImgEntity.OnDeletingImg()),
            new InfoButton("Назад").CommandClick(controlView.Exit),
        ];
}