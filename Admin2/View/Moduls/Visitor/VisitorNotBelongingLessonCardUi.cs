using Admin.Args;
using Admin.DI;
using Admin.View.AdminMain;
using Admin.View.Moduls.UIModel;
using Admin.View.Moduls.Visitor;
using Admin.View.ViewForm;
using Admin.ViewModel.Model.Visitor.Buttons;
using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;
using Logica.UILayerPanel;

namespace Admin.View;

public class VisitorNotBelongingLessonCardUi(
    AdminMainView form,
    VisitorsLessonRepository repository,
    VisitorNotBelongingLessonCardPanelUi viewData,
    VisitorNotBelongingLessonButton parametersButtons)
    : View<VisitorNotBelongingLessonCardPanelUi>(form)
{
    protected override Control CreateUi()
    {
        return LayoutPanel
            .CreateColumn()
                .Row().ContentEnd(new CardLayoutPanel<VisitorEntity, VisitorCard>()
                    .SetClickedCard(parametersButtons)
                    .SetObjects(repository.GetVisitorsNotBelongingLesson()))
                .RowAutoSize().ContentEnd(new ButtonLayoutPanel<ViewButtonClickArgs<VisitorNotBelongingLessonCardPanelUi>>()
                    .SetClickedData(this, new ViewButtonClickArgs<VisitorNotBelongingLessonCardPanelUi>(viewData))
                    .SetButtons(parametersButtons))
                    
            .Build();
    }
}