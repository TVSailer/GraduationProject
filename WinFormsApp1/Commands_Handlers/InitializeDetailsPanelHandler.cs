using Admin.Memento;
using Admin.View.ViewForm;
using Admin.ViewModel.Interface;
using CSharpFunctionalExtensions;
using MediatR;

namespace Admin.Commands_Handlers.Managment;

public record InitializeDetailsPanelRequest<T>(T Entity) : IRequest
    where T : Entity, new();

public class InitializeDetailsPanelHandler<TEntity, TDetailsViewModel>(IView<TDetailsViewModel, TEntity> detailsPanel) : IRequestHandler<InitializeDetailsPanelRequest<TEntity>>
    where TEntity : Entity, new()
    where TDetailsViewModel : IFieldData<TEntity>
{
    public Task Handle(InitializeDetailsPanelRequest<TEntity> request, CancellationToken cancellationToken)
    {
        detailsPanel.ViewData.Entity.SetEntity(request.Entity);
        detailsPanel.InitializeComponents(null);
        return Task.CompletedTask;
    }
}