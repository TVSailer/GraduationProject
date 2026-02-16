using Admin.Args;
using Admin.DI;
using Admin.View;
using Admin.ViewModel.Interface;
using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;
using Logica;
using System.Windows.Forms;

namespace Admin.ViewModel.Model.Visitor.Buttons;

public class VisitorAddingButton(VisitorsLessonRepository repositoryV, ControlView controlView) : IButtons<ViewButtonClickArgs<VisitorEntity, VisitorAddingFieldData>>
{
    public List<CustomButton<ViewButtonClickArgs<VisitorEntity, VisitorAddingFieldData>>> GetButtons(
        object? data = null)
        => [
            new CustomButton<ViewButtonClickArgs<VisitorEntity, VisitorAddingFieldData>>()
                .LabelText("Назад")
                .CommandClick((_, _) => controlView.Exit()),
            new CustomButton<ViewButtonClickArgs<VisitorEntity, VisitorAddingFieldData>>()
                .LabelText("Сохранить")
                .CommandClick((_, e) => SaveEntity(e.FieldData)),
        ];

    private void SaveEntity(VisitorAddingFieldData arg2FieldData)
    {
        if (Validatoreg.TryValidObject(arg2FieldData, out var results))
        {
            var entity = arg2FieldData.Entity.GetData();

            var auth = UserAuthService.CreateAuthUser(entity.FIO.Name,
                repositoryV
                    .Get()
                    .Select(t => t.Password)
                    .ToArray());

            LogicaMessage.MessageInfo($" Логин: {auth.Login}\nПароль: {auth.Password}");

            entity.Login = auth.Login;
            entity.Password = BCrypt.Net.BCrypt.HashPassword(auth.Password);
            repositoryV.Add(entity);
            controlView.Exit();
        }
         
        if (arg2FieldData is PropertyChange pc)
            results.ForEach(r => r.MemberNames.ForEach(n => { pc.OnMassegeErrorProvider(r.ErrorMessage, n); }));
    }
}