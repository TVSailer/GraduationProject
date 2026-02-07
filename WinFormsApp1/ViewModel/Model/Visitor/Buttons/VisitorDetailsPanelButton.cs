using Admin.DI;
using Admin.View.ViewForm;
using Admin.ViewModel.Managment;
using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;
using Logica;

namespace Admin.ViewModel.Model.Visitor.Buttons;

public class VisitorDetailsPanelButton(Repository<VisitorEntity> repository) : IParametersButtons<VisitorDetailsPanelUI>
{
    public List<ButtonInfo> GetButtons(VisitorDetailsPanelUI instance)
        =>
        [
            new("Назад", _ => AdminDI.GetService<IView<VisitorMangment>>().InitializeComponents(null)),
            new("Обновить",
                _ =>
                {
                    repository.Update(instance.Entity.Id, instance.Entity.GetEntity());
                }),
            new("Удалить",
                _ =>
                {
                    repository.Delete(instance.Entity.Id);
                    AdminDI.GetService<IView<VisitorMangment>>().InitializeComponents(null);
                })
        ];
}