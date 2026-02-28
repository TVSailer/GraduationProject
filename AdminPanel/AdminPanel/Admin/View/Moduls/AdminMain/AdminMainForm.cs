using Admin.DI;
using UserInterface;
using UserInterface.LayoutPanel;
using UserInterface.UiLayoutPanel.ButtonPanel;
using UserInterface.View;

namespace Admin.View.Moduls.AdminMain;

public sealed class AdminMainUi(AdminMainViewButton buttons, AdminFieldData model) : UiView<AdminFieldData>(model)
{
    private readonly List<CustomButton> _buttonInfos = buttons.GetButtons(model);

    public override Form InitializeForm(Form form)
    {
        form.Text = "Панель администратора";
        form.WindowState = FormWindowState.Maximized;
        form.StartPosition = FormStartPosition.CenterParent;
        form.BackColor = Color.White;

        return form;
    }

    protected override IBuilder CreateUi(BuilderLayoutPanel layout)
        => layout.CreateRow()
            .Column(25).End()
            .Column(50)
                .Row(70, SizeType.Absolute).ContentEnd(FactoryElements.LabelTitle("Панель администратора"))
                .Row(60, SizeType.Absolute).ContentEnd(_buttonInfos[0])
                .Row(60, SizeType.Absolute).ContentEnd(_buttonInfos[1])
                .Row(60, SizeType.Absolute).ContentEnd(_buttonInfos[2])
                .Row(60, SizeType.Absolute).ContentEnd(_buttonInfos[3])
                .Row(60, SizeType.Absolute).ContentEnd(_buttonInfos[4])
                .Row().End()
            .End()
            .Column(25).End();
}