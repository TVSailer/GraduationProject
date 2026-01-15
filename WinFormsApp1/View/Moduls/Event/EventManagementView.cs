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
        //        .ControlAddIsRowsAbsolute(FactoryElements.TableLayoutPanel()
        //            .ControlAddIsColumnAbsolute(FactoryElements.Label_11("Название: "), 140)
        //            .ControlAddIsColumnPercent(FactoryElements.TextBox("")
        //                .With(tb => tb.TextChanged += (s, e) => Context.Title = tb.Text), 10), 60)
        //        .ControlAddIsRowsAbsolute(FactoryElements.TableLayoutPanel()
        //            .ControlAddIsColumnAbsolute(FactoryElements.Label_11("Категория: "), 140)
        //            .ControlAddIsColumnPercent(FactoryElements.ComboBox()
        //                .With(cb => cb.DataBindings.Add(new Binding("DataSource", Context, "Categorys")))
        //                .With(cb => cb.SelectedIndexChanged += (s, e) => Context.Category = cb.SelectedItem.ToString()),
        //            10), 60)
        //        .ControlAddIsRowsAbsolute(FactoryElements.TableLayoutPanel()
        //            .ControlAddIsColumnAbsolute(FactoryElements.Label_11("От: "), 140)
        //            .ControlAddIsColumnPercent(FactoryElements.DateTimePicker()
        //                .With(dt => dt.TextChanged += (s, e) => Context.StartDate = dt.Text),
        //            10), 60)
        //        .ControlAddIsRowsAbsolute(FactoryElements.TableLayoutPanel()
        //            .ControlAddIsColumnAbsolute(FactoryElements.Label_11("До: "), 140)
        //            .ControlAddIsColumnPercent(FactoryElements.DateTimePicker()
        //                .With(dt => dt.TextChanged += (s, e) => Context.StartDate = dt.Text), 10), 60)
        //        .ControlAddIsRowsPercentV2()
        //        .ControlAddIsRowsAbsolute(FactoryElements.TableLayoutPanel()
        //            .ControlAddIsColumnPercent(FactoryElements.Button("Поиск", Context, nameof(Context.OnSerch)), 50)
        //            .ControlAddIsColumnPercent(FactoryElements.Button("Очистить поиск", Context, nameof(Context.OnClearSerch)), 50), 80)));
    }

}
