using UserInterface;
using UserInterface.LayoutPanel;
using UserInterface.UiLayoutPanel.ButtonPanel;
using UserInterface.View;
using Visitor.DI.Module;
using Visitor.FieldData.Main.Button;

namespace Visitor.View.Main;

public class MainUi(MainViewButton buttons, MainFieldData model) : UiView<MainFieldData>
{
    private readonly List<CustomButton> _buttonInfos = buttons.GetButtons(model);
    public override Form InitializeForm(Form form)
    {
        form.Text = "Панель поситителя";
        form.WindowState = FormWindowState.Maximized;
        form.StartPosition = FormStartPosition.CenterParent;
        form.BackColor = Color.White;

        return form;
    }

    protected override IBuilder CreateUi(BuilderLayoutPanel layout)
        => layout.Row()
            .Column(25).End()
            .Column(50)
                .Row(70, SizeType.Absolute).ContentEnd(FactoryElements.LabelTitle("Панель поситителя"))
                .Row(60, SizeType.Absolute).ContentEnd(_buttonInfos[0])
                .Row(60, SizeType.Absolute).ContentEnd(_buttonInfos[1])
                .Row(60, SizeType.Absolute).ContentEnd(_buttonInfos[2])
                .Row(60, SizeType.Absolute).ContentEnd(_buttonInfos[3])
                .Row(60, SizeType.Absolute).End()
                .Row(60, SizeType.Absolute).ContentEnd(_buttonInfos[4])
            .Row().End()
            .End()
            .Column(25).End();
}