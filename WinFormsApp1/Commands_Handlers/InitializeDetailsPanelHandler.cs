using Admin.ViewModel.Interface;
using CSharpFunctionalExtensions;
using MediatR;

namespace Admin.Commands_Handlers.Managment;

public class InitializeDetailsPanelHandler<TEntity, TDetailsViewModel>(
    IMediator mediator,
    TDetailsViewModel viewModel) : IRequestHandler<SendEntity<TEntity>>
    where TEntity : Entity, new()
    where TDetailsViewModel : IDetailsPanel<TEntity>
{
    public Task Handle(SendEntity<TEntity> request, CancellationToken cancellationToken)
    {
        viewModel.SetEntity(request.Entity);
        mediator.Send(new InitializeUI<TDetailsViewModel>(), cancellationToken);
        return Task.CompletedTask; 
    }
}