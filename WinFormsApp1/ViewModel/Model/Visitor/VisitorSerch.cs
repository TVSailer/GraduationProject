using Admin.ViewModel.Managment;
using CSharpFunctionalExtensions;
using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;

namespace Admin.ViewModel.Model.Visitor;

public class VisitorSearch : SearchEntity<VisitorEntity, VisitorFieldSearch>
{
    public VisitorSearch(Repository<VisitorEntity> repository) : base(repository.Get, new VisitorFieldSearch(),  (obj, entitys) =>
        entitys
            .Where(e => e.FIO.Name.StartsWith(obj.VisitorName))
            .Where(e => e.FIO.Surname.StartsWith(obj.VisitorSurname))
            .ToList())
    {
    }
}