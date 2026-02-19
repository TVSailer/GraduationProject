using Admin.Args;
using Admin.DI;
using Admin.View;
using Admin.ViewModel.Interface;
using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;
using Logica;

namespace Admin.ViewModel.Model.Visitor.Buttons;

public class VisitorAddingButton(MementoLesson v, ControlView controlView) : IButtons<ViewButtonClickArgs<VisitorEntity, VisitorAddingFieldData>>
{
    public List<CustomButton> GetButtons(
        object? data, ViewButtonClickArgs<VisitorEntity, VisitorAddingFieldData>? e)
        => [
            new CustomButton("Назад")
                .CommandClick(() => controlView.Exit()),
            new CustomButton("Сохранить")
                .CommandClick(() => SaveEntity(e.FieldData)),
        ];

    private void SaveEntity(VisitorAddingFieldData arg2FieldData)
    {
        if (Validatoreg.TryValidObject(arg2FieldData, out var results))
        {
            var entity = arg2FieldData.Entity.GetData();

            var auth = UserAuthService.CreateAuthUser(entity.FIO.Name,
                v
                    .GetVisitorsBelongingLesson()
                    .Select(t => t.Password)
                    .ToArray());

            LogicaMessage.MessageInfo($" Логин: {auth.Login}\nПароль: {auth.Password}");

            entity.Login = auth.Login;
            entity.Password = BCrypt.Net.BCrypt.HashPassword(auth.Password);
            v.AddVisitor(entity);
            controlView.Exit();
        }
         
        if (arg2FieldData is PropertyChange pc)
            results.ForEach(r => r.MemberNames.ForEach(n => { pc.OnMassegeErrorProvider(r.ErrorMessage, n); }));
    }
}