using UserInterface.View;
using Visitor.DI;
using Visitor.DI.Module;

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

            var di = new VisitorDi();
            var controlView = di.GetService<ControlView>();
            controlView.LoadView(new MainFieldData());

            Application.Run(controlView.Form);
        }
    }
}