using Admin.ViewModels.Lesson;
using DataAccess.Postgres.Repository;
using Logica;
using System.Windows.Input;

namespace Admin.ViewModel.Model.Visitor;

[LinkingCommand(nameof(ManagmentModelView<>.OnLoadDetailsView))]
public class VisitorDetailsPanel : VisitorData
{
    [ButtonInfoUI("Удалить")] public ICommand OnDelete { get; protected set; }
    [ButtonInfoUI("Обновить")] public ICommand OnUpdate { get; protected set; }

    public VisitorDetailsPanel(VisitorsRepository visitorsRepository)
    {
        OnUpdate = new MainCommand(
            _ => TryValidObject(() =>
            {
                visitorsRepository.Update(GenericRepositoryEntity.Id, GenericRepositoryEntity.GetEntity());
            }));

        OnDelete = new MainCommand(
            _ =>
            {
                visitorsRepository.Delete(GenericRepositoryEntity.Id);
                OnBack.Execute(this);
            });
    }
}