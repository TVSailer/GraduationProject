using Admin.View;
using Admin.View.Moduls.Event;
using Admin.View.Moduls.Lesson;
using Admin.View.Moduls.News;
using Admin.View.Moduls.Teacher;
using Admin.View.Moduls.Visitor;
using Admin.ViewModels;
using Admin.ViewModels.Lesson;
using DataAccess.Postgres;
using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;
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

    public AdminMainViewModel(
        ApplicationDbContext dbContext)
    {
        //OnLoadEventsManagemetnView = new MainCommand(
        //    _ => eventMenegment.InitializeComponents("🎭 Управление мероприятиями"));
        
        OnLoadTeachersManagemetnView = new MainCommand(
            _ =>
            {
            });

        OnLoadLessonsManagemetnView = new MainCommand(
            _ => AdminDI.GetService<ManagementView<LessonEntity, LessonCard>>().InitializeComponents(null));
        
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
