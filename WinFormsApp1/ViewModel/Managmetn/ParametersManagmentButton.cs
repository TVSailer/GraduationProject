using Admin.Commands_Handlers.Managment;
using Admin.ViewModel.Interface;
using Admin.ViewModel.Managment;
using MediatR;

public class ParametersManagmentButton<T, TExit, TAddingPanel>(IMediator mediator) : IParametersButtons<T>
{
    public List<ButtonInfo> buttons =>
    [
        new("Назад", _ => mediator.Send(new InitializeUI<TExit>())),
        new("Добавить", _ => mediator.Send(new InitializeUI<TAddingPanel>()))
    ];
}

public class DetailsPanelButton<T>(IMediator mediator) : IParametersButtons<T>
{
    public List<ButtonInfo> buttons =>
    [
        // new("Назад", _ => mediator.Send(new InitializeUI<TViewModelExit>())),
        // new("Сохранить", _ => mediator.Send(new InitializeUI<TAddingPanel>()))
    ];
}

