using Domain.Entitys;
using Domain.Enum;
using Domain.Repository;
using Domain.Service.AuthService.BaseAuhtService;
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

            var authService = di.GetService<IAuthService>();
            var controlView = di.GetService<IControlView>();
            var repositoryV = di.GetService<IRepository<VisitorEntity>>();

            LoadVisitor(authService, di, repositoryV, controlView);
            
        }

        private static void LoadVisitor(IAuthService authService, MainDI di, IRepository<VisitorEntity> repositoryV, IControlView controlView)
        {
            if (authService.IsSaveAuth(UserRole.Visitor, out var authEntity))
                di.GetService<IMementoService<VisitorEntity>>().Set(
                    repositoryV
                        .Get()
                        .AsEnumerable()
                        .Single(v => v.AuthEntity.Equals(authEntity)));
            else controlView.LoadView<MainPanelViewModel>();
        }
    }
}