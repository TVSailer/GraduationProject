using Admin.DI;
using Admin.View;
using Admin.ViewModel.Managment;
using DataAccess.Postgres.Repository;

public class LessonWordWithVisitorButton(ControlView control, VisitorsRepository repositoryV) : IParametersButtons<LessonWordWithVisitor>
{
    public List<ButtonInfo> GetButtons(LessonWordWithVisitor instance)
        => [
            new("Назад", _ => control.Exit()),
            new("Добавить нового", _ => control.LoadView<VisitorAddingPanelUi>(), _ => repositoryV.IsAdd),
            new("Добавить существуещегося", _ => control.LoadView<VisitorCardPanelUi>(), _ => repositoryV.IsAdd),
        ];
}