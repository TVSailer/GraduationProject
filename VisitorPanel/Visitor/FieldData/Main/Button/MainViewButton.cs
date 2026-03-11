using UserInterface.UiLayoutPanel.ButtonPanel;
using UserInterface.View;
using Visitor.DI.Module;

namespace Visitor.FieldData.Main.Button;

public class MainViewButton(
    ControlView controlView,
    LessonManager fieldDataL) : IButtons<MainFieldData>
{
    public List<CustomButton> GetButtons(MainFieldData eventArgs)
        => [
            new CustomButton("📰 Новости").CommandClick(() => controlView.LoadView(fieldDataL)),
            new CustomButton("🎭 Мероприятия").CommandClick(() => controlView.LoadView(fieldDataL)),
            new CustomButton("🎨 Кружки").CommandClick(() => controlView.LoadView(fieldDataL)),
            new CustomButton("👨‍🏫 Вход").CommandClick(() => controlView.LoadView(fieldDataL)),
            new CustomButton("🚪 Выход").CommandClick(controlView.Exit),
        ];
}
