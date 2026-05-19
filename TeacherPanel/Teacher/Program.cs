using Domain.Enum;
using Domain.Service.AuthService.BaseAuhtService;
using Domain.Service.ControlViewService.BaseControlView;
using Teacher.DI;
using Teacher.ViewModel.Enter;
using Teacher.ViewModel.Main;

namespace Teacher
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            ApplicationConfiguration.Initialize();

            var di = new MainDI();

            LoadTeahcerPanel(di);
        }

        private static void LoadTeahcerPanel(MainDI di)
        {
            var controlView = di.GetService<IControlViewService>();
            var authService = di.GetService<IAuthService>();

            if (authService.IsRoleAuth(UserRole.Teacher))
            {
                if (authService.IsSaveAuth(UserRole.Teacher))
                    controlView.LoadView<MainPanelViewModel>();
                else controlView.ShowDialog<EnterPanelViewModel>();
            }
            else
                controlView.ShowDialog<EnterPanelViewModel>();
        }
    }
}