using Logica;
using WinFormsApp1.View;

namespace Admin.View.ViewForm
{
    public class ViewForm : IViewForm
    {
        protected readonly Form form;
        protected readonly IButtonPanel buttonPan;
        protected readonly IFieldsPanel fieldsPan;

        public ViewForm(AdminMainView mainView, IButtonPanel buttonPanel, IFieldsPanel fieldsPanel)
        {
            form = mainView;
            buttonPan = buttonPanel;
            fieldsPan = fieldsPanel;
        }

        public Form InitializeComponents()
            => form
            .With(m => m.Controls.Clear())
            .With(m => m.Controls.Add(CreateUI()));

        protected virtual Control? CreateUI()
           => FactoryElements
            .TableLayoutPanel()
            .ControlAddIsRowsAbsoluteV2(FactoryElements.LabelTitle(form.Text), 70)
            .ControlAddIsRowsPercentV2(fieldsPan.CreateFieldsPanel(), 100)
            .ControlAddIsRowsAbsoluteV2(buttonPan.CreateButtonPanel(), 90);
    }
}
