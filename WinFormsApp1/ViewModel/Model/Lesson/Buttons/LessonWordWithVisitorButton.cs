using Admin.Commands_Handlers.Managment;
using Admin.DI;
using Admin.View.ViewForm;
using Admin.ViewModel.Managment;
using DataAccess.Postgres.Models;
using MediatR;

public class LessonWordWithVisitorButton(IMediator mediator, IServiceProvision di) : IParametersButtons<LessonWordWithVisitor>
{
    private Action action;
    public List<ButtonInfo> GetButtons(LessonWordWithVisitor instance)
        => [
            new("Назад", _ => mediator.Send(new RecoveryPanelRequest<LessonDetailsPanelUI>())),
            new("Добавить нового", _ => di.GetService<IView<VisitorAddingPanelUI, VisitorEntity>>().InitializeComponents(null)),
            new("Добавить существуещегося", _ => action.Invoke()),
        ];
}