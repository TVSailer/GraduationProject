using DataAccess.PostgreSQL.Memento;
using UserInterface.Info;
using UserInterface.Message;
using UserInterface.UiLayoutPanel.ButtonPanel;
using UserInterface.UiLayoutPanel.CardPanel.Args;
using UserInterface.View;
using Visitor.DI.Module;
using Visitor.View.Enter;

namespace Visitor.FieldData.Main.Button;

public class MainViewButton(
    ControlView controlView,
    LessonManager fieldDataL,
    NewsManager fieldDataN,
    MementoVisitor mementoVisitor,
    EventManager fieldDataE) : IButtons<MainFieldData>, ILinkLabels<MainFieldData>
{
    public InfoButton[] GetButtons(ClickedArgs<MainFieldData> eventArgs)
        => [
            new InfoButton("📰 Новости").CommandClick(() => controlView.LoadView(fieldDataN)),
            new InfoButton("🎭 Мероприятия").CommandClick(() => controlView.LoadView(fieldDataE)),
            new InfoButton("🎨 Кружки").CommandClick(() => controlView.LoadView(fieldDataL)),
            new InfoButton("👨‍🏫 Вход").CommandClick(controlView.ShowDialog<EnterPanelUi>),
            new InfoButton("🚪 Выход").CommandClick(controlView.Exit),
        ];

    public InfoLinkLabel[] GetLinkLabels(LinkLabelArgs<MainFieldData> eventArgs)
        => [
            new InfoLinkLabel("Профиль").CommandClick(() => LogicaMessage.MessageError("sd")).Enable(mementoVisitor.IsVisitor),
        ];
}
