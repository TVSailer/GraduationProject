using Admin.Args;
using Admin.DI;
using Admin.DI.Module;
using Admin.View;
using User_Interface_Library.UiLayoutPanel.ButtonPanel;
using User_Interface_Library.View;

public class AdminMainViewButton(ControlView controlView) : IButtons<AdminFieldData>
{
    public List<CustomButton> GetButtons(AdminFieldData eventArgs)
        => [
            new CustomButton("📰 Управление новостями").CommandClick(() => controlView.LoadView<LessonManagment>()),
            new CustomButton("🎭 Управление мероприятиями").CommandClick(() => controlView.LoadView<LessonManagment>()),
            new CustomButton("🎨 Управление кружками").CommandClick(() => controlView.LoadView<LessonManagment>()),
            new CustomButton("👥 Управление посетителями").CommandClick(() => controlView.LoadView<LessonManagment>()),
            new CustomButton("👨‍🏫 Управление преподавателями").CommandClick(() => controlView.LoadView<LessonManagment>()),
        ];
}

