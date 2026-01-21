using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;

namespace Admin.ViewModels.Lesson
{
    //[FieldInfoSerch("Категория")]
    //public string Category { get; set; }
    //public List<string> Categorys = new() { "Пусто" };
    //public List<TeacherEntity> Teachers = new();
    public class LessonSerch : SerchManagment<LessonEntity>
    {

        [FieldInfoSerch("Название")]
        public string Name { get; set; }

        [FieldInfoSerch("Имя преподователя")]
        public string TeacherName { get; set; }

        [FieldInfoSerch("Фамилия преподователя")]
        public string TeacherSurname { get; set; }

        public override Func<List<LessonEntity>, List<LessonEntity>> OnSerhFunk { get; protected set; }
        public override Action OnClearSerchFunk { get; protected set; }

        public LessonSerch(LessonsRepository lessonsRepository, TeacherRepository teacherRepository) : base(lessonsRepository) 
        {
            //Teachers = teacherRepository.Get();

            //lessonsRepository.Get().ForEach(e =>
            //{
            //    if (!Categorys.Contains(e.Category))
            //        Categorys.Add(e.Category);
            //});

            OnClearSerchFunk = () =>
            {
                Name = "";
                TeacherName = "";
                TeacherSurname = "";
            };

            OnSerhFunk = (entitys) =>
            {
                return entitys
                    //.Where(e => Category == "Пусто" ? true : e.Category == Category)
                    .Where(e => e.Name.StartesWith(Name))
                    .Where(e => e.Teacher.FIO.Name.StartesWith(TeacherName))
                    .Where(e => e.Teacher.FIO.Surname.StartesWith(TeacherSurname))
                    .ToList();

            };
        }
    }
}
