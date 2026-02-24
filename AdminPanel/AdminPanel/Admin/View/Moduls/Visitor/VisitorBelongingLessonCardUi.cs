using Admin.Args;
using Admin.DI;
using Admin.View.Moduls.UIModel;
using Admin.View.Moduls.Visitor;
using Admin.View.ViewForm;
using Admin.ViewModel.Model.Lesson.Buttons;
using Admin.ViewModel.Model.Visitor.Buttons;
using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;
using Logica.UILayerPanel;

namespace Admin.View;

public class VisitorBelongingLessonCardUi(
    MementoLesson repository,
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
                .SetObjects(repository.GetVisitorsBelongingLesson()))
            .RowAutoSize().ContentEnd(new ButtonLayoutPanel<ViewButtonClickArgs<VisitorBelongingLesson>>()
                .SetClickedData(this, new ViewButtonClickArgs<VisitorBelongingLesson>(viewData))
                .SetButtons(parametersButtons))
            .Build();
    }
}