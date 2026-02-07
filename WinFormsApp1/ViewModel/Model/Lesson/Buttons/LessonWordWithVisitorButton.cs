using Admin.View.ViewForm;
using Admin.ViewModel.Managment;
using DataAccess.Postgres.Models;

public class LessonWordWithVisitorButton : IParametersButtons<LessonWordWithVisitor>
{
    private Action action;
    public List<ButtonInfo> GetButtons(LessonWordWithVisitor instance)
        => [
            new("Назад", _ => instance.InitializeComponents(null)),
            new("Добавить нового", _ => action.Invoke()),
            new("Добавить существуещегося", _ => action.Invoke()),
        ];
}