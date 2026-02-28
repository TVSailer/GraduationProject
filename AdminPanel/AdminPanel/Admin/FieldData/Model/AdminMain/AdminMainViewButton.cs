using Admin.DI;
using Admin.DI.Module;
using UserInterface.UiLayoutPanel.ButtonPanel;
using UserInterface.View;

public class AdminMainViewButton(ControlView controlView) : IButtons<AdminFieldData>
{
    public List<CustomButton> GetButtons(AdminFieldData eventArgs)
        => [
            new CustomButton("📰 Управление новостями").CommandClick(() => controlView.LoadView<LessonManager>()),
            new CustomButton("🎭 Управление мероприятиями").CommandClick(() => controlView.LoadView<LessonManager>()),
            new CustomButton("🎨 Управление кружками").CommandClick(() => controlView.LoadView<LessonManager>()),
            new CustomButton("👥 Управление посетителями").CommandClick(() => controlView.LoadView<LessonManager>()),
            new CustomButton("👨‍🏫 Управление преподавателями").CommandClick(() => controlView.LoadView<LessonManager>()),
        ];
}

