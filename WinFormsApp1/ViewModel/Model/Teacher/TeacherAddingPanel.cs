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
                var entity = GenericRepositoryEntity.GetEntity();

                var auth = UserAuthService.CreateAuthUser(entity.FIO.Name, 
                    teacherRepository
                        .Get()
                        .Select(t => t.Password)
                        .ToArray());

                LogicaMessage.MessageInfo($" Логин: {auth.Login}\nПароль: {auth.Password}");

                entity.Login = auth.Login;
                entity.Password = BCrypt.Net.BCrypt.HashPassword(auth.Password);
                teacherRepository.Add(entity);
            }));
    }
}