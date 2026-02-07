using Admin.View.ViewForm;
using Admin.ViewModel.Managment;
using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;
using Logica;
using MediatR;

public class LessonDetailsPanelButton(Repository<LessonEntity> repository) : IParametersButtons<LessonDetailsPanelUI>
{
    private Action action;
    public List<ButtonInfo> GetButtons(LessonDetailsPanelUI instance)
    => 
    [
        new("Назад", _ => AdminDI.GetService<IView<LessonMangment>>().InitializeComponents(null)),
        new("Обновить", _ =>
        {
            if (Validatoreg.TryValidObject(instance, out var results))
            {
                repository.Add(instance.Entity.GetEntity());
                AdminDI.GetService<IView<LessonMangment>>().InitializeComponents(null);
            }
            if (instance is PropertyChange pc)
                results.ForEach(r => r.MemberNames.ForEach(n => { pc.OnMassegeErrorProvider(r.ErrorMessage, n); }));
        }),
        new("Управление посетителями", _ =>
        {
            var ui = AdminDI.GetService<IView<LessonWordWithVisitor>>();
            if(ui is IInitializeSerch<VisitorEntity> s)
                s.SetData(() => instance.Entity.GetEntity().Visitors);
            ui.InitializeComponents(null);

        }),
        new("Управление посещаемостью", _ => action.Invoke()),
        new("Управление отзывами", _ => action.Invoke()),
        new("Добавить изображение", _=> instance.OnAddingImg.Execute(null)),
        new("Удалить изображение", _ => instance.OnDeletingImg.Execute(null)),
        new("Удалить", _ =>
        {
            repository.Delete(instance.Entity.Id);
            AdminDI.GetService<IView<LessonMangment>>().InitializeComponents(null);
        }),
    ];
}