using Admin.Args;
using Admin.DI;
using Admin.View.AdminMain;
using Admin.View.Moduls.UIModel;
using Admin.View.ViewForm;
using Admin.ViewModel.Model.Visitor.Buttons;
using DataAccess.Postgres.Models;
using Logica.UILayerPanel;

namespace Admin.View;

public class VisitorDetailsUi(
    AdminMainView form, 
    VisitorDetailsFieldData viewData,
    VisitorDetailsButton parametersButtons)
    : View<VisitorDetailsFieldData, VisitorEntity>(form, viewData)
{
    protected override Control CreateUi()
    {
        return LayoutPanel
            .CreateColumn()
                .RowAutoSize().ContentEnd(new FieldLayoutPanel(ViewField).CreateControl())
                .RowAutoSize().ContentEnd(FactoryElements.Label_12(" Посещает:"))
                .Row().ContentEnd(new CardLayoutPanel<LessonEntity, LessonCard>()
                    .SetObjects(ViewField.Entity.GetData().Lessons!))
                .RowAutoSize().ContentEnd(new ButtonLayoutPanel<ViewButtonClickArgs<VisitorEntity, VisitorDetailsFieldData>>()
                    .SetClickedData(this, new ViewButtonClickArgs<VisitorEntity, VisitorDetailsFieldData>(viewData))
                    .SetButtons(parametersButtons))
            .Build();
    }
}