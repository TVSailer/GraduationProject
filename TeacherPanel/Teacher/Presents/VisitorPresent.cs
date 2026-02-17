using DataAccess.Postgres;
using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;
using Logica;
using System.ComponentModel.DataAnnotations;
using Teacher.Forms.Visitors;

namespace Teacher.Presents
{
    public class VisitorPresent
    {
        public readonly VisitorsRepository VRepository;
        public readonly LessonsRepository LRepository;
        public readonly ApplicationDbContext DbContext;
        public LessonEntity Lesson { get; set; }

        public static event Action EventOnAddData;
        public static event Action EventOnDeleteData;
        public static event Action EventOnUpdateData;
        public static event Action EventOnCloseForm;

        private DataGridView gridView;

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string DateBirth { get; set; }
        public string NumberPhone { get; set; }

        public VisitorPresent(ApplicationDbContext dbContext, LessonEntity lesson)
        {
            DbContext = dbContext;
            VRepository = new(dbContext);
            LRepository = new(dbContext);

            Lesson = lesson;
        }
        internal void OnAdd()
        {
            var userAuth = UserAuthService.CreateAuthUser(Surname, Name, DbContext);

            var visitor = new VisitorEntity()
            {
                Name = Name,
                Surname = Surname,
                Patronymic = Patronymic,
                NumberPhone = NumberPhone,
                DateBirth = DateBirth,
                Login = userAuth.Login,
                Password = userAuth.Password,
            };
            //Валерий 9104 Т194ер100ег10ераВал109ерий 
            var results = new List<ValidationResult>();
            var context = new ValidationContext(visitor);

            if (!Validator.TryValidateObject(visitor, context, results, true))
                foreach (var error in results)
                    LogicaMessage.MessageOk(error.ErrorMessage);
            else
            {
                VRepository.Add(visitor);
                LRepository.AddRelationWithVisitor(Lesson, visitor);

                OnLoadData();

                LogicaMessage.MessageOk("Данные успешно добавлены");
                
                EventOnAddData?.Invoke();
            }
        }

        internal void OnLoadData()
            => OnLoadData(ref gridView);

        internal void OnLoadData(ref DataGridView gridView)
        {
            if (this.gridView == null) this.gridView = gridView;
            var lesson = LRepository.Get(Lesson.Id);
            gridView.DataSource = lesson.Visitors;
        }

        internal void OnSerchData(string[] text, ref DataGridView gridView)
            => gridView.DataSource = LRepository.GetVisitors(Lesson.Id, text[0], text[1], text[2]);

        internal void OnShowFormAdding()
            => new FormAddingVisitor(this).Show();

        internal void OnDelete()
        {
            if (gridView.SelectedRows.Count == 1)
                if (LogicaMessage.MessageYesNo("Вы уверены, что хотите безовратно удалить запись?"))
                {
                    VRepository.Delete(new InClassName<VisitorEntity>(Convert.ToInt32(gridView.SelectedRows[0].Cells[0].Value)));
                    LogicaMessage.MessageOk("Данные успешно удалились");
                }

            OnLoadData();
            EventOnDeleteData?.Invoke();
        }

        internal void OnShowFormUpdating()
        {
            if (gridView.SelectedRows.Count == 1)
                new FormUpdatingVisitor(this, gridView.SelectedRows[0]).Show();
        }

        internal void OnUpdate(DataGridViewRow row)
        {
            var userAuth = UserAuthService.CreateAuthUser(Surname, Name, DbContext);

            var visitor = new VisitorEntity()
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
            var context = new ValidationContext(visitor);

            if (!Validator.TryValidateObject(visitor, context, results, true))
                foreach (var error in results)
                    LogicaMessage.MessageOk(error.ErrorMessage);
            else
            {
                VRepository.Update(Convert.ToInt32(row.Cells[0].Value.ToString()), visitor);

                OnLoadData();

                LogicaMessage.MessageOk("Данные успешно обновились");

                EventOnUpdateData?.Invoke();
            }
        }

        internal void Close(Form form)
        {
            form.Close();
            EventOnCloseForm?.Invoke();
        }
    }
}
