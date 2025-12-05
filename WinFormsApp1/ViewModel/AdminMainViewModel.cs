using AdminApp.Forms;
using DataAccess.Postgres;
using Logica;
using Logica.DI;
using System.Windows.Input;
using WinFormsApp1;
using WinFormsApp1.View.Event;

public class AdminMainViewModel 
{
    public ICommand OnLoadEventsManagemetnView { get; private set; }
    public ICommand OnLoadNewsManagemetnView;
    public ICommand OnLoadLessonsManagemetnView;
    public ICommand OnLoadTeachersManagemetnView;
    public ICommand OnLoadAttendancesManagemetnView;

    public AdminMainViewModel(ApplicationDbContext dbContext)
    {
        OnLoadEventsManagemetnView = new MainCommand(
            _ =>
            {
                using (var scope = new ContainerScoped(AdminConteiner.Container))
                {
                    scope.GetService<EventManagementView>().InitializeComponent();
                }
            });
    }
}
