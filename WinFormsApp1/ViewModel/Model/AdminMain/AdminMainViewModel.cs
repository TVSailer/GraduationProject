using Admin.Commands_Handlers.Managment;
using Admin.ViewModel.Interface;
using DataAccess.Postgres;
using Logica;
using MediatR;
using System.Windows.Input;
using Admin.DI;
using Admin.View;
using Admin.View.ViewForm;
using Admin.ViewModel.Model.Visitor;
using Admin.ViewModels.Lesson;
using DataAccess.Postgres.Models;
using Ninject;

public class AdminMainViewModel : IFieldData
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
                 // AdminDI.GetService<ManagementView<
                 //     EventEntity,
                 //     EventCard>>().InitializeComponents(null);
             });

        OnLoadTeachersManagemetnView = new MainCommand(
            _ =>
            {
                // AdminDI.GetService<ManagementView<
                //     TeacherEntity,
                //     TeacherCard>>().InitializeComponents(null);
            });

        OnLoadLessonsManagemetnView = new MainCommand(
            _ =>
            {
                
                AdminDI.GetService<ManagmentEntityUi<LessonMangment, LessonEntity, LessonFieldSearch>>().InitializeComponents(null);
                // AdminDI.GetService<ManagementView<
                //     LessonEntity, 
                //     LessonCard>>().InitializeComponents(null);
            });
        
        OnLoadNewsManagemetnView = new MainCommand(
            _ =>
            {
            });
        
        OnLoadVisitorsManagemetnView = new MainCommand(
            _ =>
            {
                AdminDI.GetService<ManagmentEntityUi<VisitorMangment, VisitorEntity, VisitorFieldSearch>>().InitializeComponents(null);
            });

    }
}
