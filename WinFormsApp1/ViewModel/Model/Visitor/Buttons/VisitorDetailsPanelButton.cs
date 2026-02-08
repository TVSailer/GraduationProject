using Admin.DI;
using Admin.View.ViewForm;
using Admin.ViewModel.Managment;
using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;
using Logica;

namespace Admin.ViewModel.Model.Visitor.Buttons;

public class VisitorDetailsPanelButton(Repository<VisitorEntity> repository, IServiceProvision di) : IParametersButtons<VisitorDetailsPanelUI>
{
    public List<ButtonInfo> GetButtons(VisitorDetailsPanelUI instance)
        =>
        [
            new("Назад", _ => di.GetService<IView<LessonWordWithVisitor>>().InitializeComponents(null)),
            new("Обновить", _ =>
            {
                if (Validatoreg.TryValidObject(instance, out var results))
                {
                    repository.Update(instance.Entity.Id, instance.Entity.GetData());
                    //di.GetService<IView<LessonMangment>>().InitializeComponents(null);
                }
                if (instance is PropertyChange pc)
                    results.ForEach(r => r.MemberNames.ForEach(n => { pc.OnMassegeErrorProvider(r.ErrorMessage, n); }));
            }),
            new("Удалить",
                _ =>
                {
                    repository.Delete(instance.Entity.Id);
                    di.GetService<IView<VisitorMangment>>().InitializeComponents(null);
                })
        ];
}