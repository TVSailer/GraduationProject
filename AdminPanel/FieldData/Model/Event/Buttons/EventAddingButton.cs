using Admin.DI;
using DataAccess.PostgreSQL.Models;
using DataAccess.PostgreSQL.Repository;
using UserInterface.Info;
using UserInterface.UiLayoutPanel.ButtonPanel;
using UserInterface.View;

namespace Admin.FieldData.Model.Event.Buttons;

public class EventAddingButton(ControlView controlView, Repository<EventEntity> repository) : 
    IButtons<EventFieldData>
{
    public List<InfoButton> GetButtons(EventFieldData e)
        => [
           new InfoButton("Сохранить").CommandClick(() => e.ValidObject((_, entity) =>
                {
                    repository.Add(entity);
                    controlView.Exit();
                })),
            new InfoButton("Добавить изображение").CommandClick(() => e.RepositoryImgEntity.OnAddingImg()),
            new InfoButton("Удалить изображение").CommandClick(() => e.RepositoryImgEntity.OnDeletingImg()),
            new InfoButton("Назад").CommandClick(controlView.Exit),
        ];
}