using Admin.Forms.Teacher;
using DataAccess.Postgres;
using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;
using Logica;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Admin.Presents
{
    public class TeacherPresent
    {
        public readonly TeacherRepository Repository;
        public readonly ApplicationDbContext DbContext;

        private DataGridView gridView;

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string DateBirth { get; set; }
        public string NumberPhone { get; set; }
        public List<LessonEntity> Lessons { get; set; }

        public TeacherPresent(ApplicationDbContext dbContext)
        {
            Repository = new(dbContext);
            DbContext = dbContext;
        }
        internal void OnAdd()
        {
            var userAuth = UserAuthService.CreateUser(Surname, Name, DbContext);

            var teacher = new TeacherEntity()
            {
                Name = Name,
                Surname = Surname,
                Patronymic = Patronymic,
                NumberPhone = NumberPhone,
                DateBirth = DateBirth,
                Login = userAuth.Login,
                Password = userAuth.Password 
            };

            var results = new List<ValidationResult>();
            var context = new ValidationContext(teacher);

            if (!Validator.TryValidateObject(teacher, context, results, true))
                foreach (var error in results)
                    Message(error.ErrorMessage);
            else
            {
                Repository.Add(teacher);
                Message("Данные успешно добавлены");
            }
        }

        internal void OnLoadData(ref DataGridView gridView)
        {
            this.gridView = gridView;
            DbContext.Teachers.Load();
            gridView.DataSource = DbContext.Teachers.Local.ToBindingList();
        }

        internal void OnSerchData(string[] text)
            => gridView.DataSource = Repository.Get(text[0], text[1], text[2]);

        internal void OnShowFormAdding()
            => new FormAddingTeacher(this).Show();

        public void Message(object? obj)
        {
            if (obj is string text)
                MessageBox.Show((string)obj, "", MessageBoxButtons.OK);
        }
        
        public bool MessageYesNo(object? obj)
        {
            if (obj is string text)
            {
                var mes = MessageBox.Show((string)obj, "", MessageBoxButtons.YesNo);
                return mes == DialogResult.Yes;
            }

            return false;
        }

        internal void OnDelete()
        {
            if (gridView.SelectedRows.Count == 1)
                if (MessageYesNo("Вы уверены, что хотите безовратно удалить запись?"))
                {
                    Repository.Delete(Convert.ToInt32(gridView.SelectedRows[0].Cells[0].Value));
                    Message("Данные успешно удалились");
                }

            gridView.DataSource = Repository.Get();
        }

        internal void OnUpdate()
        {
            if (gridView.SelectedRows.Count == 1)
                new FormUpdatingTeacher(this, gridView.SelectedRows[0]).Show();
        }

        internal void OnUpdate(DataGridViewRow row)
        {
            var userAuth = UserAuthService.CreateUser(Surname, Name, DbContext);
            var teacher = new TeacherEntity()
            {
                Name = Name,
                Surname = Surname,
                Patronymic = Patronymic,
                NumberPhone = NumberPhone,
                DateBirth = DateBirth,
                Lessons = Lessons,
                Login = userAuth.Login,
                Password = userAuth.Password
            };

            var results = new List<ValidationResult>();
            var context = new ValidationContext(teacher);

            if (!Validator.TryValidateObject(teacher, context, results, true))
                foreach (var error in results)
                    Message(error.ErrorMessage);
            else
            {
                Repository.Update(Convert.ToInt32(row.Cells[0].Value.ToString()), teacher);
                gridView.DataSource = Repository.Get();
                Message("Данные успешно обновились");
            }
        }
    }
}
