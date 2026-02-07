using CSharpFunctionalExtensions;

namespace Admin.ViewModel.Managment;

public interface IInitializeSerch<TEntity>
    where TEntity : Entity, new()
{
    public void SetData(Func<List<TEntity>?> data);
}