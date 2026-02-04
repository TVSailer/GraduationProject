using MediatR;

public record SaveCommandRequest<T, TEntity>() : IRequest;
