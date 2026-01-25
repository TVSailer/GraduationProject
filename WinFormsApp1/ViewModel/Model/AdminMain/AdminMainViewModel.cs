using System.Windows.Input;
using Admin.View;
using DataAccess.Postgres;
using DataAccess.Postgres.Models;
using Logica;
using WinFormsApp1;

public class AdminMainViewModel 
{
    public ICommand OnLoadEventsManagemetnView { get; private set; }
    public ICommand OnLoadNewsManagemetnView { get; private set; }
    public ICommand OnLoadLessonsManagemetnView { get; private set; }
    public ICommand OnLoadTeachersManagemetnView { get; private set; }
    public ICommand OnLoadVisitorsManagemetnView { get; private set; }

    public AdminMainViewModel(
        ApplicationDbContext dbContext)
    {
        OnLoadEventsManagemetnView = new MainCommand(
             _ =>
             {
                 AdminDI.GetService<ManagementView<
                     EventEntity,
                     EventCard>>().InitializeComponents(null);
             });

        OnLoadTeachersManagemetnView = new MainCommand(
            _ =>
            {
                AdminDI.GetService<ManagementView<
                    TeacherEntity,
                    TeacherCard>>().InitializeComponents(null);
            });

        OnLoadLessonsManagemetnView = new MainCommand(
            _ =>
            {
                AdminDI.GetService<ManagementView<
                    LessonEntity, 
                    LessonCard>>().InitializeComponents(null);
            });
        
        OnLoadNewsManagemetnView = new MainCommand(
            _ =>
            {
            });
        
        OnLoadVisitorsManagemetnView = new MainCommand(
            _ =>
            {
            });

    }
}
