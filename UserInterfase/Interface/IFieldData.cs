namespace UserInterface.Interface;


public interface IDataUi<TEntity>
    where TEntity : new()
{
    TEntity Entity { get; set; }
    public long EntityId { get; protected set; }
}
