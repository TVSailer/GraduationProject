using System.Windows.Input;
using Admin.ViewModels;
using Admin.ViewModels.Lesson;
using DataAccess.Postgres.Repository;
using Logica;

namespace WinFormsApp1.ViewModel.Model.Teacher;

[LinkingCommand(nameof(ManagmentModelView<>.OnLoadAddingView))]
public class TeacherAddingPanel : TeacherData
{
    [ButtonInfoUI("Добавить")]public ICommand OnSave { get; protected set; }

    public TeacherAddingPanel(TeacherRepository teacherRepository, LessonsRepository lessonsRepository) : base(teacherRepository, lessonsRepository)
    {
        OnSave = new MainCommand(
            _ => TryValidObject(() =>
            {
                var auth = UserAuthService.CreateAuthUser(GenericRepositoryEntity.Entity.FIO.Name, 
                    teacherRepository
                        .Get()
                        .Select(t => t.Password)
                        .ToArray());

                LogicaMessage.MessageInfo($" Логин: {auth.Login}\nПароль: {auth.Password}");

                GenericRepositoryEntity.Entity.Login = auth.Login;
                GenericRepositoryEntity.Entity.Password = BCrypt.Net.BCrypt.HashPassword(auth.Password);
                teacherRepository.Add(GenericRepositoryEntity.Entity);
            }));
    }
}