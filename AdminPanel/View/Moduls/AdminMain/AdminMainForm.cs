using Abstract.View;
using AbstractView.View;
using Admin.DI.Module;
using Admin.View.Moduls.Event;
using Domain.Command;
using System.Windows.Input;
using UserInterface.LayoutPanel;
using UserInterface.UiLayoutPanel;

namespace Admin.View.Moduls.AdminMain;

public sealed class AdminMainUi(ControlView controlView, AdminFieldData model) : UiView
{
    private readonly ICommand _loadEventManagerView = new ExecuteCommand(_ => controlView.LoadView<EventManagerView>());
    private readonly ICommand _exit = new ExecuteCommand(_ => controlView.Exit());

    protected override Form InitializeForm(Form form)
    {
        form.Text = "Панель администратора";
        form.WindowState = FormWindowState.Maximized;
        form.StartPosition = FormStartPosition.CenterParent;
        form.BackColor = Color.White;

        return form;
    }

    protected override IBuilder CreateUi(BuilderLayoutPanel layout)
        => layout.Row()
            .Column(25).End()
            .Column(50)
                .Row(70, SizeType.Absolute).ContentEnd(FactoryElements.LabelTitle("Панель администратора"))
                .Row(60, SizeType.Absolute).Content().Button("🎭 Управление кружками").Command(_loadEventManagerView).End()
                //.Row(60, SizeType.Absolute).Content().Button(_buttonInfos[1]).End()
                //.Row(60, SizeType.Absolute).Content().Button(_buttonInfos[2]).End()
                //.Row(60, SizeType.Absolute).Content().Button(_buttonInfos[3]).End()
                //.Row(60, SizeType.Absolute).Content().Button(_buttonInfos[4]).End()
                .Row(60, SizeType.Absolute).Content().Button("🚪 Выход").Command(_exit).End()
                .Row().End()
            .End()
            .Column(25).End();
}