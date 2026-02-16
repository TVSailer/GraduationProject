using Admin.Args;
using Admin.DI;
using Admin.View.ViewForm;
using Admin.ViewModel.Interface;
using Logica.UILayerPanel;

namespace Admin.View.AdminMain;

public class AdminMainView(AdminMainViewButton buttons, AdminPanelUi model) : Form, IView<AdminPanelUi>
{
    private readonly List<CustomButton<ViewButtonClickArgs<AdminPanelUi>>> buttonInfos = buttons.GetButtons(model);

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
                .Row(60, SizeType.Absolute).ContentEnd(buttonInfos[0].OnClick(this, new ViewButtonClickArgs<AdminPanelUi>(model)))
                .Row(60, SizeType.Absolute).ContentEnd(buttonInfos[1].OnClick(this, new ViewButtonClickArgs<AdminPanelUi>(model)))
                .Row(60, SizeType.Absolute).ContentEnd(buttonInfos[2].OnClick(this, new ViewButtonClickArgs<AdminPanelUi>(model)))
                .Row(60, SizeType.Absolute).ContentEnd(buttonInfos[3].OnClick(this, new ViewButtonClickArgs<AdminPanelUi>(model)))
                .Row(60, SizeType.Absolute).ContentEnd(buttonInfos[4].OnClick(this, new ViewButtonClickArgs<AdminPanelUi>(model)))
                .Row().End()
                .End()
            .Column(25).End()
            .Build();
}