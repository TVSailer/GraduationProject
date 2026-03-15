using Admin.DI.Module;
using UserInterface.Info;
using UserInterface.UiLayoutPanel.ButtonPanel;
using UserInterface.UiLayoutPanel.CardPanel.Args;
using UserInterface.View;

namespace Admin.FieldData.Model.AdminMain;

public class AdminMainViewButton(
    ControlView controlView,
    LessonManager fieldDataL,
    NewsManager fieldDataN,
    EventManager fieldDataE,
    VisitorManager fieldDataV,
    TeacherManager fieldDataT) : IButtons<ClickedArgs<AdminFieldData>>
{
    public InfoButton[] GetButtons(ClickedArgs<AdminFieldData> eventArgs)
        => [
            new InfoButton("📰 Управление новостями").CommandClick(() => controlView.LoadView(fieldDataN)),
            new InfoButton("🎭 Управление мероприятиями").CommandClick(() => controlView.LoadView(fieldDataE)),
            new InfoButton("🎨 Управление кружками").CommandClick(() => controlView.LoadView(fieldDataL)),
            new InfoButton("👥 Управление посетителями").CommandClick(() => controlView.LoadView(fieldDataV)),
            new InfoButton("👨‍🏫 Управление преподавателями").CommandClick(() => controlView.LoadView(fieldDataT)),
        ];
}