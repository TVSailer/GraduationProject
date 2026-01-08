using Admin.View.ImagePanel;
using Logica;
using System.Windows.Forms;
using WinFormsApp1.View;

namespace Admin.View.ViewForm
{
    public class ViewFormWithImgs : ViewForm
    {
        private readonly IImagePanel imagePan;

        public ViewFormWithImgs(AdminMainView mainView, IButtonPanel buttonPanel, IFieldsPanel fieldsPanel, IImagePanel imagePanel) : base(mainView, buttonPanel, fieldsPanel)
        {
            imagePan = imagePanel;
        }

        protected override Control? CreateUI()
            => FactoryElements
            .TableLayoutPanel()
                .ControlAddIsRowsAbsoluteV2(FactoryElements.LabelTitle(form.Text), 70)
                .ControlAddIsRowsAbsoluteV2(fieldsPan.CreateFieldsPanel(), 500)
                .ControlAddIsRowsPercentV2(imagePan.CreateImagePanel(), 20)
                .With(t => buttonPan.CreateButtonPanel()
                    .With(bp =>  t.ControlAddIsRowsAbsoluteV2(bp, bp.PreferredSize.Height)));
    }
}

