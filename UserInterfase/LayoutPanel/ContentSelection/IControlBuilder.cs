using System.Windows.Forms;

namespace UserInterface.LayoutPanel.ContentSelection;

public interface IControlBuilder<out TControl, TParentBuilder>
    where TControl : Control
{
    TControl Build();
    TParentBuilder End();
}