using Admin.View.Moduls.Lesson;
using Admin.ViewModel.NotifuPropertyViewModel;
using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;
using Logica;
using Logica.CustomAttribute;
using Logica.DI;
using System.Windows.Input;
using WinFormsApp1;
using NotNullAttribute = Logica.CustomAttribute.NotNullAttribute;

namespace Admin.ViewModel.Lesson
{
    public abstract class LessonDataViewModel : NotifyPropertyImagesViewModel
    {
        public readonly List<TeacherEntity> teachers;

        public ICommand OnBack { get; protected set; }
        public ICommand OnSave { get; protected set; }
        public ICommand OnBindingTeacher { get; protected set; }

        protected LessonEntity lesson = new();

        [RequiredCustom] public string Name { get; set => Set(ref field, value); }
        [RequiredCustom] public string Description { get; set => Set(ref field, value); }
        [RequiredCustom] public string Category { get; set => Set(ref field, value); }
        [RequiredCustom] public string Schedule { get; set => Set(ref field, value); }
        [RequiredCustom] public string Location { get; set => Set(ref field, value); }
        [MaxParticipants] public string MaxParticipants { get; set => Set(ref field, value); }
        [NotNull] public TeacherEntity Teacher { get; set => Set(ref field, value); }

        public LessonDataViewModel(LessonsRepository lessonsRepository, TeacherRepository teacherRepository)
        {
            teachers = teacherRepository.Get();

            OnBindingTeacher = new MainCommand(
            _ =>
            {
                new LessonLinkingToTeacherView(this).InitializeComponents();
            });

            OnBack = new MainCommand(
             _ =>
             {
                 using (var scope = new ContainerScoped(AdminDIConteiner.Container))
                     scope.GetService<LessonManagementView>().InitializeComponents();
             });

            OnSave = new MainCommand(
            _ =>
            {
                if (Validatoreg.TryValidObject(this, out var results, false))
                {
                    List<ImgLessonEntity> imgs = new();

                    SelectedImg.ForEach(i => imgs.Add(new ImgLessonEntity(i.Key)));

                    lessonsRepository.AddRelationWithLesson(Teacher,
                        new LessonEntity(Teacher, int.Parse(MaxParticipants), Category, Name, Description, Schedule, Location, imgs));

                    LogicaMessage.MessageOk("Кружок успешно добавленно!");
                    OnBack.Execute(null);
                }
                else { results.ForEach(r => r.MemberNames.ForEach(n => OnMassegeErrorProvider(r.ErrorMessage, n))); }
            });
        }
    }
}
