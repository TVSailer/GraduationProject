using Admin.DI;
using Admin.View;
using Admin.ViewModel.Managment;
using DataAccess.Postgres.Repository;

public class LessonWordWithVisitorButton(ControlView control, VisitorsRepository repositoryV) : IParametersButtons<LessonWordWithVisitor>
{
    private Action action;
    public List<ButtonInfo> GetButtons(LessonWordWithVisitor instance)
        => [
            new("Назад", _ => control.Exit()),
            new("Добавить нового", _ => control.LoadView<VisitorAddingPanelUI>(), button => repositoryV.IsAdd),
            new("Добавить существуещегося", _ => action.Invoke(), button => repositoryV.IsAdd),
        ];
}