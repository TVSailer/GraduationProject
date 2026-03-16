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
    private InfoButton[] _buttonInfos;
    private InfoLinkLabel[] _linkLabelInfos;

    public override Form InitializeForm(Form form)
    {
        form.Text = "Панель поситителя";
        form.WindowState = FormWindowState.Maximized;
        form.StartPosition = FormStartPosition.CenterParent;
        form.BackColor = Color.White;

        return form;
    }

    protected override IBuilder CreateUi(BuilderLayoutPanel layout) 
    {
        _buttonInfos = buttons.GetButtons(new ClickedArgs<MainFieldData>(model));
        _linkLabelInfos = buttons.GetLinkLabels(new LinkLabelArgs<MainFieldData>(model));
        return layout.Row()
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
            .Column(25)
                .Row(10)
                    .Column(75)
                    .End()
                    .Column(25)
                        .Content()
                            .LinkLabel(_linkLabelInfos[0]).Alignment(ContentAlignment.TopRight)
                    .End()
                .End()
                .Row(90)
                .End()
            .End();
    }
}