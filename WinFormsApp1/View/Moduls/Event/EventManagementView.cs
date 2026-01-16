using Admin.View;
using DataAccess.Postgres.Models;
using Logica;
using Logica.DI;
using WinFormsApp1;
using WinFormsApp1.View;

namespace Admin.View.Moduls.Event
{
    public partial class EventManagementView 
    {
        private new readonly EventMenegmentModelView context;

        public EventManagementView(AdminMainView mainForm, EventMenegmentModelView modelView) //: base(mainForm, modelView, "🎭 Управление мероприятиями")
        {
            context = modelView;
        }

        
    }

}
