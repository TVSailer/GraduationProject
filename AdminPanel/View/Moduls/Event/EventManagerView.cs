using Admin.ViewModel.Model.Event;
using Domain.Command;
using System.Windows.Input;
using Domain.Entitys;
using Domain.Repository;
using UserInterface.LayoutPanel;
using UserInterface.LayoutPanel.Extension;
using UserInterface.Service.View;
using UserInterface.View;

namespace Admin.View.Moduls.Event;

public class EventManagerPanelView(
    EventManagerPanelViewModel viewModel,
    ControlView controlView) : UiView<EventManagerPanelViewModel>
{
    public override IBuilder CreateUi(BuilderLayoutPanel layout)
        => layout.Column()
            .Row()
                .Column(80).Content()
                    .CardFlowLayoutPanel<EventEntity, EventCard>(() => viewModel.EventsEntities)
                    .Binding(viewModel)
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
                                    .SetData(viewModel.CategoryEntities)
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
                    .Command(viewModel.Exit)
                .End()
                .Column().Content()
                    .Button("Добавить")
                    .Command(viewModel.LoadAddingPanel)
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