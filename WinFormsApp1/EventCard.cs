using Logica;
using Logica.Extension;


namespace AdminApp.Controls
{
    public class EventCard : ObjectCard
    {
        public int Id { get; }
        private string _title;
        private string _date;
        private string _location;
        private string _organizer;
        private string _participants;

        public EventCard(int id, string title, string date, string location, string organizer, string participants) : base(id)
        {
            Id = id;
            _title = title;
            _date = date;
            _location = location;
            _organizer = organizer;
            _participants = participants;
            CreateContent();
        }

        public override Control Content()
            => new TableLayoutPanel()
                .With(t => t.Dock = DockStyle.Fill)
                .ControlAddIsRowsPercentV2(
                    new Label().LabelHeard(_title)
                    .With(t => t.ForeColor = Color.DarkBlue), 40)
                .ControlAddIsRowsPercentV2(
                    new Label().LabelMini($"📅 {_date} | 📍 {_location}")
                    .With(t => t.ForeColor = Color.Gray), 30)
                .ControlAddIsRowsPercentV2(
                    new Label().LabelMini($"👨‍💼 {_organizer}")
                    .With(t => t.ForeColor = Color.Gray), 30)
                .ControlAddIsRowsPercentV2(
                    new Label().LabelMini($"👥 {_participants}")
                    .With(t => t.ForeColor = Color.DarkGreen), 30);
    }
}
