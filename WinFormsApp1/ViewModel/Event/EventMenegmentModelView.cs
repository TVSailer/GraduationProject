using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;
using Logica;
using Logica.DI;
using System.Windows.Input;
using WinFormsApp1;
using WinFormsApp1.View;
using WinFormsApp1.View.Event;

public class EventMenegmentModelView
{
    public ICommand OnBack { get; private set; }
    public ICommand OnLoadAddView { get; private set; }
    public ICommand OnLoadDetailsView { get; private set; }

    public readonly List<EventEntity> EventEntities = new();

    public EventMenegmentModelView(AdminMainView mainForm, EventRepository eventRepository)
    {
        EventEntities = eventRepository.Get();

        OnBack = new MainCommand(
            _ => mainForm.InitializeComponent());

        OnLoadDetailsView = new MainCommand(
            _ =>
            {
                using (var scope = new ContainerScoped(AdminConteiner.Container))
                {
                    scope.GetService<EventDetailsView>().InitializeComponents();
                }
            });

        OnLoadAddView = new MainCommand(
            _ =>
            {
                using (var scope = new ContainerScoped(AdminConteiner.Container))
                {
                    scope.GetService<AddEventView>().InitializeComponents();
                }
            });
    }
}
