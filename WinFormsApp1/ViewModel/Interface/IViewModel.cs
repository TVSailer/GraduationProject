using CSharpFunctionalExtensions;

namespace Admin.ViewModels
{
    public interface IViewModel<TEntity> 
        where TEntity : Entity
    {
        public void SetData(TEntity value);
        public IViewModel<TEntity> Initialize(object value);
    }
}