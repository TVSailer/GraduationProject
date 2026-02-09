using Admin.View.ViewForm;
using Admin.ViewModel.Managment;
using Logica;
using Logica.UILayerPanel;

namespace Admin.View.AdminMain;

public class AdminMainView : Form, IView<AdminPanelUI>
{
    private readonly List<ButtonInfo> buttonInfos;

    public AdminMainView(IParametersButtons<AdminPanelUI> buttons, AdminPanelUI model)
    {
        buttonInfos = buttons.GetButtons(model, this);
    }

    public Form InitializeComponents(object? data)
        => this
            .With(m => m.Controls.Clear())
            .With(m => m.Text = "Панель администратора")
            .With(m => m.WindowState = FormWindowState.Maximized)
            .With(m => m.StartPosition = FormStartPosition.CenterParent)
            .With(m => m.BackColor = Color.White)
            .With(m => m.Controls.Add(MainMenu()));

    private Control MainMenu()
        => LayoutPanel.CreateRow()
            .Column(25).End()
            .Column(50)
                .Row(70, SizeType.Absolute).ContentEnd(FactoryElements.LabelTitle("Панель администратора"))
                .Row(60, SizeType.Absolute).ContentEnd(Button(buttonInfos[0]))
                .Row(60, SizeType.Absolute).ContentEnd(Button(buttonInfos[1]))
                .Row(60, SizeType.Absolute).ContentEnd(Button(buttonInfos[2]))
                .Row(60, SizeType.Absolute).ContentEnd(Button(buttonInfos[3]))
                .Row(60, SizeType.Absolute).ContentEnd(Button(buttonInfos[4]))
                .Row().End()
                .End()
            .Column(25).End()
            .Build();

    public Button Button(ButtonInfo buttonInfo) => FactoryElements.Button(buttonInfo.LabelText, buttonInfo.Command);

    public AdminPanelUI? ViewData { get; set; }
}