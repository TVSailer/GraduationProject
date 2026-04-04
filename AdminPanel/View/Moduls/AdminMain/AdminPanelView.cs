using Admin.ViewModel.Model.AdminMain;
using UserInterface.LayoutPanel;
using UserInterface.LayoutPanel.Extension;
using UserInterface.View;

namespace Admin.View.Moduls.AdminMain;

public sealed class AdminPanelView(AdminPanelViewModel viewModel) : UiView<AdminPanelViewModel>
{
    public override Form InitializeForm(Form form)
    {
        form.Text = "Панель администратора";
        return base.InitializeForm(form);
    }

    public override IBuilder CreateUi(BuilderLayoutPanel layout)
        => layout.Row()
            .Column(25).End()
            .Column(50)
                .RowAbsolute(70).Content()
                    .Label("Панель администратора")
                    .Size(18)
                    .Alignment(ContentAlignment.TopCenter)
                    .ForeColor(Color.DarkBlue)
                .End()
                .RowAbsolute(60).Content()
                    .Button("🎭 Управление мероприятиями")
                    .Command(viewModel.LoadEventManagerPanelView)
                .End()
                .RowAbsolute(60).Content()
                    .Button("📰 Управление новостями")
                .End()
                .RowAbsolute(60).Content()
                    .Button("🎨 Управление кружками")
                    .Command(viewModel.LoadLessonManagerPanelView)
                .End()
                .RowAbsolute(60).Content()
                    .Button("👨‍🏫 Управление преподавателями")
                    .Command(viewModel.LoadTeacherManagerPanelView)
                .End()
                .RowAbsolute(60).Content()
                    .Button("👥 Управление посетителями")
                    .Command(viewModel.LoadVisitorManagerPanelView)
                .End()
                .RowAbsolute(60).Content()
                    .Button("🚪 Выход")
                    .Command(viewModel.Exit)
                .End()
                .Row().End()
            .End()
            .Column(25).End();
}