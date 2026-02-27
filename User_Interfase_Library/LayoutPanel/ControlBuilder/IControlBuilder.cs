using System.Windows.Forms;

namespace User_Interface_Library.TableLayerPanel.ControlBuilder;

public interface IControlBuilder<out TControl, TParentBuilder>
    where TControl : Control
{
    TControl Build();
    TParentBuilder End();
}