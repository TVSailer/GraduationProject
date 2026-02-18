using Admin.Args;
using Admin.DI;
using Admin.View;
using Admin.ViewModel.Interface;

namespace Admin.ViewModel.Model.Review.Buttons;

public class ReviewLessonManagmentButton(ControlView controlView) 
    : IButtons<ViewButtonClickArgs<LessonReviewManagment>>,
        IButtons<CardClickedToolStripArgs<ReviewEntity>>
{
    public List<CustomButton>? GetButtons(object? data, ViewButtonClickArgs<LessonReviewManagment>? eventArgs)
        => [
            new CustomButton("Назад")
                .CommandClick(() => controlView.Exit()),
        ];

    public List<CustomButton>? GetButtons(object? data, CardClickedToolStripArgs<ReviewEntity>? eventArgs)
    {
        return null;
    }
}