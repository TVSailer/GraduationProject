using UserInterface.Info;
using UserInterface.UiLayoutPanel.ButtonPanel;
using UserInterface.UiLayoutPanel.CardPanel.Args;
using UserInterface.View;
using Visitor.DI.Module;

namespace Visitor.FieldData.Main.Button;

public class MainViewButton(
    ControlView controlView,
    LessonManager fieldDataL,
    NewsManager fieldDataN,
    EventManager fieldDataE) : IButtons<ClickedArgs<MainFieldData>>
{
    public InfoButton[] GetButtons(ClickedArgs<MainFieldData> eventArgs)
        => [
            new InfoButton("📰 Новости").CommandClick(() => controlView.LoadView(fieldDataN)),
            new InfoButton("🎭 Мероприятия").CommandClick(() => controlView.LoadView(fieldDataE)),
            new InfoButton("🎨 Кружки").CommandClick(() => controlView.LoadView(fieldDataL)),
            new InfoButton("👨‍🏫 Вход").CommandClick(() => controlView.LoadView(fieldDataL)),
            new InfoButton("🚪 Выход").CommandClick(controlView.Exit),
        ];
}
