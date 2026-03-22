using Abstract.View;
using AbstractView.View;
using Admin.FieldData.Model.Event;
using Domain.Command;
using Domain.Entitys;
using System.Windows.Input;
using UserInterface.LayoutPanel;
using UserInterface.LayoutPanel.Extension;

namespace Admin.View.Moduls.Event;

public class EventManagerView(
    EventManagerViewModel viewModel,
    ControlView controlView) : UiView
{
    private readonly ICommand _loadDetailsPanel = new ExecuteCommand(_ => controlView.LoadView<EventDetailsPanelUi>());
    private readonly ICommand _loadAddingPanel = new ExecuteCommand(_ => controlView.LoadView<EventAddingPanelView>());
    private readonly ICommand _exit = new ExecuteCommand(_ => controlView.Exit());

    protected override IBuilder CreateUi(BuilderLayoutPanel layout)
        => layout.Column()
            .Row()
                .Column(80).Content()
                    .CardFlowLayoutPanel<EventEntity, EventCard>(() => viewModel.EventsEntities)
                    .Binding(viewModel)
                    .ClickedCard(_loadDetailsPanel)
                    .Initialize()
                .End()
                .Column(20).Content()
                    .Panel()
                    .Contents(b => 
                        b.Column()
                            .RowAbsolute(40)
                                .Column().Content()
                                    .Label("Категория")
                                .End()
                                .Column().Content()
                                    .ComboBox()
                                    .SetData(viewModel.EventsEntities)
                                    .Binding(viewModel, nameof(viewModel.Category))
                                .End()
                            .End()
                            .RowAbsolute(40)
                                .Column().Content()
                                    .Label("Название")
                                .End()
                                .Column().Content()
                                    .TextBox()
                                    .Binding(viewModel, nameof(viewModel.Title))
                                .End()
                            .End()
                            .RowAbsolute(40)
                                .Column().Content()
                                    .Label("c")
                                .End()
                                .Column().Content()
                                    .MaskedTextBox("00/00/0000")
                                    .Binding(viewModel, nameof(viewModel.StartDate))
                                .End()
                            .End()
                            .RowAbsolute(40)
                                .Column().Content()
                                    .Label("по")
                                .End()
                                .Column().Content()
                                    .MaskedTextBox("00/00/0000")
                                    .Binding(viewModel, nameof(viewModel.EndDate))
                                .End()
                            .End()
                            .Row()
                            .End()
                            .RowAbsolute(60).Content()
                                .Button("Очистить")
                                .Command(viewModel.ClearSearch)
                            .End()
                        )
                .End()
            .End()
            .RowAbsolute(80)
                .Column().Content()
                    .Button("Назад")
                    .Command(_exit)
                .End()
                .Column().Content()
                    .Button("Добавить")
                    .Command(_loadAddingPanel)
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