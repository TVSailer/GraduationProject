using Admin.Args;
using Admin.DI;
using Admin.View;
using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;
using Logica.Interface;
using Logica.UI;

namespace Admin.ViewModel.Model.Visitor.Buttons;

public class VisitorDetailsButton(
    Repository<VisitorEntity> repository,
    ControlView controlView) : IButtons<ViewButtonClickArgs<VisitorEntity, VisitorDetailsFieldData>>
{
    public List<CustomButton> GetButtons(object? data, ViewButtonClickArgs<VisitorEntity, VisitorDetailsFieldData> e)
        => [
            new CustomButton("Назад").CommandClick(controlView.Exit),
            new CustomButton("Обновить").CommandClick(() => e.FieldData.TryWordWithEntity(entity =>
            {
                repository.Update(entity.Id, entity.GetDataNotNull());
                controlView.Exit();
            })),
            new CustomButton("Удалить").CommandClick(() =>
            {
                repository.Delete(e.FieldData.Entity.Id);
                controlView.Exit();
            })
        ];
}

