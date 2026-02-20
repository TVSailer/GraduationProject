using Admin.Args;
using Admin.View;
using DataAccess.Postgres.Repository;
using Logica.Interface;
using Logica.UI;

namespace Admin.ViewModel.Model.Review.Buttons;

public class ReviewDetailsButton(ControlView controlView, MementoLesson memento) : 
    IButtons<ViewButtonClickArgs<ReviewEntity, ReviewFieldData>>
{
    public List<CustomButton>? GetButtons(object? send, ViewButtonClickArgs<ReviewEntity, ReviewFieldData>? eventArgs)
        => [
            new CustomButton("Назад")
                .CommandClick(() => controlView.Exit()),
            new CustomButton("Удалить")
                .CommandClick(() =>
                {
                    memento.DeleteReview(eventArgs!.FieldData.Entity.Id);
                    controlView.Exit();
                })
        ];
}