using Admin.ViewModel.Managment;
using Admin.ViewModels.Lesson;
using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;

namespace Admin.ViewModel.Model.Visitor;

public class VisitorSerch : SerchManagment<VisitorEntity>
{
    [BaseFieldUi("Имя преподователя")]
    public string VisitorName
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
    public string VisitorSurname
    {
        get;
        set
        {
            if (value == field) return;
            field = value;
            OnPropertyChanged();
        }
    } = "";
    public VisitorSerch(Repository<VisitorEntity> repository) : base(repository)
    {
        OnClearSerchFunk = () =>
        {
            VisitorName = "";
            VisitorSurname = "";
        };

        OnSerhFunk = (entitys) =>
        {
            return entitys
                .Where(e => e.FIO.Name.StartsWith(VisitorName))
                .Where(e => e.FIO.Surname.StartsWith(VisitorSurname))
                .ToList();
        };
    }

    public override Func<List<VisitorEntity>, List<VisitorEntity>> OnSerhFunk { get; protected set; }
    public override Action OnClearSerchFunk { get; protected set; }
}