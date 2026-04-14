using Domain.Entitys;
using Domain.Repository;
using Domain.Service.FielService.BaseFileService;
using Domain.Service.MementoService.BaseMementoService;
using UserInterface.Service.View.Base;
using Visitor.DI;
using Visitor.ViewModel.Main;

namespace Visitor
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            var di = new MainDI();

            var authFileService = di.GetService<IAuthFileService>();

            if (authFileService.Exists())
            {
                var auth = authFileService.ReadAuth();
                var visitor = di
                    .GetService<IRepository<VisitorEntity>>()
                    .Get()
                    .ToArray()
                    .SingleOrDefault(v => v.AuthEntity.Equals(auth.login, auth.password));

                if (visitor is not null)
                    di.GetService<IMementoService<VisitorEntity>>().Set(visitor);
            }

            var controlView = di.GetService<IControlView>();
            controlView.LoadView<MainPanelViewModel>();

            Application.Run(controlView.Form);
        }
    }
}