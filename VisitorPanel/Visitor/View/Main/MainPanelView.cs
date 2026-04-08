using UserInterface.LayoutPanel;
using UserInterface.LayoutPanel.Extension;
using UserInterface.View;
using Visitor.ViewModel.Main;

namespace Visitor.View.Main;
public class MainPanelView(MainPanelViewModel viewModel) : UiView<MainPanelViewModel>
{
    public override Form InitializeForm(Form form)
    {
        form.Text = "Панель поситителя";

        return form;
    }

    public override IBuilder CreateUi(BuilderLayoutPanel layout) 
    {
        return layout.Row()
            .Column(25)
            .End()
            .Column(50)
                .RowAbsolute(70).Content()
                    .Label("Панель поситителя")
                    .Alignment(ContentAlignment.TopCenter)
                    .Size(18)
                    .ForeColor(Color.DarkBlue)
                .End()
                .RowAbsolute(60).Content()
                    .Button("📰 Новости")
                    .Command(viewModel.OpenNews)
                .End()
                .RowAbsolute(60).Content()
                    .Button("🎭 Мероприятия")
                    .Command(viewModel.OpenEvent)
                .End()
                .RowAbsolute(60).Content()
                    .Button("🎨 Кружки")
                    .Command(viewModel.OpenLesson)
                .End()
                .RowAbsolute(60).Content()
                    .Button("👨‍🏫 Профиль")
                    .Command(viewModel.OpenEnter)
                .End()
                .RowAbsolute(60).Content()
                    .Button("🚪 Выход")
                    .Command(viewModel.Exit)
                .End()
                .Row()
                .End()
            .End()
            .Column(25)
            .End();
    }
}