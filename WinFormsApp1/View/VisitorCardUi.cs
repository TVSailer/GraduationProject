using Admin.DI;
using Admin.View.AdminMain;
using Admin.View.Moduls.UIModel;
using Admin.View.ViewForm;
using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;
using Logica.UILayerPanel;

namespace Admin.View;

public class VisitorCardUi(
    AdminMainView form,
    CardModule<VisitorEntity> cardLesson,
    VisitorsRepository repository,
    VisitorCardPanelUi viewData,
    ControlView control,
    IParametersButtons<VisitorCardPanelUi> parametersButtons)
    : IView<VisitorCardPanelUi, VisitorEntity>
{
    public Form InitializeComponents(object? data)
    {
        return form
            .With(m => m.Controls.Clear())
            .With(m => m.Controls.Add(CreateUI()));
    }

    public Control CreateUI()
    {
        cardLesson.OnClick = entity =>
        {
            repository.Add(entity);
            control.Exit();
        };

        return LayoutPanel
            .CreateColumn()
            .Row().ContentEnd(cardLesson.UpdateCard(repository.GetVisitors()).CreateControl())
            .RowAutoSize().ContentEnd(new ButtonModuleV2(parametersButtons.GetButtons(ViewField)).CreateControl())
            .Build();
    }

    public VisitorCardPanelUi ViewField { get; set; } = viewData;
}