using CSharpFunctionalExtensions;

public interface IViewModele<T>
    where T : Entity
{
    public T Entity { get; set; }
}

public interface IViewModeleWithImgs<T> : IViewModele<T>
    where T : Entity
{
    public T Entity { get; set; }
}

