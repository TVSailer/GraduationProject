using Admin.View.Moduls.Event;
using Admin.ViewModels;
using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;
using Logica;
using Logica.DI;
using System.Windows.Input;
using WinFormsApp1;
using WinFormsApp1.View;

public class EventMenegmentModelView 
{
    private List<string> categorys = new() { "Пусто" };
    private string title = "";
    private string category = "";
    private string stDate = DateTime.Now.ToString();
    private string enDate = DateTime.Now.ToString();

    //public override ICommand OnSerch { get; set; }
    //public override ICommand OnClearSerch { get; set; }

    public List<string> Categorys
    {
        get => categorys;
        private set
        {
            if (categorys.SequenceEqual(value))
                return;

            categorys = value;
        }
    }

    public EventMenegmentModelView(AdminMainView mainForm, EventRepository eventRepository)
    {
        eventRepository.Get().ForEach(e =>
        {
            if (!Categorys.Contains(e.Category))
                Categorys.Add(e.Category);
        });

        //OnSerch = new MainCommand(
        //    _ =>
        //    {
        //        // data = eventRepository.Get()
        //        //.Where(e => e.Title.StartsWith(Title))
        //        //.Where(e => Category == "Пусто" ? true : e.Category == Category)
        //        //.Where(e => DateTime.Parse(StartDate) < DateTime.Parse(e.Date) && DateTime.Parse(EndDate) > DateTime.Parse(e.Date))
        //        //.ToList();
        //    });

        //OnClearSerch = new MainCommand(
        //    _ =>
        //    {
        //        //data = eventRepository.Get();
        //    });

        //OnLoadDetailsView = new MainCommand(
        //    obj =>
        //    {
        //        if (obj is EventEntity ev)
        //            using (var scope = AdminDI.CreateDIScope())
        //                scope.GetService<EventDetailsView>().InitializeComponents();
        //    });

        //OnLoadAddingView = new MainCommand(
        //    _ =>
        //    {
        //        using (var scope = AdminDI.CreateDIScope())
        //            scope.GetService<EventAddingView>().InitializeComponents();
        //    });
    }

}
