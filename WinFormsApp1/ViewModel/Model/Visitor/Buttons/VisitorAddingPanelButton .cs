using Admin.DI;
using Admin.View.ViewForm;
using Admin.ViewModel.Managment;
using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;
using Logica;

namespace Admin.ViewModel.Model.Visitor.Buttons;

public class VisitorAddingPanelButton(Repository<VisitorEntity> repository) : IParametersButtons<VisitorAddingPanelUI>
{
    public List<ButtonInfo> GetButtons(VisitorAddingPanelUI instance)
        => 
        [
            new("Назад", _ => AdminDI.GetService<IView<VisitorMangment>>().InitializeComponents(null)),
            new("Сохранить",
                _ =>
                {
                    var entity = instance.Entity.GetEntity();

                    var auth = UserAuthService.CreateAuthUser(entity.FIO.Name,
                        repository
                            .Get()
                            .Select(t => t.Password)
                            .ToArray());

                    LogicaMessage.MessageInfo($" Логин: {auth.Login}\nПароль: {auth.Password}");

                    entity.Login = auth.Login;
                    entity.Password = BCrypt.Net.BCrypt.HashPassword(auth.Password);
                    repository.Add(entity);
                    AdminDI.GetService<IView<VisitorMangment>>().InitializeComponents(null);
                })
        ];
}