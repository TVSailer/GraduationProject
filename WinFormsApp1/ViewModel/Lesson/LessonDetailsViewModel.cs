using Admin.ViewModel.NotifuPropertyViewModel;
using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;
using Logica;
using System.Diagnostics.CodeAnalysis;
using System.Windows.Input;

namespace Admin.ViewModel.Lesson
{
    public class LessonDetailsViewModel : LessonDataViewModel
    {
        public ICommand OnDelete { get; private set; }
        public ICommand OnControlVisitros { get; private set; }

        [NotNull]
        public LessonEntity? LessonEntity
        {
            get;
            set
            {
                if (value is null) throw new ArgumentNullException();

                Name = value.Name;
                Description = value.Description;
                Category = value.Category;
                Schedule = value.Schedule;
                Location = value.Location;
                MaxParticipants = value.MaxParticipants.ToString();
                Teacher = value.Teacher;

                value.ImgsLesson?.ForEach(img => SelectedImg.Add(img.Url, false));

                field = value;
            }
        }
        public LessonDetailsViewModel(LessonsRepository lessonsRepository, TeacherRepository teacherRepository) : base(lessonsRepository, teacherRepository)
        {
            OnControlVisitros = new MainCommand(
                _ =>
                {

                });

            OnDelete = new MainCommand(
                _ =>
                {
                    lessonsRepository.Delete(LessonEntity);
                    OnBack.Execute(this);
                });

            OnSave = new MainCommand(
               _ =>
               {
                   if (Validatoreg.TryValidObject(this, out var results, false))
                   {
                       List<ImgLessonEntity> imgs = new();

                       SelectedImg.ForEach(i => imgs.Add(new ImgLessonEntity(i.Key)));

                       lessonsRepository.Update(LessonEntity.Id,
                           new LessonEntity(Teacher, int.Parse(MaxParticipants), Category, Name, Description, Schedule, Location, imgs));

                       LogicaMessage.MessageOk("Кружок успешно отредактирован!");
                       OnBack.Execute(this);
                   }
                   else { results.ForEach(r => r.MemberNames.ForEach(n => OnMassegeErrorProvider(r.ErrorMessage, n))); }
               });
        }

        public void Initialize(LessonEntity lesson)
            => LessonEntity = lesson;
    }
}
