using DataAccess.Postgres.Models;
using Logica;
using Logica.Extension;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace AdminApp.Controls
{
    public class EventCard : ObjectCard
    {
        public EventCard(EventEntity eventEntity) : base(eventEntity.Id)
        {
            DataContext = eventEntity;
            CreateContent();
        }

        public override Control Content()
            => new TableLayoutPanel()
                .With(t => t.Dock = DockStyle.Fill)
                .ControlAddIsRowsPercentV2(
                    FactoryElements.Label_11("")
                    .With(t => t.ForeColor = Color.DarkBlue)
                    .With(t => t.DataBindings.Add(new Binding("Text", DataContext, "Title"))), 40)
                .ControlAddIsRowsPercentV2(
                    FactoryElements.Label_09("")
                    .With(t => t.ForeColor = Color.Gray)
                    .With(t => t.DataBindings.Add(new Binding("Text", DataContext, "Date"))), 30)
                .ControlAddIsRowsPercentV2(
                    FactoryElements.Label_09("")
                    .With(t => t.ForeColor = Color.Gray)
                    .With(t => t.DataBindings.Add(new Binding("Text", DataContext, "Organizer", false, DataSourceUpdateMode.OnPropertyChanged))), 30)
                .ControlAddIsRowsPercentV2(
                    FactoryElements.Label_09("")
                    .With(t => t.ForeColor = Color.DarkGreen)
                    .With(t => t.DataBindings.Add(new Binding("Text", DataContext, "CurrentParticipants", false, DataSourceUpdateMode.OnPropertyChanged))), 30);
    }
}
//                    new Label().Label_09($"📅 {Date} | 📍 {Location}")
//                    .With(t => t.ForeColor = Color.Gray), 30)
//                .ControlAddIsRowsPercentV2(
//                    new Label().Label_09($"👨‍💼 {Organizer}")
//                    .With(t => t.ForeColor = Color.Gray), 30)
//                .ControlAddIsRowsPercentV2(
//                    new Label().Label_09($"👥 {Participants}")
//                    .With(t => t.ForeColor = Color.DarkGreen), 30);