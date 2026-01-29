using Admin.ViewModel.Interface;
using Admin.ViewModel.Lesson;
using CSharpFunctionalExtensions;
using DataAccess.Postgres.Models;
using MediatR;

namespace Admin.Commands_Handlers.Managment;

public class SendEntity<T>(T entity) : IRequest
    where T : Entity, new()
{
    public T Entity { get; set; } = entity;
}

public class InitializeDetailsPanelHandler<TEntity, TDetailsViewModel>(
    IMediator mediator,
    TDetailsViewModel viewModel) : IRequestHandler<SendEntity<TEntity>>
    where TEntity : Entity, new()
    where TDetailsViewModel : IDetailsPanel<TEntity>
{
    public Task Handle(SendEntity<TEntity> request, CancellationToken cancellationToken)
    {
        viewModel.SetEntity(request.Entity);
        mediator.Send(new InitializeUI<TEntity, TDetailsViewModel>(), cancellationToken);
        return Task.CompletedTask; 
    }
}

