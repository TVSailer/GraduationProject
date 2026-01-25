using System.Xml.Linq;
using Admin.ViewModels.Lesson;
using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;
using Microsoft.Office.Interop.Word;

namespace WinFormsApp1.ViewModel.Model.Teacher;

public class TeacherSerch : SerchManagment<TeacherEntity>
{
    [BaseFieldUi("Имя преподователя")]
    public string TeacherName
    {
        get;
        set
        {
            if (value == field) return;
            field = value;
            OnPropertyChanged();
        }
    } = "";

    [BaseFieldUi("Фамилия преподователя")]
    public string TeacherSurname
    {
        get;
        set
        {
            if (value == field) return;
            field = value;
            OnPropertyChanged();
        }
    } = "";
    public TeacherSerch(Repository<TeacherEntity> repository) : base(repository)
    {
        OnClearSerchFunk = () =>
        {
            TeacherName = "";
            TeacherSurname = "";
        };

        OnSerhFunk = (entitys) =>
        {
            return entitys
                .Where(e => e.FIO.Name.StartsWith(TeacherName))
                .Where(e => e.FIO.Surname.StartsWith(TeacherSurname))
                .ToList();
        };
    }

    public override Func<List<TeacherEntity>, List<TeacherEntity>> OnSerhFunk { get; protected set; }
    public override Action OnClearSerchFunk { get; protected set; }
}