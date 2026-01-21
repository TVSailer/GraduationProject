using Admin.View.ViewForm;
using Admin.ViewModels.Lesson;
using DataAccess.Postgres.Models;
using Logica;

public class LessonLinkingToTeacherView : Form
{
    private readonly List<TeacherEntity> teacherEntities;
    private readonly Action<TeacherEntity> action;

    public LessonLinkingToTeacherView(List<TeacherEntity> teacherEntities, Action<TeacherEntity> action)
    {
        this.teacherEntities = teacherEntities;
        this.action = action;

        InitializeComponents();
    }

    private LessonLinkingToTeacherView InitializeComponents()
        => this.With(t => this
        .With(f => f.StartPosition = FormStartPosition.CenterScreen)
        .With(f => f.Size = new Size(800, 1000))
        .With(f => f.Controls.Add(FactoryElements.TableLayoutPanel()
            .ControlAddIsRowsPercent(FactoryElements.ListBox()
                .With(cb => cb.DataSource = teacherEntities)
                .With(cb => cb.SelectedIndexChanged += (s, e) => action.Invoke((TeacherEntity)cb.SelectedItem)))
            .ControlAddIsRowsAbsolute(FactoryElements.Button("Ок", () => f.Close()), 60))));
}