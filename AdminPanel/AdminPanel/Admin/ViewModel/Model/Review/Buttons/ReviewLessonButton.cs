using Admin.Args;
using Admin.DI;
using Admin.View;
using Admin.ViewModel.Interface;

namespace Admin.ViewModel.Model.Review.Buttons;

public class ReviewLessonDetailsButton(ControlView controlView) : IButtons<ViewButtonClickArgs<LessonReviewManagment>>
{
    public List<CustomButton>? GetButtons(object? data, ViewButtonClickArgs<LessonReviewManagment>? eventArgs)
        => [
            new CustomButton("Назад")
                .CommandClick(() => controlView.Exit()),
            new CustomButton("Удалить")
                .CommandClick(() => controlView.Exit())
        ];
}