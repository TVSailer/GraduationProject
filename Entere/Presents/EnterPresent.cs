
using Admin;
using DataAccess.Postgres;
using DataAccess.Postgres.Repository;
using Entere.Forms;
using Logica;
using Teacher;
using Visitor;

namespace Entere.Presents
{
    class EnterPresent
    {

        public readonly VisitorsRepository VRepository;
        public readonly TeacherRepository TRepository;
        public readonly ApplicationDbContext DbContext;

        private readonly Dictionary<string, Func<string, string, bool>> authHandlers;
        private readonly Dictionary<string, Action> successHandlers;

        public Action IsEnter;

        public string Role { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string RepeatPassword { get; set; }

        public EnterPresent(ApplicationDbContext context)
        {
            TRepository = new(context);
            VRepository = new(context);
            DbContext = context;

            authHandlers = new() 
            {
                [Attributes.Teacher] = (login, password) => TRepository.VerifyTeacher(login, password),
                [Attributes.Visitor] = (login, password) => VRepository.VerifyVisitor(login, password),
                [Attributes.Admin] = (login, password) => AdminAuthService.VerifyAdmin(login, password)
            };

            successHandlers = new()
            {
                [Attributes.Teacher] = () => ProgramTeacher.Run(TRepository.Teacher),
                [Attributes.Visitor] = () => ProgramVisitor.Run(VRepository.Visitor),
                [Attributes.Admin] = () => ProgramAdmin.Run()
            };
        }

        internal void OnEnter()
        {
            if (authHandlers.TryGetValue(Role, out var func))
            {
                if (func(Login, Password))
                {
                    successHandlers[Role]();
                    IsEnter?.Invoke();
                }
                else
                    LogicaMessage.MessageOk("Неверный логин или пароль");
            }
            else
                LogicaMessage.MessageOk("Ошибка: неизвестная роль пользователя");
        }

        internal void OnShowReport()
        {
            new FormReport(this).Show();
        }

        internal void OnAddAdmin()
        {
            if (Password != RepeatPassword)
            {
                LogicaMessage.MessageOk("Пароли не совпадают");
                return;
            }
            AdminAuthService.CreateAdmin(Login, Password);
        }
    }
}

