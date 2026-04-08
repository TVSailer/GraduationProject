using Domain.Entitys;
using UserInterface.LayoutPanel;
using UserInterface.LayoutPanel.Extension;
using UserInterface.View;
using Visitor.ViewModel.Event;

namespace Visitor.View.Event;

public class EventManagerPanelView(EventManagerPanelViewModel viewModel) : UiView<EventManagerPanelViewModel>
{
    public override IBuilder CreateUi(BuilderLayoutPanel builderLayoutPanel)
        => builderLayoutPanel.Column()
            .Row().Content()
                .CardFlowLayoutPanel<EventEntity, EventCard>()
                .ClickedCard(viewModel.OpenEvent)
                .Initialize(viewModel.Events)
            .End() 
            .RowAbsolute(80)
                .Column().Content()
                    .Button("Назад")
                    .Command(viewModel.Exit)
                .End()
                .Column().Content()
                    .Button("Обновить")
                    .Command(viewModel.Update)
                .End()
                .Column().Content()
                    .Button()
                    .NoEnable()
                .End()
                .Column().Content()
                    .Button()
                    .NoEnable()
                .End()
            .End();
}