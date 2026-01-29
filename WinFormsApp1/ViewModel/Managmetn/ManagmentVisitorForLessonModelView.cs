using System.Windows.Input;
using Admin.ViewModel.Interface;
using Admin.ViewModel.Lesson;
using Admin.ViewModel.Model.Visitor;
using Admin.ViewModels.Lesson;
using DataAccess.Postgres.Models;
using Logica;

namespace Admin.ViewModel.Managment;

public class ManagmentVisitorForLessonModelView : PropertyChange, IViewModele
{
    public VisitorSerch SerchManagment { get; private set; }

    
    [ButtonInfoUI("Добавить существуещего участника")]
    public ICommand OnLoadExistingAddingView { get; private set; }

    [ButtonInfoUI("Добавить нового участника")]
    public ICommand OnLoadAddingView { get; private set; }

    [ButtonInfoUI("Назад")]
    public ICommand OnBack { get; private set; }

    public ICommand OnLoadDetailsView { get; private set; }

    public ManagmentVisitorForLessonModelView(
        VisitorSerch serchManagment,
        UI<VisitorEntity, VisitorDetailsPanel> uiDetailsVisitor,
        UI<VisitorEntity, VisitorAddingPanel> uiAddingVisitor,
        UI<LessonEntity, LessonDetailsPanel> uiDetailsLesson)
    {
        SerchManagment = serchManagment;

        OnBack = new MainCommand(
            _ => uiDetailsLesson.InitializeComponents(null));

        OnLoadDetailsView = new MainCommand(
            obj =>
            {
                if (obj is VisitorEntity val)
                {
                    uiDetailsVisitor.ViewModele.GenericRepositoryEntity.SetEntity(val);
                    uiDetailsVisitor.InitializeComponents(null);
                }
                else throw new ArgumentException();
            });

        OnLoadAddingView = new MainCommand(
            _ => uiAddingVisitor.InitializeComponents(null));
        
        // OnLoadExistingAddingView = new MainCommand(
        //     _ => existingAddingPanel.InitializeComponents(null));
    }
}