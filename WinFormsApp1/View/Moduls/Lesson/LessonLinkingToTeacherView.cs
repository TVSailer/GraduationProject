using Admin.View.ViewForm;
using Admin.ViewModel.Lesson;
using DataAccess.Postgres.Models;
using Logica;

public class LessonLinkingToTeacherView : IViewForm
{
    private readonly LessonDataViewModel context;

    public LessonLinkingToTeacherView(LessonDataViewModel viewModel)
    {
        context = viewModel;
    }

    public Form InitializeComponents()
        => new Form()
        .With(f => f.Size = new Size(800, 1000))
        .With(f => f.Controls.Add(FactoryElements.TableLayoutPanel()
            .ControlAddIsRowsPercentV2(FactoryElements.ListBox()
                .With(cb => cb.DataSource = context.teachers)
                .With(cb => cb.SelectedIndexChanged += (s, e) => context.Teacher = (TeacherEntity)cb.SelectedItem))
            .ControlAddIsRowsAbsoluteV2(FactoryElements.Button("Ок", () => f.Close()), 60)))
        .With(f => f.ShowDialog());
}