using Admin.ViewModels.Lesson;
using DataAccess.Postgres.Repository;
using Logica;
using System.Windows.Input;

namespace Admin.ViewModel.Model.Visitor;

[LinkingCommand(nameof(ManagmentModelView<>.OnLoadAddingView))]
public class VisitorAddingPanel : VisitorData
{
    [ButtonInfoUI("Добавить")] public ICommand OnSave { get; protected set; }

    public VisitorAddingPanel(VisitorsRepository visitorsRepository)
    {
        OnSave = new MainCommand(
            _ => TryValidObject(() =>
            {
                var entity = GenericRepositoryEntity.GetEntity();

                var auth = UserAuthService.CreateAuthUser(entity.FIO.Name,
                    visitorsRepository
                        .Get()
                        .Select(t => t.Password)
                        .ToArray());

                LogicaMessage.MessageInfo($" Логин: {auth.Login}\nПароль: {auth.Password}");

                entity.Login = auth.Login;
                entity.Password = BCrypt.Net.BCrypt.HashPassword(auth.Password);
                visitorsRepository.Add(entity);
            }));
    }
}