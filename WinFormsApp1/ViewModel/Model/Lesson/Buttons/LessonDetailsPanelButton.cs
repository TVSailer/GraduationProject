using Admin.Memento;
using Admin.View;
using Admin.View.ViewForm;
using Admin.ViewModel.Managment;
using Admin.ViewModels.Lesson;
using DataAccess.Postgres;
using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;
using Logica;
using MediatR;

public class LessonDetailsPanelButton(
    ControlView mementoView,
    VisitorsRepository repositoryV,
    Repository<LessonEntity> repositoryL) : IParametersButtons<LessonDetailsPanelUI>
{
    private Action action;
    public List<ButtonInfo> GetButtons(LessonDetailsPanelUI instance)
    => 
    [
        new("Назад", _ => mementoView.Exit()),
        new("Обновить", _ =>
        {
            if (Validatoreg.TryValidObject(instance, out var results))
            {
                repositoryL.Update(instance.Entity.Id, instance.Entity.GetData());
                mementoView.Exit();
            }
            if (instance is PropertyChange pc)
                results.ForEach(r => r.MemberNames.ForEach(n => { pc.OnMassegeErrorProvider(r.ErrorMessage, n); }));
        }),
        new("Управление посетителями", _ =>
        {
            repositoryV.Lesson = instance.Entity.GetData();
            mementoView.LoadView<LessonWordWithVisitor>();
        }),
        new("Управление посещаемостью", _ => action.Invoke()),
        new("Управление отзывами", _ => action.Invoke()),
        new("Добавить изображение", _=> instance.OnAddingImg.Execute(null)),
        new("Удалить изображение", _ => instance.OnDeletingImg.Execute(null)),
        new("Обновить расписание", _ => new ScheduleView(instance).ShowDialog()),
        new("Удалить", _ =>
        {
            repositoryL.Delete(instance.Entity.Id);
            mementoView.Exit();
        }),
    ];
}