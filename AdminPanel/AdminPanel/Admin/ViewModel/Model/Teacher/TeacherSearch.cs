using Admin.ViewModel.Managment;
using DataAccess.Postgres.Models;

namespace Admin.ViewModel.Model.Teacher;

public class TeacherSearch : IParametersSearch<TeacherEntity, TeacherFieldSearch>
{
    public Func<TeacherFieldSearch, List<TeacherEntity>, List<TeacherEntity>> SearchFunc =>
        (obj, entitys) =>
            entitys
                .Where(e => e.FIO.Name.StartsWith(obj.TeacherName ?? ""))
                .Where(e => e.FIO.Surname.StartsWith(obj.TeacherSurname ?? ""))
                .ToList();
}