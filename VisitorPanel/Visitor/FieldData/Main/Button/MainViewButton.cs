using UserInterface.Info;
using UserInterface.UiLayoutPanel.ButtonPanel;
using UserInterface.UiLayoutPanel.CardPanel.Args;
using UserInterface.View;
using Visitor.DI.Module;

namespace Visitor.FieldData.Main.Button;

public class MainViewButton(
    ControlView controlView,
    LessonManager fieldDataL) : IButtons<ClickedArgs<MainFieldData>>
{
    public InfoButton[] GetButtons(ClickedArgs<MainFieldData> eventArgs)
        => [
            new InfoButton("📰 Новости").CommandClick(() => controlView.LoadView(fieldDataL)),
            new InfoButton("🎭 Мероприятия").CommandClick(() => controlView.LoadView(fieldDataL)),
            new InfoButton("🎨 Кружки").CommandClick(() => controlView.LoadView(fieldDataL)),
            new InfoButton("👨‍🏫 Вход").CommandClick(() => controlView.LoadView(fieldDataL)),
            new InfoButton("🚪 Выход").CommandClick(controlView.Exit),
        ];
}
