using Admin.DI;
using DataAccess.PostgreSQL.Models;
using DataAccess.PostgreSQL.Repository;
using UserInterface.UiLayoutPanel.ButtonPanel;
using UserInterface.View;

namespace Admin.FieldData.Model.Event.Buttons;

public class EventAddingButton(ControlView controlView, Repository<EventEntity> repository) : 
    IButtons<EventFieldData>
{
    public List<CustomButton> GetButtons(EventFieldData e)
        => [
           new CustomButton("Сохранить").CommandClick(() => e.ValidObject((_, entity) =>
                {
                    repository.Add(entity);
                    controlView.Exit();
                })),
            new CustomButton("Добавить изображение").CommandClick(() => e.RepositoryImgEntity.OnAddingImg()),
            new CustomButton("Удалить изображение").CommandClick(() => e.RepositoryImgEntity.OnDeletingImg()),
            new CustomButton("Назад").CommandClick(controlView.Exit),
        ];
}