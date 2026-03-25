using Admin.ViewModel.Model.AdminMain;
using UserInterface.LayoutPanel;
using UserInterface.UiObjects.Factory;
using UserInterface.View;

namespace Admin.View.Moduls.AdminMain;

public sealed class AdminPanelView(AdminPanelViewModel viewModel) : UiView<AdminPanelViewModel>
{
    public override Form InitializeForm(Form form)
    {
        form.Text = "Панель администратора";
        form.WindowState = FormWindowState.Maximized;
        form.StartPosition = FormStartPosition.CenterParent;
        form.BackColor = Color.White;

        return form;
    }

    public override IBuilder CreateUi(BuilderLayoutPanel layout)
        => layout.Row()
            .Column(25).End()
            .Column(50)
                .Row(70, SizeType.Absolute).ContentEnd(FactoryElements.LabelTitle("Панель администратора"))
                .Row(60, SizeType.Absolute).Content().Button("🎭 Управление кружками").Command(viewModel.LoadEventManagerPanelView).End()
                //.Row(60, SizeType.Absolute).Content().Button(_buttonInfos[1]).End()
                //.Row(60, SizeType.Absolute).Content().Button(_buttonInfos[2]).End()
                //.Row(60, SizeType.Absolute).Content().Button(_buttonInfos[3]).End()
                //.Row(60, SizeType.Absolute).Content().Button(_buttonInfos[4]).End()
                .Row(60, SizeType.Absolute).Content().Button("🚪 Выход").Command(viewModel.Exit).End()
                .Row().End()
            .End()
            .Column(25).End();
}