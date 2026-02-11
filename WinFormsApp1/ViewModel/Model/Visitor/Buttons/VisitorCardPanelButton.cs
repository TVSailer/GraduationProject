using Admin.DI;
using Admin.View;
using Admin.ViewModel.Managment;

namespace Admin.ViewModel.Model.Visitor.Buttons;

public class VisitorCardPanelButton(ControlView control) : IParametersButtons<VisitorCardPanelUi>
{
    public List<ButtonInfo> GetButtons(VisitorCardPanelUi instance)
        =>
        [
            new("Назад", _ => control.Exit()),
        ];
}