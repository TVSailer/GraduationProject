using Admin.Args;
using Admin.DI;
using Admin.View;
using Admin.ViewModel.Interface;

namespace Admin.ViewModel.Managment;

public class ManagmentVisitorButton(ControlView controlView) : IButtons<ViewButtonClickArgs<VisitorManagment>>
{
    public List<CustomButton<ViewButtonClickArgs<VisitorManagment>>> GetButtons(object? data = null)
        => [
            new CustomButton<ViewButtonClickArgs<VisitorManagment>>()
                .LabelText("Назад")
                .CommandClick((_, _) => controlView.Exit())
        ];
}