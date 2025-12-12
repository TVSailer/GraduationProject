using Logica;
using Logica.DI;

namespace WinFormsApp1.View.Event
{
    public partial class EventManagementView
    {
        private EventMenegmentModelView context;
        private readonly AdminMainView form;

        public EventManagementView(AdminMainView mainForm, EventMenegmentModelView context)
        {
            this.context = context;
            form = mainForm;
        }

        public Form InitializeComponent()
            => form
                .With(m => m.Controls.Clear())
                .With(m => m.Text = "Управление мероприятиями")
                .With(m => m.Controls.Add(UIEvent(form)));

        private TableLayoutPanel UIEvent(Form form)
            => FactoryElements.TableLayoutPanel()
                .ControlAddIsRowsAbsoluteV2(FactoryElements.LabelTitle("🎭 Управление мероприятиями"), 70)
                .ControlAddIsRowsPercentV2(FactoryElements.TableLayoutPanel()
                    .With(t => t.BackColor = Color.WhiteSmoke)
                    .ControlAddIsColumnPercentV2(LoadEventCards(form), 80)
                    .ControlAddIsColumnPercentV2(new Panel()
                        .With(t => t.BorderStyle = BorderStyle.FixedSingle)
                        .With(p => p.Dock = DockStyle.Fill)
                        .With(p => p.Controls.Add(FactoryElements.TableLayoutPanel()
                            .ControlAddIsRowsAbsoluteV2(FactoryElements.TableLayoutPanel()
                                .ControlAddIsColumnAbsoluteV2(FactoryElements.Label_11("Название: "), 140)
                                .ControlAddIsColumnPercentV2(FactoryElements.TextBox("")
                                    .With(tb => tb.TextChanged += (s, e) => context.Title = tb.Text), 10), 60)
                            .ControlAddIsRowsAbsoluteV2(FactoryElements.TableLayoutPanel()
                                .ControlAddIsColumnAbsoluteV2(FactoryElements.Label_11("Категория: "), 140)
                                .ControlAddIsColumnPercentV2(FactoryElements.ComboBox()
                                    .With(cb => cb.DataBindings.Add(new Binding("DataSource", context, "Categorys")))
                                    .With(cb => cb.SelectedIndexChanged += (s, e) => context.Category = cb.SelectedItem.ToString()), 
                                10), 60)
                            .ControlAddIsRowsAbsoluteV2(FactoryElements.TableLayoutPanel()
                                .ControlAddIsColumnAbsoluteV2(FactoryElements.Label_11("От: "), 140)
                                .ControlAddIsColumnPercentV2(FactoryElements.DateTimePicker()
                                    .With(dt => dt.TextChanged += (s, e) => context.StartDate = dt.Text),
                                10), 60)
                            .ControlAddIsRowsAbsoluteV2(FactoryElements.TableLayoutPanel()
                                .ControlAddIsColumnAbsoluteV2(FactoryElements.Label_11("До: "), 140)
                                .ControlAddIsColumnPercentV2(FactoryElements.DateTimePicker()
                                    .With(dt => dt.TextChanged += (s, e) => context.StartDate = dt.Text),
                                10), 60)
                            .ControlAddIsRowsPercentV2()
                            .ControlAddIsRowsAbsoluteV2(FactoryElements.TableLayoutPanel()
                                .ControlAddIsColumnPercentV2(FactoryElements.Button("Поиск", context, "OnSerch"), 50)
                                .ControlAddIsColumnPercentV2(FactoryElements.Button("Очистить поиск", context, "OnClearSerch"), 50)
                            , 80))), 20))
                .ControlAddIsRowsAbsoluteV2(FactoryElements.TableLayoutPanel()
                    .ControlAddIsColumnPercentV2(FactoryElements.Button(""), 40)
                    .ControlAddIsColumnPercentV2(FactoryElements.Button("➕ Добавить", context, "OnLoadAddView"), 40)
                    .ControlAddIsColumnPercentV2(FactoryElements.Button("🔄 Обновить"), 40)
                    .ControlAddIsColumnPercentV2(FactoryElements.Button("⬅️ Назад", context, "OnBack"), 40), 90);


        private FlowLayoutPanel LoadEventCards(Form form)
            => new FlowLayoutPanel()
                .With(p => p.Dock = DockStyle.Fill)
                .With(p => p.AutoScroll = true)
                .With(p => p.Padding = new Padding(10))
                .With(p => context.PropertyChanged += (obj, propCh) =>
                {
                    if (!(propCh.PropertyName == "EventEntities"))
                        return;
                    p.Controls.Clear();
                    context.EventEntities
                    .ForEach(
                        ev => p.Controls.Add(new EventCard(ev)
                        .With(c => c.OnCardClicked +=
                        (s, e) =>
                        {
                            using (var scope = new ContainerScoped(AdminConteiner.Container))
                                scope.GetService<EventDetailsView>(ev.Id).InitializeComponents();
                        })));
                })
                .With(p => context.EventEntities
                    .ForEach(
                        ev => p.Controls.Add(new EventCard(ev)
                        .With(c => c.OnCardClicked += 
                        (s, e) =>
                        {
                            using (var scope = new ContainerScoped(AdminConteiner.Container))
                                scope.GetService<EventDetailsView>(ev.Id).InitializeComponents();
                        }))));
    }

}
