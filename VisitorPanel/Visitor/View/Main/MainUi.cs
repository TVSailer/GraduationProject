using UserInterface;
using UserInterface.Info;
using UserInterface.LayoutPanel;
using UserInterface.UiLayoutPanel.CardPanel.Args;
using UserInterface.View;
using Visitor.DI.Module;
using Visitor.FieldData.Main.Button;

namespace Visitor.View.Main;

public class MainUi(MainViewButton buttons, MainFieldData model) : UiView<MainFieldData>
{
    private readonly InfoButton[] _buttonInfos = buttons.GetButtons(new ClickedArgs<MainFieldData>(model));
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
                .Row(60, SizeType.Absolute).Content().Button().InfoButton(_buttonInfos[0]).End()
                .Row(60, SizeType.Absolute).Content().Button().InfoButton(_buttonInfos[1]).End()
                .Row(60, SizeType.Absolute).Content().Button().InfoButton(_buttonInfos[2]).End()
                .Row(60, SizeType.Absolute).Content().Button().InfoButton(_buttonInfos[3]).End()
                .Row(60, SizeType.Absolute).Content().Button().InfoButton(_buttonInfos[4]).End()
            .Row().End()
            .End()
            .Column(25).End();
}