using Admin.Forms.Lesson;
using Admin.Forms.Teacher;
using DataAccess.Postgres;
using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Admin.Presents
{
    public class LessonPresent
    {

        public readonly LessonsRepository Repository;
        public readonly ApplicationDbContext DbContext;

        private DataGridView gridView;

        public string Name { get; set; }
        public TeacherEntity Teacher { get; set; }

        public LessonPresent(ApplicationDbContext dbContext)
        {
            Repository = new(dbContext);
            DbContext = dbContext;
        }

        internal void OnAdd()
        {
            var lesson = new LessonEntity()
            {
                Name = Name,
                Teacher = Teacher,
            };

            var results = new List<ValidationResult>();
            var context = new ValidationContext(lesson);

            if (!Validator.TryValidateObject(lesson, context, results, true))
                foreach (var error in results)
                    Message(error.ErrorMessage);
            else
            {
                Repository.Add(lesson);
                gridView.DataSource = Repository.Get();
                Message("Данные успешно добавлены");
            }
        }

        internal void OnLoadData(ref DataGridView gridView)
        {
            this.gridView = gridView;
            DbContext.Lessons.Load();
            DbContext.Teachers.Load();
            gridView.DataSource = DbContext.Lessons.Local.ToBindingList();
        }

        internal void OnShowFormAdding()
        {
            new FormAddingLesson(this).Show();
        }

        public void Message(object? obj)
        {
            if (obj is string text)
                MessageBox.Show((string)obj, "", MessageBoxButtons.OK);
        }

        public bool MessageYesNo(object? obj)  
        {
            if (obj is string text)
                return MessageBox.Show((string)obj, "", MessageBoxButtons.YesNo) == DialogResult.Yes;

            return false;
        }

        internal void OnDelete()
        {
            if (gridView.SelectedRows.Count == 1)
                if (MessageYesNo("Вы уверены, что хотите безовратно удалить запись?"))
                {
                    Repository.Delete(Convert.ToInt32(gridView.SelectedRows[0].Cells[0].Value));
                    gridView.DataSource = Repository.Get();
                    Message("Данные успешно удалились");
                }
        }

        internal void OnUpdate()
        {
            if (gridView.SelectedRows.Count == 1)
                new FormUpdatingLesson(this, gridView.SelectedRows[0]).Show();
        }

        internal void OnUpdate(DataGridViewRow row)
        {
            var lesson = new LessonEntity()
            {
                Name = Name,
                Teacher = Teacher,
            };

            var results = new List<ValidationResult>();
            var context = new ValidationContext(lesson);

            if (!Validator.TryValidateObject(lesson, context, results, true))
                foreach (var error in results)
                    Message(error.ErrorMessage);
            else
            {
                Repository.Update(Convert.ToInt32(row.Cells[0].Value.ToString()), lesson);
                gridView.DataSource = Repository.Get();
                Message("Данные успешно обновились");
            }
        }

        internal void OpenFormDataLessons()
        {
            new FormDataLessons(new LessonPresent(DbContext)).Show();
        }

        internal void OnSerchData(string[] text)
        {
            gridView.DataSource = Repository.Get(text[0], text[1]);
        }

        internal void OpenFormDataTeacher()
        {
            new FormDataTeachers(new TeacherPresent(DbContext)).Show();
        }
    }
}
