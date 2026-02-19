using Admin.Args;
using Admin.DI;
using Admin.View;
using Admin.ViewModel.Interface;

namespace Admin.ViewModel.Model.Review.Buttons;

public class ReviewDetailsButton(ControlView controlView) : 
    IButtons<ViewButtonClickArgs<ReviewEntity, ReviewDetailsFieldData>>
{
    public List<CustomButton>? GetButtons(object? send, ViewButtonClickArgs<ReviewEntity, ReviewDetailsFieldData>? eventArgs)
        => [
            new CustomButton("Назад")
                .CommandClick(() => controlView.Exit()),
            new CustomButton("Удалить")
                .CommandClick(() => controlView.Exit())
        ];
}