using System.Windows.Forms;

namespace UserInterface.LayoutPanel.ControlBuilder;

public interface IControlBuilder<out TControl, TParentBuilder>
    where TControl : Control
{
    TControl Build();
    TParentBuilder End();
}