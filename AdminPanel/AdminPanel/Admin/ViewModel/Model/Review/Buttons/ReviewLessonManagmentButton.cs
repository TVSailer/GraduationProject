using Admin.Args;
using Admin.DI;
using Admin.View;
using Logica.Interface;
using Logica.UI;

namespace Admin.ViewModel.Model.Review.Buttons;

public class ReviewManagmentButton(ControlView controlView) 
    : IButtons<ViewButtonClickArgs<ReviewManagment>>,
        IButton<CardClickedArgs<ReviewEntity>>
{
    public List<CustomButton>? GetButtons(object? data, ViewButtonClickArgs<ReviewManagment>? eventArgs)
        => [
            new CustomButton("Назад")
                .CommandClick(() => controlView.Exit()),
        ];

    public CustomButton? GetButton(object? send, CardClickedArgs<ReviewEntity> eventArgs)
        => new CustomButton()
                .CommandClick(() => controlView.LoadView<ReviewFieldData, ReviewEntity>(eventArgs.Entity));
}