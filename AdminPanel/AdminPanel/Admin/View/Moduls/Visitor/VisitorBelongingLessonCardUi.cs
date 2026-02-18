using Admin.Args;
using Admin.DI;
using Admin.View.AdminMain;
using Admin.View.Moduls.UIModel;
using Admin.View.Moduls.Visitor;
using Admin.View.ViewForm;
using Admin.ViewModel.Model.Lesson.Buttons;
using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;
using Logica.UILayerPanel;

namespace Admin.View;

public class VisitorBelongingLessonCardUi(
    AdminMainUi form,
    VisitorsLessonRepository repository,
    VisitorBelongingLesson viewData,
    VisitorBelongingLessonButton parametersButtons)
    : View<VisitorBelongingLesson>
{
    protected override Control CreateUi()
    {
        return LayoutPanel
            .CreateColumn()
            .Row()
            .ContentEnd(new CardLayoutPanel<VisitorEntity, VisitorCard>()
                .SetContextMenu(parametersButtons)
                .SetObjects(repository.Get()))
            .RowAutoSize().ContentEnd(new ButtonLayoutPanel<ViewButtonClickArgs<VisitorBelongingLesson>>()
                .SetClickedData(this, new ViewButtonClickArgs<VisitorBelongingLesson>(viewData))
                .SetButtons(parametersButtons))
            .Build();
    }
}