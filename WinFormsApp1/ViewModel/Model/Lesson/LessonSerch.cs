using Admin.ViewModel.Managment;
using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;

namespace Admin.ViewModels.Lesson
{
    public class LessonSerch : SerchManagment<LessonEntity>
    {
        public List<LessonCategoryEntity> category = [new("")];

        [ComboBoxFieldUi("Категория", nameof(category))]
        public LessonCategoryEntity Category
        {
            get;
            set
            {
                if (value == field) return;
                field = value;
                OnPropertyChanged();
            }
        } = new ("");

        [BaseFieldUi("Название")]
        public string Name
        {
            get;
            set
            {
                if (value == field) return;
                field = value;
                OnPropertyChanged();
            }
        } = "";

        [BaseFieldUi("Имя преподователя")]
        public string TeacherName
        {
            get;
            set
            {
                if (value == field) return;
                field = value;
                OnPropertyChanged();
            }
        } = "";

        [BaseFieldUi("Фамилия преподователя")]
        public string TeacherSurname
        {
            get;
            set
            {
                if (value == field) return;
                field = value;
                OnPropertyChanged();
            }
        } = "";

        public sealed override Func<List<LessonEntity>, List<LessonEntity>> OnSerhFunk
        {
            get;
            protected set;
        }

        public sealed override Action OnClearSerchFunk
        {
            get;
            protected set;
        }

        public LessonSerch(LessonsRepository lessonsRepository, LessonCategoryRepositroy categoryRepository) : base(
            lessonsRepository)
        {
            categoryRepository
                .Get()
                .ForEach(x => category.Add(x));

            OnClearSerchFunk = () =>
            {
                Name = "";
                TeacherName = "";
                TeacherSurname = "";
                Category = category[0];
            };

            OnSerhFunk = (entitys) =>
            {
                return entitys
                    .Where(e => Category.Equals(category[0])|| e.Category.Equals(Category))
                    .Where(e => e.Name.StartsWith(Name))
                    .Where(e => e.Teacher.FIO.Name.StartsWith(TeacherName))
                    .Where(e => e.Teacher.FIO.Surname.StartsWith(TeacherSurname))
                    .ToList();
            };
        }
    }
}
