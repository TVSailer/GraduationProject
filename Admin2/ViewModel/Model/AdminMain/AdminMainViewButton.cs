using Admin.Args;
using Admin.DI;
using Admin.View;
using Admin.ViewModel.Interface;

public class AdminMainViewButton(ControlView controlView) : IButtons<ViewButtonClickArgs<AdminPanelUi>>
{
    public List<CustomButton<ViewButtonClickArgs<AdminPanelUi>>> GetButtons(object? data = null)
        => [
            new CustomButton<ViewButtonClickArgs<AdminPanelUi>>()
                .LabelText("📰 Управление новостями")
                .CommandClick((_, _) => controlView.LoadView<VisitorManagment>()),
            new CustomButton<ViewButtonClickArgs<AdminPanelUi>>()
                .LabelText("🎭 Управление мероприятиями")
                .CommandClick((_, _) => controlView.LoadView<VisitorManagment>()),
            new CustomButton<ViewButtonClickArgs<AdminPanelUi>>()
                .LabelText("🎨 Управление кружками")
                .CommandClick((_, _) => controlView.LoadView<LessonMangment>()),
            new CustomButton<ViewButtonClickArgs<AdminPanelUi>>()
                .LabelText("👥 Управление посетителями")
                .CommandClick((_, _) => controlView.LoadView<VisitorManagment>()),
            new CustomButton<ViewButtonClickArgs<AdminPanelUi>>()
                .LabelText("👨‍🏫 Управление преподавателями")
                .CommandClick((_, _) => controlView.LoadView<VisitorManagment>()),
        ];
}

