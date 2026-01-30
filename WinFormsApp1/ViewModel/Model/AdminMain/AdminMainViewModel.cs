using Admin.Commands_Handlers.Managment;
using Admin.ViewModel.Interface;
using DataAccess.Postgres;
using Logica;
using MediatR;
using System.Windows.Input;
using Admin.ViewModels.Lesson;

public class AdminMainViewModel : IViewModele
{
    public ICommand OnLoadEventsManagemetnView { get; private set; }
    public ICommand OnLoadNewsManagemetnView { get; private set; }
    public ICommand OnLoadLessonsManagemetnView { get; private set; }
    public ICommand OnLoadTeachersManagemetnView { get; private set; }
    public ICommand OnLoadVisitorsManagemetnView { get; private set; }

    public AdminMainViewModel(
        ApplicationDbContext dbContext, IMediator mediator)
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
                mediator.Send(new InitializeUI<LessonMangment>());
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
                // AdminDI.GetService<ManagementView<
                //     VisitorEntity,
                //     VisitorCard>>().InitializeComponents(null);
            });

    }
}
