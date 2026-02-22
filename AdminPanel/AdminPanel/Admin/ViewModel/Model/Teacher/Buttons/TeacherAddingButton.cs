using Admin.Args;
using Admin.DI;
using Admin.View;
using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;
using Logica;
using Logica.Interface;
using Logica.UI;

namespace Admin.ViewModel.Model.Teacher.Buttons;

public class TeacherAddingButton(Repository<TeacherEntity> repository, ControlView controlView) : 
    IButtons<ViewButtonClickArgs<TeacherEntity, TeacherAddingFieldData>>
{
    public List<CustomButton> GetButtons(
        object? data, ViewButtonClickArgs<TeacherEntity, TeacherAddingFieldData>? e)
        => [
            new CustomButton("Назад")
                .CommandClick(() => controlView.Exit()),
            new CustomButton("Сохранить")
                .CommandClick(() => SaveEntity(e.FieldData)),
        ];

    private void SaveEntity(TeacherAddingFieldData arg2FieldData)
    {
        if (Validatoreg.TryValidObject(arg2FieldData, out var results))
        {
            var entity = arg2FieldData.Entity.GetData();

            var auth = UserAuthService.CreateAuthUser(entity.FIO.Name,
                repository
                    .Get()
                    .Select(t => t.Password)
                    .ToArray());

            LogicaMessage.MessageInfo($" Логин: {auth.Login}\nПароль: {auth.Password}");

            entity.Login = auth.Login;
            entity.Password = BCrypt.Net.BCrypt.HashPassword(auth.Password);
            repository.Add(entity);
            controlView.Exit();
        }

        if (arg2FieldData is PropertyChange pc)
            results.ForEach(r => r.MemberNames.ForEach(n => { pc.OnMassegeErrorProvider(r.ErrorMessage, n); }));
    }
}