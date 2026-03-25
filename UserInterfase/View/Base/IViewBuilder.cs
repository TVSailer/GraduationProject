using System.Windows.Forms;
using UserInterface.LayoutPanel;

namespace UserInterface.View.Base;

public interface IViewBuilder
{
    protected Form InitializeForm(Form form);
    protected IBuilder CreateUi(BuilderLayoutPanel builderLayoutPanel);
}