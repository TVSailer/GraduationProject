using Admin.DI.Module;
using Admin.FieldData.Model.AdminMain;
using UserInterface;
using UserInterface.Info;
using UserInterface.LayoutPanel;
using UserInterface.UiLayoutPanel.CardPanel.Args;
using UserInterface.View;

namespace Admin.View.Moduls.AdminMain;

public sealed class AdminMainUi(AdminMainViewButton buttons, AdminFieldData model) : UiView<AdminFieldData>
{
    private readonly InfoButton[] _buttonInfos = buttons.GetButtons(new ClickedArgs<AdminFieldData>(model));
    public override Form InitializeForm(Form form)
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
                .Row(60, SizeType.Absolute).Content().Button(_buttonInfos[0]).End()
                .Row(60, SizeType.Absolute).Content().Button(_buttonInfos[1]).End()
                .Row(60, SizeType.Absolute).Content().Button(_buttonInfos[2]).End()
                .Row(60, SizeType.Absolute).Content().Button(_buttonInfos[3]).End()
                .Row(60, SizeType.Absolute).Content().Button(_buttonInfos[4]).End()
                .Row(60, SizeType.Absolute).Content().Button(_buttonInfos[5]).End()
                .Row().End()
            .End()
            .Column(25).End();
}