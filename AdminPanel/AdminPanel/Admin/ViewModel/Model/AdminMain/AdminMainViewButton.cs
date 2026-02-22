using Admin.Args;
using Admin.DI;
using Admin.View;
using Logica.Interface;
using Logica.UI;

public class AdminMainViewButton(ControlView controlView) : IButtons<ViewButtonClickArgs<AdminFieldData>>
{
    public List<CustomButton> GetButtons(object? data, ViewButtonClickArgs<AdminFieldData> eventArgs)
        => [
            new CustomButton("📰 Управление новостями").CommandClick(() => controlView.LoadView<VisitorManagment>()),
            new CustomButton("🎭 Управление мероприятиями").CommandClick(() => controlView.LoadView<EventManagment>()),
            new CustomButton("🎨 Управление кружками").CommandClick(() => controlView.LoadView<LessonManagment>()),
            new CustomButton("👥 Управление посетителями").CommandClick(() => controlView.LoadView<VisitorManagment>()),
            new CustomButton("👨‍🏫 Управление преподавателями").CommandClick(() => controlView.LoadView<TeacherManagment>()),
        ];
}

