using System.Windows.Input;
using Admin.ViewModels;
using Admin.ViewModels.Lesson;
using Castle.Core.Internal;
using DataAccess.Postgres.Repository;
using Logica;

namespace WinFormsApp1.ViewModel.Model.Teacher;

[LinkingCommand(nameof(ManagmentModelView<>.OnLoadDetailsView))]
public class TeacherDetailsPanel : TeacherData
{
    [ButtonInfoUI("Удалить")] public ICommand OnDelete { get; protected set; }
    [ButtonInfoUI("Обновить")] public ICommand OnUpdate { get; protected set; }

    public TeacherDetailsPanel(TeacherRepository teacherRepository, LessonsRepository lessonsRepository) : base(teacherRepository, lessonsRepository)
    {
        OnUpdate = new MainCommand(
            _ => TryValidObject(() =>
            {
                teacherRepository.Update(GenericRepositoryEntity.Id, GenericRepositoryEntity.GetEntity());
            }));

        OnDelete = new MainCommand(_ =>
        {
            {
                if (lessonsRepository.Get().Select(l => l.TeacherId).Contains(GenericRepositoryEntity.Id))
                {
                    var rezult = LogicaMessage.MessageYesNo(
                        "Данное дейсвие несёт за собой удаление кружков, закрепленные за преподователем!\n" +
                        "Если хотите удалить только преподователя, то вам необходимо обновить данные в кружках поля 'Преподователь'!");

                    if (!rezult) return;
                }

                teacherRepository.Delete(GenericRepositoryEntity.Id);
                OnBack.Execute(this);
            }
        });
    }
}