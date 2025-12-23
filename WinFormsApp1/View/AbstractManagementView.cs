using Admin.ViewModel;
using Logica;

namespace Admin.View
{
    public abstract class AbstractManagementView : IViewForm
    {
        protected Form form;
        protected AbstractManagmentModelView context;

        public AbstractManagementView(Form form, AbstractManagmentModelView modelView)
        {
            this.form = form;
            context = modelView;
        }

        public Form InitializeComponents()
            => form
                .With(m => m.Controls.Clear())
                .With(m => m.Controls.Add(UIEvent()));

        private TableLayoutPanel UIEvent()
            => FactoryElements.TableLayoutPanel()
            .ControlAddIsRowsAbsoluteV2(FactoryElements.LabelTitle(form.Text), 70)
            .ControlAddIsRowsPercentV2(FactoryElements.TableLayoutPanel()
                .With(t => t.BackColor = Color.WhiteSmoke)
                .ControlAddIsColumnPercentV2(LoadCardsPanel(), 80)
                .ControlAddIsColumnPercentV2(LoadSerchPanel(), 20))
            .ControlAddIsRowsAbsoluteV2(LoadButtonPanel(), 90);

        protected abstract Control LoadSerchPanel();
        protected abstract Control LoadCardsPanel();
        protected virtual TableLayoutPanel LoadButtonPanel()
            => FactoryElements.TableLayoutPanel()
            .ControlAddIsColumnPercentV2(FactoryElements.Button(""), 40)
            .ControlAddIsColumnPercentV2(FactoryElements.Button(""), 40)
            .ControlAddIsColumnPercentV2(FactoryElements.Button("➕ Добавить", context, "OnLoadAddingView"), 40)
            .ControlAddIsColumnPercentV2(FactoryElements.Button("⬅️ Назад", context, "OnBack"), 40);
    }
}
