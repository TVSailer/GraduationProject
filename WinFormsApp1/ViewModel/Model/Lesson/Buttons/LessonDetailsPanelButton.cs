using Admin.Memento;
using Admin.View.ViewForm;
using Admin.ViewModel.Managment;
using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;
using Logica;
using MediatR;

public class LessonDetailsPanelButton(
    MementoData<VisitorEntity> mementoSearch, 
    MementoStateField<LessonDetailsPanelUI> mementoEntiy,  
    Repository<LessonEntity> repository, 
    IServiceProvision di) : IParametersButtons<LessonDetailsPanelUI>
{
    private Action action;
    public List<ButtonInfo> GetButtons(LessonDetailsPanelUI instance)
    => 
    [
        new("Назад", _ => di.GetService<IView<LessonMangment>>().InitializeComponents(null)),
        new("Обновить", _ =>
        {
            if (Validatoreg.TryValidObject(instance, out var results))
            {
                repository.Update(instance.Entity.Id, instance.Entity.GetData());
                di.GetService<IView<LessonMangment>>().InitializeComponents(null);
            }
            if (instance is PropertyChange pc)
                results.ForEach(r => r.MemberNames.ForEach(n => { pc.OnMassegeErrorProvider(r.ErrorMessage, n); }));
        }),
        new("Управление посетителями", _ =>
        {
            mementoEntiy.State = instance;
            mementoSearch.Data = instance.Entity.GetData().Visitors;
            di.GetService<IView<LessonWordWithVisitor>>().InitializeComponents(null);
        }),
        new("Управление посещаемостью", _ => action.Invoke()),
        new("Управление отзывами", _ => action.Invoke()),
        new("Добавить изображение", _=> instance.OnAddingImg.Execute(null)),
        new("Удалить изображение", _ => instance.OnDeletingImg.Execute(null)),
        new("Удалить", _ =>
        {
            repository.Delete(instance.Entity.Id);
            di.GetService<IView<LessonMangment>>().InitializeComponents(null);
        }),
    ];
}