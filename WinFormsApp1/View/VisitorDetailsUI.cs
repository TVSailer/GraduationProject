using Admin.DI;
using Admin.View.AdminMain;
using Admin.View.Moduls.UIModel;
using Admin.View.ViewForm;
using DataAccess.Postgres.Models;
using Logica.UILayerPanel;

namespace Admin.View;

public class VisitorDetailsUi(
    AdminMainView form, 
    CardModule<LessonEntity> cardLesson,
    VisitorDetailsPanelUi viewData,
    IParametersButtons<VisitorDetailsPanelUi> parametersButtons)
    : IView<VisitorDetailsPanelUi, VisitorEntity>
{
    public Form InitializeComponents(object? data)
    {
        return form
            .With(m => m.Controls.Clear())
            .With(m => m.Controls.Add(CreateUI()));
    }

    public Control CreateUI()
    {
        return LayoutPanel
            .CreateColumn()
            .RowAutoSize().ContentEnd(new FieldEntityModule(ViewField).CreateControl())
            .RowAutoSize().ContentEnd(FactoryElements.Label_12("Посещает:"))
            .Row().ContentEnd(cardLesson.UpdateCard(ViewField.Entity.GetData().Lessons!).CreateControl())
            .RowAutoSize().ContentEnd(new ButtonModuleV2(parametersButtons.GetButtons(ViewField)).CreateControl())
            .Build();
    }

    public VisitorDetailsPanelUi ViewField { get; set; } = viewData;
}