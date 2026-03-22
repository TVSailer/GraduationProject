namespace UserInterface.Interface;


public interface IDataUi<TEntity>
{
    TEntity Entity { get; set; }
    public long EntityId { get; protected set; }
}
