using CSharpFunctionalExtensions;
using DataAccess.Postgres.Repository;

namespace Admin.Memento;

public class MementoData<T>(Repository<T> repository)
    where T : Entity
{
    private List<T> data = [];
    public bool IsProvide { get; private set; }

    public List<T> Data
    {
        get => IsProvide ? data : repository.Get();
        set
        {
            data = value;
            IsProvide = true;
        }
    }
}