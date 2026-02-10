using Admin.DI;
using Admin.Memento;
using Admin.View;
using Admin.View.ViewForm;
using Admin.ViewModel.Managment;
using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;
using Logica;

namespace Admin.ViewModel.Model.Visitor.Buttons;

public class VisitorAddingPanelButton(Repository<LessonEntity> repositoryL, Repository<VisitorEntity> repositoryV, ControlView control) : IParametersButtons<VisitorAddingPanelUI>
{
    public List<ButtonInfo> GetButtons(VisitorAddingPanelUI instance)
        => 
        [
            new("Назад", _ => control.Exit()),
            new("Сохранить",
                _ =>
                {
                    if (Validatoreg.TryValidObject(instance, out var results))
                    {
                        var entity = instance.Entity.GetData();

                        var auth = UserAuthService.CreateAuthUser(entity.FIO.Name,
                            repositoryV
                                .Get()
                                .Select(t => t.Password)
                                .ToArray());

                        LogicaMessage.MessageInfo($" Логин: {auth.Login}\nПароль: {auth.Password}");

                        entity.Login = auth.Login;
                        entity.Password = BCrypt.Net.BCrypt.HashPassword(auth.Password);
                        repositoryV.Add(entity);
                        control.Exit();
                    }
                    if (instance is PropertyChange pc)
                        results.ForEach(r => r.MemberNames.ForEach(n => { pc.OnMassegeErrorProvider(r.ErrorMessage, n); }));
                })
        ];
}