using UserInterface.Service.View;
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
            var controlView = di.GetService<IControlView>();
            controlView.LoadView<MainPanelViewModel>();

            Application.Run(controlView.Form);
        }
    }
}