using Admin.Args;
using Admin.View;
using DataAccess.Postgres.Repository;
using Logica.Interface;
using Logica.UI;

namespace Admin.ViewModel.Model.Review.Buttons;

public class ReviewDetailsButton(
    Repository<ReviewEntity> repository,
    ControlView controlView) : 
    IButtons<ViewButtonClickArgs<ReviewEntity, ReviewFieldData>>
{
    public List<CustomButton> GetButtons(object? send, ViewButtonClickArgs<ReviewEntity, ReviewFieldData> e)
        => [
            new CustomButton("Назад").CommandClick(controlView.Exit),
            new CustomButton("Удалить").CommandClick(() =>
            {
                repository.Delete(e.FieldData.Entity.Id);
                controlView.Exit();
            })
        ];
}