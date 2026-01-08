using Admin.View.Moduls.Event;
using Admin.View.Moduls.Lesson;
using Admin.View.Moduls.News;
using Admin.View.Moduls.Teacher;
using Admin.View.Moduls.Visitor;
using DataAccess.Postgres;
using Logica;
using Logica.DI;
using System.Windows.Input;
using WinFormsApp1;

public class AdminMainViewModel 
{
    public ICommand OnLoadEventsManagemetnView { get; private set; }
    public ICommand OnLoadNewsManagemetnView { get; private set; }
    public ICommand OnLoadLessonsManagemetnView { get; private set; }
    public ICommand OnLoadTeachersManagemetnView { get; private set; }
    public ICommand OnLoadVisitorsManagemetnView { get; private set; }

    public AdminMainViewModel(ApplicationDbContext dbContext)
    {
        OnLoadEventsManagemetnView = new MainCommand(
            _ =>
            {
                using (var scope = new ContainerScoped(AdminDIConteiner.Container))
                {
                    scope.GetService<EventManagementView>().InitializeComponents();
                }
            });
        
        OnLoadTeachersManagemetnView = new MainCommand(
            _ =>
            {
                using (var scope = new ContainerScoped(AdminDIConteiner.Container))
                {
                    scope.GetService<TeacherManagementView>().InitializeComponents();
                }
            });

        OnLoadLessonsManagemetnView = new MainCommand(
            _ =>
            {
                using (var scope = new ContainerScoped(AdminDIConteiner.Container))
                {
                    scope.GetService<LessonManagementView>().InitializeComponents();
                }
            });
        
        OnLoadNewsManagemetnView = new MainCommand(
            _ =>
            {
                using (var scope = new ContainerScoped(AdminDIConteiner.Container))
                {
                    scope.GetService<NewsManagementView>().InitializeComponents();
                }
            });
        
        OnLoadVisitorsManagemetnView = new MainCommand(
            _ =>
            {
                using (var scope = new ContainerScoped(AdminDIConteiner.Container))
                {
                    scope.GetService<VistorManagmentView>().InitializeComponents();
                }
            });

    }
}
