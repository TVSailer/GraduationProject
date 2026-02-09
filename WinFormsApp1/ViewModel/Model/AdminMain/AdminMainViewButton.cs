using Admin.DI;
using Admin.View;
using Admin.View.ViewForm;
using Admin.ViewModel.Managment;

public class AdminMainViewButton(ControlView view) : IParametersButtons<AdminPanelUI>
{
    private Action action;
    public List<ButtonInfo> GetButtons(AdminPanelUI instance)
        =>
        [
            new("📰 Управление новостями", _ => action.Invoke()),
            new("🎭 Управление мероприятиями", _ => action.Invoke()),
            new("🎨 Управление кружками", _ => view.LoadView<LessonMangment>()),
            new("👥 Управление посетителями", _ => view.LoadView<VisitorMangment>()),
            new("👨‍🏫 Управление преподавателями", _ => action.Invoke()),
        ];
}

