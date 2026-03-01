using Admin.DI;
using Admin.DI.Module;
using UserInterface.UiLayoutPanel.ButtonPanel;
using UserInterface.View;

namespace Admin.FieldData.Model.AdminMain;

public class AdminMainViewButton(
    ControlView controlView,
    LessonManager fieldDataL,
    VisitorManager fielDataV,
    TeacherManager fieldDataT) : IButtons<AdminFieldData>
{
    public List<CustomButton> GetButtons(AdminFieldData eventArgs)
        => [
            new CustomButton("📰 Управление новостями").CommandClick(() => controlView.LoadView(fieldDataL)),
            new CustomButton("🎭 Управление мероприятиями").CommandClick(() => controlView.LoadView(fieldDataL)),
            new CustomButton("🎨 Управление кружками").CommandClick(() => controlView.LoadView(fieldDataL)),
            new CustomButton("👥 Управление посетителями").CommandClick(() => controlView.LoadView(fielDataV)),
            new CustomButton("👨‍🏫 Управление преподавателями").CommandClick(() => controlView.LoadView(fieldDataT)),
        ];
}