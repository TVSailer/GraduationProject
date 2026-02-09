using Admin.Commands_Handlers.Managment;
using Admin.DI;
using Admin.Memento;
using Admin.View;
using Admin.View.ViewForm;
using Admin.ViewModel.Managment;
using DataAccess.Postgres.Models;
using MediatR;

public class LessonWordWithVisitorButton(ControlView control) : IParametersButtons<LessonWordWithVisitor>
{
    private Action action;
    public List<ButtonInfo> GetButtons(LessonWordWithVisitor instance)
        => [
            new("Назад", _ => control.Exit()),
            new("Добавить нового", _ => control.LoadView<VisitorAddingPanelUI>()),
            new("Добавить существуещегося", _ => action.Invoke()),
        ];
}