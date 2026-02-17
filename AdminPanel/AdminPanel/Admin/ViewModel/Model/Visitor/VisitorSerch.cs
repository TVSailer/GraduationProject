using Admin.ViewModel.Managment;
using CSharpFunctionalExtensions;
using DataAccess.Postgres.Models;

namespace Admin.ViewModel.Model.Visitor;

public class VisitorSearch : IParametersSearch<VisitorEntity, VisitorFieldSearch>
{
    public Func<VisitorFieldSearch, List<VisitorEntity>, List<VisitorEntity>> SearchFunc => 
        (obj, entitys) =>
            entitys
                .Where(e => e.FIO.Name.StartsWith(obj.VisitorName))
                .Where(e => e.FIO.Surname.StartsWith(obj.VisitorSurname))
                .ToList();
}
