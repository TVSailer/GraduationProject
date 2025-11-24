using AdminApp.Controls;
using Logica;
using Logica.Extension;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace AdminApp.Forms
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
                .With(m => m.Controls.Add(UIEvent()));

        private TableLayoutPanel UIEvent()
            => FactoryElements.TableLayoutPanel()
                .ControlAddIsRowsAbsoluteV2(FactoryElements.LabelTitle("🎭 Управление мероприятиями"), 70)
                .ControlAddIsRowsPercentV2(LoadEventCards(), 70)
                .ControlAddIsRowsAbsoluteV2(
                    FactoryElements.TableLayoutPanel()
                        .ControlAddIsColumnPercentV2(FactoryElements.Button(""), 40)
                        .ControlAddIsColumnPercentV2(FactoryElements.Button("➕ Добавить", context, "OnLoadAddView"), 40)
                        .ControlAddIsColumnPercentV2(FactoryElements.Button("🔄 Обновить"), 40)
                        .ControlAddIsColumnPercentV2(FactoryElements.Button("⬅️ Назад", context, "OnBack"), 40), 90);


        private Control LoadEventCards()
        {
            var cardsPanel = new FlowLayoutPanel()
                        .With(p => p.Dock = DockStyle.Fill)
                        .With(p => p.AutoScroll = true)
                        .With(p => p.BackColor = Color.WhiteSmoke)
                        .With(p => p.Padding = new Padding(10));

            context.EventEntities
                .ForEach(ev =>
                cardsPanel.Controls.Add(
                    new EventCard(ev)));
                            //.With(c => c.OnCardClicked += (s, e) => new EventDetailsView(this, ))));


            return cardsPanel;
        }
    }

}
