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

        //protected override Control LoadSerchPanel()
        //    => new Panel()
        //    .With(t => t.BorderStyle = BorderStyle.FixedSingle)
        //    .With(p => p.Dock = DockStyle.Fill)
        //    .With(p => p.Controls.Add(FactoryElements.TableLayoutPanel()
        //        .ControlAddIsRowsAbsoluteV2(FactoryElements.TableLayoutPanel()
        //            .ControlAddIsColumnAbsoluteV2(FactoryElements.Label_11("Название: "), 140)
        //            .ControlAddIsColumnPercentV2(FactoryElements.TextBox("")
        //                .With(tb => tb.TextChanged += (s, e) => context.Title = tb.Text), 10), 60)
        //        .ControlAddIsRowsAbsoluteV2(FactoryElements.TableLayoutPanel()
        //            .ControlAddIsColumnAbsoluteV2(FactoryElements.Label_11("Категория: "), 140)
        //            .ControlAddIsColumnPercentV2(FactoryElements.ComboBox()
        //                .With(cb => cb.DataBindings.Add(new Binding("DataSource", context, "Categorys")))
        //                .With(cb => cb.SelectedIndexChanged += (s, e) => context.Category = cb.SelectedItem.ToString()),
        //            10), 60)
        //        .ControlAddIsRowsAbsoluteV2(FactoryElements.TableLayoutPanel()
        //            .ControlAddIsColumnAbsoluteV2(FactoryElements.Label_11("От: "), 140)
        //            .ControlAddIsColumnPercentV2(FactoryElements.DateTimePicker()
        //                .With(dt => dt.TextChanged += (s, e) => context.StartDate = dt.Text),
        //            10), 60)
        //        .ControlAddIsRowsAbsoluteV2(FactoryElements.TableLayoutPanel()
        //            .ControlAddIsColumnAbsoluteV2(FactoryElements.Label_11("До: "), 140)
        //            .ControlAddIsColumnPercentV2(FactoryElements.DateTimePicker()
        //                .With(dt => dt.TextChanged += (s, e) => context.StartDate = dt.Text), 10), 60)
        //        .ControlAddIsRowsPercentV2()
        //        .ControlAddIsRowsAbsoluteV2(FactoryElements.TableLayoutPanel()
        //            .ControlAddIsColumnPercentV2(FactoryElements.Button("Поиск", context, nameof(context.OnSerch)), 50)
        //            .ControlAddIsColumnPercentV2(FactoryElements.Button("Очистить поиск", context, nameof(context.OnClearSerch)), 50), 80)));
    }

}
