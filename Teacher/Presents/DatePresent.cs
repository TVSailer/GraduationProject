using DataAccess.Postgres;
using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Teacher.Forms.Dates;
using Teacher.Forms.Visitors;
using Logica;

namespace Teacher.Presents
{
    public class DatePresent
    {

        public readonly DateAttendancesRepository DRepository;
        public readonly LessonsRepository LRepository;
        public readonly VisitorsRepository VRepository;
        public readonly ApplicationDbContext DbContext;
        public readonly TeacherEntity Teacher;

        private DataGridView gridView;

        public string Date { get; set; }
        public LessonEntity Lesson { get; set; }
        public List<VisitorEntity> Visitors { get; set; } = new();

        public DatePresent(ApplicationDbContext dbContext, TeacherEntity teacher)
        {
            DbContext = dbContext;

            DRepository = new(dbContext);
            LRepository = new(dbContext);
            VRepository = new(dbContext);

            Teacher = teacher;

            if (teacher.Lessons != null)
                Lesson = LRepository.Get(teacher.Lessons[0].Id);

            VisitorPresent.EventOnAddData += OnAddVisitorInDataGridView;
            VisitorPresent.EventOnDeleteData += OnLoadData;
        }

        internal void OnAdd(ref DataGridView gridView)
        {
            var date = new DateAttendanceEntity()
            {
                DbContext = DbContext,
                Date = Date,
                LessonId = Lesson.Id,
            };

            if (Validatoreg.TryValidObject(date)) return;

            DRepository.Add(date);
            DRepository.AddRelationWithLesson(date, Lesson);

            foreach (var vis in Visitors)
                DRepository.AddRelationWithVisitor(date, vis);

            OnLoadData();

            LogicaMessage.MessageOk("Данные успешно добавлены");
        }

        internal void OnLoadData()
            => OnLoadData(ref gridView);

        internal void OnLoadData(ref DataGridView gridView)
        {
            if (Lesson == null) return;
            if (this.gridView == null) this.gridView = gridView;
            else
            {
                this.gridView.Columns.Clear();
                this.gridView.Rows.Clear();
            }

            var lesson = LRepository.Get(Lesson.Id);
            var dates = DRepository.Get(Lesson.Id);

            gridView.Columns.Add("Посетители", "");

            List<object> objs = new();

            foreach (var visitor in lesson.Visitors)
            {
                objs.Add(visitor.ToString());

                foreach (var date in dates)
                {
                    if (!gridView.Columns.Contains(date.Date))
                        gridView.Columns.Add(date.Date, date.Date);

                    var rez = date.Visitors
                        .FirstOrDefault(d => d.Id == visitor.Id) == null;

                    if (!rez)
                        objs.Add("отсутствовал");
                    else
                        objs.Add("");
                }
                gridView.Rows.Add(objs.ToArray());
                objs.Clear();
            }
        }

        internal void OnAddVisitorInDataGridView()
        {
            var lesson = LRepository.Get(Lesson.Id);
            gridView.Rows.Add(lesson.Visitors[^1]);
        }
            
        internal void OnSerchData(string[] text, ref DataGridView gridView)
            => gridView.DataSource = DRepository.Get(text[0], text[1]);

        internal void OnShowFormAddingDate(ref DataGridView gridView)
        {
            if (Lesson == null)
                return;

            var visitors = LRepository.Get(Lesson.Id).Visitors;
            visitors.ForEach(v => v.Lessons = null);

            new FormAddingDateAttendance(this, visitors.ToArray(), gridView).Show();
        }

        internal void OnDelete(ref DataGridView dataGridView)
        {
            if (dataGridView.SelectedRows.Count == 1)
                if (LogicaMessage.MessageYesNo("Вы уверены, что хотите безовратно удалить запись?"))
                {
                    DRepository.Delete(Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value));
                     LogicaMessage.MessageOk("Данные успешно удалились");
                }
            OnLoadData();
        }

        internal void OnUpdate(ref DataGridView dataGridView)
        {
            //if (dataGridView.SelectedRows.Count == 1)
            //    new FormUpdatingVisitor(this, dataGridView.SelectedRows[0]).Show();
        }

        internal void OnUpdate(DataGridViewRow row)
        {
            //var visitor = new VisitorEntity()
            //{
            //    Name = Name,
            //    Surname = Surname,
            //    Patronymic = Patronymic,
            //    NumberPhone = NumberPhone,
            //    DateBirth = DateBirth,
            //    Login = Generating.GenerateLogin(Surname),
            //    Password = Generating.GeneratePassword(Surname + Name)
            //};

            //var results = new List<ValidationResult>();
            //var context = new ValidationContext(visitor);

            //if (!Validator.TryValidateObject(visitor, context, results, true))
            //    foreach (var error in results)
            //        Message(error.ErrorMessagePropertyArgs);
            //else
            //{
            //    VRepository.Update(Convert.ToInt32(row.Cells[0].Value.ToString()), visitor);
            //    Message("Данные успешно обновились");
            //}
        }

        internal void OpenFormDataVisitors()
        {
            new FormDataVisitors(new VisitorPresent(DbContext, Lesson)).Show();
        }

        internal void OnChosseLesson(string nameLesson)
        {
            Lesson = LRepository.Get(nameLesson);
            OnLoadData();
        }
    }
}
