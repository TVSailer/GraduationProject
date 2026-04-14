using Domain.Entitys;
using Domain.Repository;
using Domain.Service.FielService.BaseFileService;
using Domain.Service.MementoService.BaseMementoService;
using Teacher.DI;
using Teacher.ViewModel.Main;
using UserInterface.Service.View.Base;

namespace Teacher
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            ApplicationConfiguration.Initialize();

            var di = new MainDI();

            var authFileService = di.GetService<IAuthFileService>();

            if (authFileService.Exists())
            {
                var auth = authFileService.ReadAuth();
                var teacher = di
                    .GetService<IRepository<TeacherEntity>>()
                    .Get()
                    .ToArray()
                    .SingleOrDefault(v => v.AuthEntity.Equals(auth.login, auth.password));

                if (teacher is not null)
                    di.GetService<IMementoService<TeacherEntity>>().Set(teacher);
            }

            var controlView = di.GetService<IControlView>();
            controlView.LoadView<MainPanelViewModel>();

            Application.Run(controlView.Form);
        }
    }
}