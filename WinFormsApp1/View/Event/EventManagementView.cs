using AdminApp.Controls;
using Logica;
using WinFormsApp1.ViewModel;

namespace WinFormsApp1.View.Event
{
    public partial class EventManagementView
    {
        private EventMenegmentModelView context;

        public EventManagementView(Form mainForm, EventMenegmentModelView context)
        {
            this.context = context;
            InitializeComponent(mainForm);
        }

        public Form InitializeComponent(Form form)
            => form
                .With(m => m.Controls.Clear())
                .With(m => m.Text = "Управление мероприятиями")
                .With(m => m.Controls.Add(UIEvent(form)));

        private TableLayoutPanel UIEvent(Form form)
            => FactoryElements.TableLayoutPanel()
                .ControlAddIsRowsAbsoluteV2(FactoryElements.LabelTitle("🎭 Управление мероприятиями"), 70)
                .ControlAddIsRowsPercentV2(LoadEventCards(form), 70)
                .ControlAddIsRowsAbsoluteV2(
                    FactoryElements.TableLayoutPanel()
                        .ControlAddIsColumnPercentV2(FactoryElements.Button(""), 40)
                        .ControlAddIsColumnPercentV2(FactoryElements.Button("➕ Добавить", context, "OnLoadAddView"), 40)
                        .ControlAddIsColumnPercentV2(FactoryElements.Button("🔄 Обновить"), 40)
                        .ControlAddIsColumnPercentV2(FactoryElements.Button("⬅️ Назад", context, "OnBack"), 40), 90);


        private Control LoadEventCards(Form form)
            => new FlowLayoutPanel()
                .With(p => p.Dock = DockStyle.Fill)
                .With(p => p.AutoScroll = true)
                .With(p => p.BackColor = Color.WhiteSmoke)
                .With(p => p.Padding = new Padding(10))
                .With(p => context.EventEntities
                    .ForEach(
                        ev => p.Controls.Add(new EventCard(ev)
                        .With(c => c.OnCardClicked += 
                        (s, e) => new EventDetailsViewModel(form, new MainCommand(_ => InitializeComponent(form)), context.EventRepository, ev.Id)))));
    }

}
