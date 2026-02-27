using Admin.DI;
using User_Interface_Library;
using User_Interface_Library.LayerPanel;
using User_Interface_Library.UiLayoutPanel.ButtonPanel;
using User_Interface_Library.View;

namespace Admin.View.Moduls.AdminMain;

public sealed class AdminMainUi : UiView<AdminFieldData>
{
    private readonly List<CustomButton> buttonInfos;


    public AdminMainUi(AdminMainViewButton buttons, AdminFieldData model)
    {
        buttonInfos = buttons.GetButtons(model);
    }

    public override Form InitializeForm(Form form)
    {
        form.Text = "Панель администратора";
        form.WindowState = FormWindowState.Maximized;
        form.StartPosition = FormStartPosition.CenterParent;
        form.BackColor = Color.White;

        return form;
    }

    protected override Control? CreateUi()
        => LayoutPanel.CreateRow()
            .Column(25).End()
            .Column(50)
            .Row(70, SizeType.Absolute).ContentEnd(FactoryElements.LabelTitle("Панель администратора"))
            .Row(60, SizeType.Absolute).ContentEnd(buttonInfos[0])
            .Row(60, SizeType.Absolute).ContentEnd(buttonInfos[1])
            .Row(60, SizeType.Absolute).ContentEnd(buttonInfos[2])
            .Row(60, SizeType.Absolute).ContentEnd(buttonInfos[3])
            .Row(60, SizeType.Absolute).ContentEnd(buttonInfos[4])
            .Row().End()
            .End()
            .Column(25).End()
            .Build();
}