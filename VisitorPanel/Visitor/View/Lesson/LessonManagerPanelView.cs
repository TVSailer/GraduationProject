using UserInterface.LayoutPanel;
using UserInterface.View;
using Visitor.ViewModel.Lesson;

namespace Visitor.View.Lesson;

public class LessonManagerPanelView(LessonManagerPanelViewModel viewModel) : UiView<LessonManagerPanelViewModel>
{
    public override IBuilder CreateUi(BuilderLayoutPanel builderLayoutPanel)
    {
        throw new NotImplementedException();
    }
}