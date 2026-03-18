using UserInterface.LayoutPanel;
using UserInterface.View;

namespace Visitor.View.Review;

public class ReviewPanelUi : Forma
{
    public ReviewPanelUi()
    {
        Size = new Size(width: 500, height: 250);
    }

    public override IBuilder ControlUi(BuilderLayoutPanel builderLayoutPanel)
    => builderLayoutPanel.Column()
}