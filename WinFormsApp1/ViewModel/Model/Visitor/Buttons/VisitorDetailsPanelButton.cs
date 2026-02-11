using Admin.DI;
using Admin.Memento;
using Admin.View;
using Admin.View.ViewForm;
using Admin.ViewModel.Managment;
using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;
using Logica;

namespace Admin.ViewModel.Model.Visitor.Buttons;

public class VisitorDetailsPanelButton(Repository<VisitorEntity> repository, ControlView control) : IParametersButtons<VisitorDetailsPanelUi>
{
    public List<ButtonInfo> GetButtons(VisitorDetailsPanelUi instance)
        =>
        [
            new("Назад", _ => control.Exit()),
            new("Обновить", _ =>
            {
                if (Validatoreg.TryValidObject(instance, out var results))
                {
                    repository.Update(instance.Entity.Id, instance.Entity.GetData());
                    control.Exit();
                }
                if (instance is PropertyChange pc)
                    results.ForEach(r => r.MemberNames.ForEach(n => { pc.OnMassegeErrorProvider(r.ErrorMessage, n); }));
            }),
            new("Удалить",
                _ =>
                {
                    repository.Delete(instance.Entity.Id);
                    control.Exit();
                })
        ];
}