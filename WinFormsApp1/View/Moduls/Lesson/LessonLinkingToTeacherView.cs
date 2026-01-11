using Admin.View.ViewForm;
using Admin.ViewModels.Lesson;
using DataAccess.Postgres.Models;
using Logica;

public class LessonLinkingToTeacherView
{
    private readonly List<TeacherEntity> teacherEntities;
    public TeacherEntity Teacher { get; private set; }

    public LessonLinkingToTeacherView(List<TeacherEntity> teacherEntities)
    {
        this.teacherEntities = teacherEntities;
    }

    public LessonLinkingToTeacherView InitializeComponents()
        => this.With(t => new Form()
        .With(f => f.StartPosition = FormStartPosition.CenterScreen)
        .With(f => f.Size = new Size(800, 1000))
        .With(f => f.Controls.Add(FactoryElements.TableLayoutPanel()
            .ControlAddIsRowsPercentV2(FactoryElements.ListBox()
                .With(cb => cb.DataSource = teacherEntities)
                .With(cb => cb.SelectedIndexChanged += (s, e) => Teacher = (TeacherEntity)cb.SelectedItem))
            .ControlAddIsRowsAbsoluteV2(FactoryElements.Button("Ок", () => f.Close()), 60)))
        .With(f => f.ShowDialog()));
}